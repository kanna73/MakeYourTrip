using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class RoomDetailsMasterRepo : ICrud<RoomDetailsMaster, IdDTO>
    {
        private readonly MakeYourTripContext _context;

        public RoomDetailsMasterRepo(MakeYourTripContext context)
        {
            _context = context;
        }

        public async Task<RoomDetailsMaster?> Add(RoomDetailsMaster item)
        {
            try
            {

                var newRoomDetailsMaster = _context.RoomDetailsMasters.FirstOrDefault(h => h.Id == item.Id);
                if (newRoomDetailsMaster == null)
                {
                    await _context.RoomDetailsMasters.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return item;
                }

                return null;
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public async Task<RoomDetailsMaster?> Delete(IdDTO item)
        {
            try
            {

                var RoomDetailsMasters = await _context.RoomDetailsMasters.ToListAsync();
                var myRoomDetailsMaster = RoomDetailsMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myRoomDetailsMaster != null)
                {
                    _context.RoomDetailsMasters.Remove(myRoomDetailsMaster);
                    await _context.SaveChangesAsync();
                    return myRoomDetailsMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<RoomDetailsMaster>?> GetAll()
        {
            try
            {
                var RoomDetailsMasters = await _context.RoomDetailsMasters.ToListAsync();
                if (RoomDetailsMasters != null)
                    return RoomDetailsMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomDetailsMaster?> GetValue(IdDTO item)
        {
            try
            {
                var RoomDetailsMasters = await _context.RoomDetailsMasters.ToListAsync();
                var RoomDetailsMaster = RoomDetailsMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (RoomDetailsMaster != null)
                    return RoomDetailsMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomDetailsMaster?> Update(RoomDetailsMaster item)
        {
            try
            {
                var RoomDetailsMasters = await _context.RoomDetailsMasters.ToListAsync();
                var RoomDetailsMaster = RoomDetailsMasters.SingleOrDefault(h => h.Id == item.Id);
                if (RoomDetailsMaster != null)
                {
                    RoomDetailsMaster.Price = item.Price != null ? item.Price : RoomDetailsMaster.Price;
                    RoomDetailsMaster.RoomTypeId = item.RoomTypeId != null ? item.RoomTypeId : RoomDetailsMaster.RoomTypeId;
                    RoomDetailsMaster.HotelId = item.HotelId != null ? item.HotelId : RoomDetailsMaster.HotelId;
                    RoomDetailsMaster.Description = item.Description != null ? item.Description : RoomDetailsMaster.Description;


                    _context.RoomDetailsMasters.Update(RoomDetailsMaster);
                    await _context.SaveChangesAsync();
                    return RoomDetailsMaster;
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
