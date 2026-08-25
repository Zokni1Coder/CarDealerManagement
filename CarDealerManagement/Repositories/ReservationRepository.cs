using Entities;
using Entities.DTOs;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Reservation>?> GetAllActiveReservations()
        {
            List<Reservation>? allReservations = await this.GetAllReservation();

            List<Reservation>? activeReservations = allReservations?.Where(r => r.Status == ReservationStatus.active).ToList();

            return activeReservations;
        }

        public async Task<List<Reservation>?> GetAllReservation()
        {
            List<Reservation>? reservations = await this._carDealerDbContext.Reservations.ToListAsync();

            return reservations;
        }

        public async Task SaveChange()
        {
            await this._carDealerDbContext.SaveChangesAsync();
        }
    }
}
