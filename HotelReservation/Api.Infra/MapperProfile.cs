using Api.Domain.DTOs;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Infra
{
    public  class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<CustomerDTO, Customer>().ReverseMap();
            //CreateMap<CustomerDTO, Customer>().ForMember();
            //CreateMap<HotelDTO, Hotel>().ReverseMap();
            //CreateMap<List<HotelDTO>, List<Hotel>>().ReverseMap();

            CreateMap<HotelDTO, Hotel>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dto => dto.Fulladdress, opt => opt.MapFrom(src => src.Fulladdress))
                .ReverseMap();
        }
    }
}
