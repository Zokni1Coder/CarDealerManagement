using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IReservationRepository
    {
        Task<ResponseReservation> AddNewReservation(RequestAddNewReservation newReservation);
        Task<List<Reservation>?> GetAllReservation();
        Task<List<Reservation>?> GetAllActiveReservations();
        Task SaveChange();
    }
}
