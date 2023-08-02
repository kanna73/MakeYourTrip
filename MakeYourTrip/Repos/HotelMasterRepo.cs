using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class HotelMasterRepo : ICrud<HotelMaster, IdDTO>
    {
        private readonly MakeYourTripContext _context;

        public HotelMasterRepo(MakeYourTripContext context)
        {
            _context = context;
        }
        public async Task<HotelMaster?> Add(HotelMaster item)
        {
            /* try
             {*/
            var newHotelMaster = _context.HotelMasters.SingleOrDefault(h => h.Id == item.Id);
            if (newHotelMaster == null)
            {
                await _context.HotelMasters.AddAsync(item);
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

        public async Task<HotelMaster?> Delete(IdDTO item)
        {
            try
            {

                var HotelMasters = await _context.HotelMasters.ToListAsync();
                var myHotelMaster = HotelMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myHotelMaster != null)
                {
                    _context.HotelMasters.Remove(myHotelMaster);
                    await _context.SaveChangesAsync();
                    return myHotelMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<HotelMaster>?> GetAll()
        {
            try
            {
                var HotelMasters = await _context.HotelMasters.ToListAsync();
                if (HotelMasters != null)
                    return HotelMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<HotelMaster?> GetValue(IdDTO item)
        {
            try
            {
                var HotelMasters = await _context.HotelMasters.ToListAsync();
                var HotelMaster = HotelMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (HotelMaster != null)
                    return HotelMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<HotelMaster?> Update(HotelMaster item)
        {
            try
            {
                var HotelMasters = await _context.HotelMasters.ToListAsync();
                var HotelMaster = HotelMasters.SingleOrDefault(h => h.Id == item.Id);
                if (HotelMaster != null)
                {
                    HotelMaster.HotelName = item.HotelName != null ? item.HotelName : HotelMaster.HotelName;
                    HotelMaster.PlaceId = item.PlaceId != null ? item.PlaceId : HotelMaster.PlaceId;
                    
                    _context.HotelMasters.Update(HotelMaster);
                    await _context.SaveChangesAsync();
                    return HotelMaster;
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
