using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class RoomTypeMasterRepo : ICrud<RoomTypeMaster, IdDTO>
    {
        private readonly MakeYourTripContext _context;

        public RoomTypeMasterRepo(MakeYourTripContext context)
        {
            _context = context;
        }
        public async Task<RoomTypeMaster?> Add(RoomTypeMaster item)
        {
            /* try
             {*/
            var newRoomTypeMaster = _context.RoomTypeMasters.SingleOrDefault(h => h.Id == item.Id);
            if (newRoomTypeMaster == null)
            {
                await _context.RoomTypeMasters.AddAsync(item);
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

        public async Task<RoomTypeMaster?> Delete(IdDTO item)
        {
            try
            {

                var RoomTypeMasters = await _context.RoomTypeMasters.ToListAsync();
                var myRoomTypeMaster = RoomTypeMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myRoomTypeMaster != null)
                {
                    _context.RoomTypeMasters.Remove(myRoomTypeMaster);
                    await _context.SaveChangesAsync();
                    return myRoomTypeMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<RoomTypeMaster>?> GetAll()
        {
            try
            {
                var RoomTypeMasters = await _context.RoomTypeMasters.ToListAsync();
                if (RoomTypeMasters != null)
                    return RoomTypeMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomTypeMaster?> GetValue(IdDTO item)
        {
            try
            {
                var RoomTypeMasters = await _context.RoomTypeMasters.ToListAsync();
                var RoomTypeMaster = RoomTypeMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (RoomTypeMaster != null)
                    return RoomTypeMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<RoomTypeMaster?> Update(RoomTypeMaster item)
        {
            try
            {
                var RoomTypeMasters = await _context.RoomTypeMasters.ToListAsync();
                var RoomTypeMaster = RoomTypeMasters.SingleOrDefault(h => h.Id == item.Id);
                if (RoomTypeMaster != null)
                {
                    RoomTypeMaster.RoomType = item.RoomType != null ? item.RoomType : RoomTypeMaster.RoomType;
                   

                    _context.RoomTypeMasters.Update(RoomTypeMaster);
                    await _context.SaveChangesAsync();
                    return RoomTypeMaster;
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
