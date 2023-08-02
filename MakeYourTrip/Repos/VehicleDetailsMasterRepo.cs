using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Repos
{
    public class VehicleDetailsMasterRepo : ICrud<VehicleDetailsMaster, IdDTO>
    {
        private readonly MakeYourTripContext _context;

        public VehicleDetailsMasterRepo(MakeYourTripContext context)
        {
            _context = context;
        }

        public async Task<VehicleDetailsMaster?> Add(VehicleDetailsMaster item)
        {
            try
            {

                var newVehicleDetailsMaster = _context.VehicleDetailsMasters.FirstOrDefault(h => h.Id == item.Id);
                if (newVehicleDetailsMaster == null)
                {
                    await _context.VehicleDetailsMasters.AddAsync(item);
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

        public async Task<VehicleDetailsMaster?> Delete(IdDTO item)
        {
            try
            {

                var VehicleDetailsMasters = await _context.VehicleDetailsMasters.ToListAsync();
                var myVehicleDetailsMaster = VehicleDetailsMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myVehicleDetailsMaster != null)
                {
                    _context.VehicleDetailsMasters.Remove(myVehicleDetailsMaster);
                    await _context.SaveChangesAsync();
                    return myVehicleDetailsMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<VehicleDetailsMaster>?> GetAll()
        {
            try
            {
                var VehicleDetailsMasters = await _context.VehicleDetailsMasters.ToListAsync();
                if (VehicleDetailsMasters != null)
                    return VehicleDetailsMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<VehicleDetailsMaster?> GetValue(IdDTO item)
        {
            try
            {
                var VehicleDetailsMasters = await _context.VehicleDetailsMasters.ToListAsync();
                var VehicleDetailsMaster = VehicleDetailsMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (VehicleDetailsMaster != null)
                    return VehicleDetailsMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<VehicleDetailsMaster?> Update(VehicleDetailsMaster item)
        {
            try
            {
                var VehicleDetailsMasters = await _context.VehicleDetailsMasters.ToListAsync();
                var VehicleDetailsMaster = VehicleDetailsMasters.SingleOrDefault(h => h.Id == item.Id);
                if (VehicleDetailsMaster != null)
                {
                    VehicleDetailsMaster.VehicleId = item.VehicleId != null ? item.VehicleId : VehicleDetailsMaster.VehicleId;
                    VehicleDetailsMaster.PlaceId = item.PlaceId != null ? item.PlaceId : VehicleDetailsMaster.PlaceId;
                    VehicleDetailsMaster.CarPrice = item.CarPrice != null ? item.CarPrice : VehicleDetailsMaster.CarPrice;

                    _context.VehicleDetailsMasters.Update(VehicleDetailsMaster);
                    await _context.SaveChangesAsync();
                    return VehicleDetailsMaster;
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
