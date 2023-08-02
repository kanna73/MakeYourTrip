using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class PackageMasterRepo : ICrud<PackageMaster, IdDTO>
    {
        private readonly MakeYourTripContext _context;

        public PackageMasterRepo(MakeYourTripContext context)
        {
            _context = context;
        }
        public async Task<PackageMaster?> Add(PackageMaster item)
        {
            /* try
             {*/
            var newPackageMaster = _context.PackageMasters.SingleOrDefault(h => h.Id == item.Id);
            if (newPackageMaster == null)
            {
                await _context.PackageMasters.AddAsync(item);
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

        public async Task<PackageMaster?> Delete(IdDTO item)
        {
            try
            {

                var PackageMasters = await _context.PackageMasters.ToListAsync();
                var myPackageMaster = PackageMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myPackageMaster != null)
                {
                    _context.PackageMasters.Remove(myPackageMaster);
                    await _context.SaveChangesAsync();
                    return myPackageMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<PackageMaster>?> GetAll()
        {
            try
            {
                var PackageMasters = await _context.PackageMasters.ToListAsync();
                if (PackageMasters != null)
                    return PackageMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PackageMaster?> GetValue(IdDTO item)
        {
            try
            {
                var PackageMasters = await _context.PackageMasters.ToListAsync();
                var PackageMaster = PackageMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (PackageMaster != null)
                    return PackageMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PackageMaster?> Update(PackageMaster item)
        {
            try
            {
                var PackageMasters = await _context.PackageMasters.ToListAsync();
                var PackageMaster = PackageMasters.SingleOrDefault(h => h.Id == item.Id);
                if (PackageMaster != null)
                {
                    PackageMaster.PackagePrice = item.PackagePrice != null ? item.PackagePrice : PackageMaster.PackagePrice;
                    PackageMaster.PackageName = item.PackageName != null ? item.PackageName : PackageMaster.PackageName;
                    PackageMaster.TravelAgentId = item.TravelAgentId != null ? item.TravelAgentId : PackageMaster.TravelAgentId;
                    PackageMaster.Region = item.Region != null ? item.Region : PackageMaster.Region;

                    _context.PackageMasters.Update(PackageMaster);
                    await _context.SaveChangesAsync();
                    return PackageMaster;
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
