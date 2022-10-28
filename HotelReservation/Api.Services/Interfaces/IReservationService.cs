using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IReservationService
    {
        Reservation Create(Reservation reservation);
        Reservation Update(Reservation reservation);
        Reservation FindById(int id);
        List<Reservation> FindAll();
        void Delete(int id);
    }
}
