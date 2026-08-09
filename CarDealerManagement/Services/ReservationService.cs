using Entities.DTOs;
using RepositoryContracts;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            this._reservationRepository = reservationRepository;
        }

        public async Task<ResponseReservation> AddNewReservation(RequestAddNewReservation newReservation)
        {
            ResponseReservation response = await this._reservationRepository.AddNewReservation(newReservation);

            return response;
        }
    }
}
