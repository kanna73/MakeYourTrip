﻿using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class BookingRepo : ICrud<Booking, IdDTO>
    {
        private readonly MakeYourTripContext _context;

        public BookingRepo(MakeYourTripContext context)
        {
            _context = context;
        }
        public async Task<Booking?> Add(Booking item)
        {
            /* try
             {*/
            var newBooking = _context.Bookings.SingleOrDefault(h => h.Id == item.Id);
            if (newBooking == null)
            {
                await _context.Bookings.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }

            return null;
            /* }*/
            /*catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }*/
        }

        public async Task<Booking?> Delete(IdDTO item)
        {
            try
            {

                var Bookings = await _context.Bookings.ToListAsync();
                var myBooking = Bookings.FirstOrDefault(h => h.Id == item.IdInt);
                if (myBooking != null)
                {
                    _context.Bookings.Remove(myBooking);
                    await _context.SaveChangesAsync();
                    return myBooking;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<Booking>?> GetAll()
        {
            try
            {
                var Bookings = await _context.Bookings.ToListAsync();
                if (Bookings != null)
                    return Bookings;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Booking?> GetValue(IdDTO item)
        {
            try
            {
                var Bookings = await _context.Bookings.ToListAsync();
                var Booking = Bookings.SingleOrDefault(h => h.Id == item.IdInt);
                if (Booking != null)
                    return Booking;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Booking?> Update(Booking item)
        {
            try
            {
                var Bookings = await _context.Bookings.ToListAsync();
                var Booking = Bookings.SingleOrDefault(h => h.Id == item.Id);
                if (Booking != null)
                {
                    Booking.UserId = item.UserId != null ? item.UserId : Booking.UserId;
                    Booking.PackageMasterId = item.PackageMasterId != null ? item.PackageMasterId : Booking.PackageMasterId;
                    Booking.Feedback = item.Feedback != null ? item.Feedback : Booking.Feedback;
                    Booking.TotalAmount = item.TotalAmount != null ? item.TotalAmount : Booking.TotalAmount;


                    _context.Bookings.Update(Booking);
                    await _context.SaveChangesAsync();
                    return Booking;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

    }
}
