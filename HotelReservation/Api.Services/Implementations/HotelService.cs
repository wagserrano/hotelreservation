using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Repository.Generic;
using Api.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> _repository;
        private readonly IMapper _mapper;

        public HotelService(IRepository<Hotel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Hotel Create(Hotel hotel)
        {
            return _repository.Create(hotel);
        }

        public List<Hotel> FindAll()
        {
            return _repository.FindAll();
        }

        public Hotel FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Hotel Update(Hotel hotel)
        {
            return _repository.Update(hotel);
        }

        //public List<HotelDTO> FindAll()
        //{
        //    var myList = _repository.FindAll();
        //    List<HotelDTO> myRet = new List<HotelDTO>();
        //    //var myRet = Mapper.Map<IList<HotelDTO>, IList<Hotel>>(myList);
        //    if (myList != null)
        //    {
        //        foreach(var item in myList)
        //        {
        //            myRet.Add(new HotelDTO { Name = item.Name, Fulladdress = item.Fulladdress });
        //        }
        //    }
        //    return myRet;
        //}

        //public HotelDTO FindById(long id)
        //{
        //    return _mapper.Map<Hotel, HotelDTO>((_repository.FindById(id)));
        //}

        //public HotelDTO Update(HotelDTO dto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
