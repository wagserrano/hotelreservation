using Api.Domain.DTOs;
using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IHotelService
    {
        Hotel Create(Hotel hotel);
        Hotel Update(Hotel hotel);
        Hotel FindById(int id);
        List<Hotel> FindAll();
    }
}
