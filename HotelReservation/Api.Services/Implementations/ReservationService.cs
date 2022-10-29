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
            if (reservation.BeginDate < DateTime.Now.AddDays(1) )
            {
                reservation.Status = "Invalid begin date, the minimum date is tomorrow";
                return reservation;
            }
            if (reservation.BeginDate > DateTime.Now.AddDays(30))
            {
                reservation.Status = "Invalid begin date, you can't book with 1 month in advance";
                return reservation;
            }

            Reservation vldReservation = this.ValidDates(reservation);
            if (string.IsNullOrEmpty(vldReservation.Status))
            {
                try
                {
                    var algum = _repository.Create(vldReservation);
                    vldReservation = algum;
                    var datesReserve = vldReservation.BeginDate;
                    for (int i = 0; i < vldReservation.ReservedDays; i++)
                    {
                        _reproomocc.Create(new RoomOccupancy { RoomId = vldReservation.RoomId, DateBusy = datesReserve, BookingId = vldReservation.Id });
                        datesReserve = datesReserve.AddDays(1);
                    }
                    
                }
                catch (Exception ex)
                {
                    vldReservation.Status = ex.Message;
                }
            }
            return vldReservation;
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
            //return _repository.Update(reservation);
            if (reservation.BeginDate < DateTime.Now.AddDays(1))
            {
                reservation.Status = "Invalid begin date, the minimum date is tomorrow";
                return reservation;
            }
            if (reservation.BeginDate > DateTime.Now.AddDays(30))
            {
                reservation.Status = "Invalid begin date, you can't book with 1 month in advance";
                return reservation;
            }

            Reservation vldReservation = this.ValidDates(reservation);
            if (string.IsNullOrEmpty(vldReservation.Status))
            {
                try
                {
                    var myRetA = _reproomocc.FindAll();
                    var myRetB = myRetA.FindAll(x => x.BookingId.Equals(vldReservation.Id));
                    if (myRetB.Any())
                    {
                        foreach (var item in myRetB)
                        {
                            _reproomocc.Delete(item.Id);
                        }
                    }
                    var algum = _repository.Update(vldReservation);
                    vldReservation = algum;
                    var datesReserve = vldReservation.BeginDate;
                    for (int i = 0; i < vldReservation.ReservedDays; i++)
                    {
                        _reproomocc.Create(new RoomOccupancy { RoomId = vldReservation.RoomId, DateBusy = datesReserve, BookingId = vldReservation.Id });
                        datesReserve = datesReserve.AddDays(1);
                    }

                }
                catch (Exception ex)
                {
                    vldReservation.Status = ex.Message;
                }
            }
            return vldReservation;

        }
        public void Delete(int id)
        {
            try
            {
                var myRet1 = _reproomocc.FindAll();
                var myRet2 = myRet1.FindAll(x => x.BookingId.Equals(id));
                if (myRet2.Any())
                {
                    foreach (var item in myRet2)
                    {
                        _reproomocc.Delete(item.Id);
                    }
                }
                _repository.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Reservation ValidDates(Reservation reservation)
        {
            reservation.Status = string.Empty;
            string verDates = string.Empty;
            // Search for busy dates
            //var myRet = _reproomocc.FindAll().Where(r => r.RoomId.Equals(reservation.RoomId));
            var myRet1 = _reproomocc.FindAll();
            var myRet2 = myRet1.FindAll(x => x.RoomId.Equals(reservation.RoomId));
            var dateReset = new DateTime(reservation.BeginDate.Year, reservation.BeginDate.Month, reservation.BeginDate.Day, 0, 0, 0);
            reservation.BeginDate = dateReset;
            dateReset = dateReset.AddDays(reservation.ReservedDays-1);
            dateReset = new DateTime(dateReset.Year, dateReset.Month, dateReset.Day, 23, 59, 59);
            reservation.EndDate = dateReset;
            dateReset = reservation.BeginDate.Date;
            for (int i = 0; i < reservation.ReservedDays; i++)
            {
                if (myRet2.Count(x => x.DateBusy.Date.Equals(dateReset) && !x.BookingId.Equals(reservation.Id)) > 0)
                {
                    //verDates += dateReset.ToString() + ", ";
                    verDates += Convert.ToDateTime(dateReset, System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy") + ", ";
                }
                dateReset = dateReset.AddDays(1);
            }
            if (verDates.Any())
            {
                reservation.Status = verDates + " not available";
            }
            return reservation;
        }
    }
}
