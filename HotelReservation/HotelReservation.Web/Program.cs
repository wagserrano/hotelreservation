using Api.Infra;
using Api.Repository.Context;
using Api.Repository.Generic;
using Api.Services.Implementations;
using Api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddMvc().AddRazorPagesOptions(opt => {
//    opt.RootDirectory = "/pg";
//});
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
//builder.Services.AddMvcCore();

// Enabling API Versioning
builder.Services.AddApiVersioning();

// Enabling Swagger
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Hotel Reservation REST API",
            Version = "v1",
            Description = "API RESTful developed in .NET Core 6",
            Contact = new OpenApiContact
            {
                Name = "Wagner Serrano",
                Url = new Uri("https://github.com/wagserrano"),
                Email = "wagserrano@gmail.com"
            }
        });
    });

// Enabling AutoMapper
var configMap = new MapperConfiguration(cfg =>
{
    //cfg.CreateMap<>
    cfg.AddProfile(new MapperProfile());
});
IMapper mapper = configMap.CreateMapper();
builder.Services.AddSingleton(mapper);

// Enabling get data from AppSettings.json
builder.Configuration.AddJsonFile("appsettings.json");

var connDb = builder.Configuration["ConnectionStrings:SqlLocalDb"];

// Enabling EF DbContext and database
builder.Services.AddDbContext<MyDbContext>(
opt =>
{
    //opt.UseSqlite(connDb);
    opt.UseSqlServer(connDb);
}
);

// Dependency Injection from Services and respective contracts 
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    using (var myScope = app.Services.CreateScope())
    {
        var myCtx = myScope.ServiceProvider.GetRequiredService<MyDbContext>();
        myCtx.Database.EnsureCreated();
    }
}
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Reservation API v1");
    //c.RoutePrefix = String.Empty;
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
//});
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapRazorPages();
//    //endpoints.MapControllerRoute(
//    //    name: "default",
//    //    pattern: "{controller=Hotel}/{action=Index}/{id?}");
//});

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
