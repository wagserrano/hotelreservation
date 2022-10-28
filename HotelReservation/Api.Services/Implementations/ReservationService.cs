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
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IRepository<RoomOccupancy> _reproomocc;
        private readonly IMapper _mapper;

        public ReservationService(IRepository<Reservation> repository, IRepository<RoomOccupancy> reproomocc, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _reproomocc = reproomocc;
        }
        public Reservation Create(Reservation reservation)
        {
            // Search for busy dates
            var myRet = _reproomocc.FindAll().Where(r => r.RoomId.Equals(reservation.RoomId));
            var myRet2 = _reproomocc.FindAll();
            var dateReset = new DateTime(reservation.BeginDate.Year, reservation.BeginDate.Month, reservation.BeginDate.Day, 0, 0, 0);
            reservation.BeginDate = dateReset;
            dateReset = dateReset.AddDays(reservation.ReservedDays);
            dateReset = new DateTime(dateReset.Year, dateReset.Month, dateReset.Day, 23, 59, 59);
            reservation.EndDate = dateReset;
            return _repository.Create(reservation);
        }

        public List<Reservation> FindAll()
        {
            return _repository.FindAll();
        }

        public Reservation FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Reservation Update(Reservation reservation)
        {
            return _repository.Update(reservation);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
