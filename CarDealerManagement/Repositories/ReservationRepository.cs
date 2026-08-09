using Entities;
using Entities.DTOs;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarDealerDbContext _carDealerDbContext;

        public ReservationRepository(CarDealerDbContext carDealerDbContext)
        {
            this._carDealerDbContext = carDealerDbContext;
        }

        public async Task<ResponseReservation> AddNewReservation(RequestAddNewReservation newReservation)
        {
            Reservation reservation = newReservation.ToReservation();

            await this._carDealerDbContext.Reservations.AddAsync(reservation);

            await this._carDealerDbContext.SaveChangesAsync();

            return reservation.ToResponseReservation();
        }
    }
}
