﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MakeYourTrip.Models;
using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;

namespace MakeYourTrip.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _BookingService;


        public BookingsController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<Booking>> Add_Booking(Booking newHotel)
        {
             try
             {
             
            var myBooking = await _BookingService.Add_Booking(newHotel);
            if (myBooking != null)
                return Created("Booking created Successfully", myBooking);
            return BadRequest(new Error(1, $"Booking {newHotel.Id} is Present already"));
            }
            
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }


        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet]

        public async Task<ActionResult<List<Booking>>> Get_all_Booking()
        {
            var myBookings = await _BookingService.Get_all_Booking();
            if (myBookings?.Count > 0)
                return Ok(myBookings);
            return BadRequest(new Error(10, "No Bookings are Existing"));
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]

        public async Task<ActionResult<Booking>> View_Booking(IdDTO idDTO)
        {
            try
            {
                if (idDTO.IdInt <= 0)
                    return BadRequest(new Error(4, "Enter Valid Booking ID"));
                var myBooking = await _BookingService.View_Booking(idDTO);
                if (myBooking != null)
                    return Created("Booking", myBooking);
                return BadRequest(new Error(9, $"There is no Booking present for the id {idDTO.IdInt}"));
            }
            catch (InvalidSqlException ise)
            {
                return BadRequest(new Error(25, ise.Message));
            }
        }
    }
}
