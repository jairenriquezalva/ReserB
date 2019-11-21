using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserB.Models;
using ReserB.Services.Contracts;

namespace ReserB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
		IReservationRepository _reservationRepository;

		public ReservationController(IReservationRepository reservationRepository)
		{
			_reservationRepository = reservationRepository;
		}

		[HttpPost]
		public async Task<ActionResult> InsertSpace(Reservation reservation)
		{
			await _reservationRepository.InsertOne(reservation);
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpGet("customer/{id}")]
		public async Task<ActionResult> GetReservationByCustomer(string id)
		{
			var reservations = await _reservationRepository.GetByCustomer(id);
			return new JsonResult(reservations);
		}

		[HttpGet("space/{id}")]
		public async Task<ActionResult> GetSpaceBySpace(string id)
		{
			var reservations = await _reservationRepository.GetBySpace(id);
			return new JsonResult(reservations);
		}
	}
}