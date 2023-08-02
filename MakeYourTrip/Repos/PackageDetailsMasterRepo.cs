using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using MakeYourTrip.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class PackageDetailsMasterRepo : ICrud<PackageDetailsMaster, IdDTO>
    {
        private readonly MakeYourTripContext _context;

        public PackageDetailsMasterRepo(MakeYourTripContext context)
        {
            _context = context;
        }

        public async Task<PackageDetailsMaster?> Add(PackageDetailsMaster item)
        {
            try
            {
               
                var newPackageDetailsMaster = _context.PackageDetailsMasters.FirstOrDefault(h => h.Id == item.Id);
                if (newPackageDetailsMaster == null)
                {
                    await _context.PackageDetailsMasters.AddAsync(item);
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

        public async Task<PackageDetailsMaster?> Delete(IdDTO item)
        {
            try
            {

                var PackageDetailsMasters = await _context.PackageDetailsMasters.ToListAsync();
                var myPackageDetailsMaster = PackageDetailsMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myPackageDetailsMaster != null)
                {
                    _context.PackageDetailsMasters.Remove(myPackageDetailsMaster);
                    await _context.SaveChangesAsync();
                    return myPackageDetailsMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<PackageDetailsMaster>?> GetAll()
        {
            try
            {
                var PackageDetailsMasters = await _context.PackageDetailsMasters.ToListAsync();
                if (PackageDetailsMasters != null)
                    return PackageDetailsMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PackageDetailsMaster?> GetValue(IdDTO item)
        {
            try
            {
                var PackageDetailsMasters = await _context.PackageDetailsMasters.ToListAsync();
                var PackageDetailsMaster = PackageDetailsMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (PackageDetailsMaster != null)
                    return PackageDetailsMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PackageDetailsMaster?> Update(PackageDetailsMaster item)
        {
            try
            {
                var PackageDetailsMasters = await _context.PackageDetailsMasters.ToListAsync();
                var PackageDetailsMaster = PackageDetailsMasters.SingleOrDefault(h => h.Id == item.Id);
                if (PackageDetailsMaster != null)
                {
                    PackageDetailsMaster.PackageId = item.PackageId != null ? item.PackageId : PackageDetailsMaster.PackageId;
                    PackageDetailsMaster.PlaceId = item.PlaceId != null ? item.PlaceId : PackageDetailsMaster.PlaceId;
                    PackageDetailsMaster.DayNumber = item.DayNumber != null ? item.DayNumber : PackageDetailsMaster.DayNumber;

                    _context.PackageDetailsMasters.Update(PackageDetailsMaster);
                    await _context.SaveChangesAsync();
                    return PackageDetailsMaster;
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
