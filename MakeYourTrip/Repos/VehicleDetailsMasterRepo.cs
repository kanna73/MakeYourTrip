using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Repos
{
    public class VehicleDetailsMasterRepo : ICrud<VehicleDetailsMaster, IdDTO>, IImageRepo<VehicleDetailsMaster, VehicleFormModel>
    {
        private readonly MakeYourTripContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public VehicleDetailsMasterRepo(MakeYourTripContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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

        public async Task<VehicleDetailsMaster> PostImage([FromForm] VehicleFormModel vehicleFormModel)
        {
            if (vehicleFormModel == null)
            {
                throw new ArgumentException("Invalid file");
            }

            string VehicleImagepath1 = await SaveImage(vehicleFormModel.FormFile);
            var vehicle = new VehicleDetailsMaster();
            vehicle.VehicleId = vehicleFormModel.VehicleId;
            vehicle.CarPrice = vehicleFormModel.CarPrice;
            vehicle.PlaceId = vehicleFormModel.PlaceId;
            vehicle.VehicleImagepath = VehicleImagepath1;
            _context.VehicleDetailsMasters.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }


        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot/Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }


    }
}
