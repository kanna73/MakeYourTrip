using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class PlaceMasterRepo: ICrud<PlaceMaster, IdDTO>
    {
        private readonly MakeYourTripContext _context;

        public PlaceMasterRepo(MakeYourTripContext context)
        {
            _context = context;
        }
        public async Task<PlaceMaster?> Add(PlaceMaster item)
        {
           /* try
            {*/
                var newPlaceMaster = _context.PlaceMasters.SingleOrDefault(h => h.Id == item.Id);
                if (newPlaceMaster == null)
                {
                    await _context.PlaceMasters.AddAsync(item);
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

        public async Task<PlaceMaster?> Delete(IdDTO item)
        {
            try
            {

                var PlaceMasters = await _context.PlaceMasters.ToListAsync();
                var myPlaceMaster = PlaceMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myPlaceMaster != null)
                {
                    _context.PlaceMasters.Remove(myPlaceMaster);
                    await _context.SaveChangesAsync();
                    return myPlaceMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<PlaceMaster>?> GetAll()
        {
            try
            {
                var PlaceMasters = await _context.PlaceMasters.ToListAsync();
                if (PlaceMasters != null)
                    return PlaceMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PlaceMaster?> GetValue(IdDTO item)
        {
            try
            {
                var PlaceMasters = await _context.PlaceMasters.ToListAsync();
                var PlaceMaster = PlaceMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (PlaceMaster != null)
                    return PlaceMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PlaceMaster?> Update(PlaceMaster item)
        {
            try
            {
                var PlaceMasters = await _context.PlaceMasters.ToListAsync();
                var PlaceMaster = PlaceMasters.SingleOrDefault(h => h.Id == item.Id);
                if (PlaceMaster != null)
                {
                    PlaceMaster.PlaceName = item.PlaceName != null ? item.PlaceName : PlaceMaster.PlaceName;
                    _context.PlaceMasters.Update(PlaceMaster);
                    await _context.SaveChangesAsync();
                    return PlaceMaster;
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
