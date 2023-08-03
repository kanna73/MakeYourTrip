using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Repos
{
    public class HotelMasterRepo : ICrud<HotelMaster, IdDTO>, IImageRepo<HotelMaster, HotelFormModule>
    {
        private readonly MakeYourTripContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public HotelMasterRepo(MakeYourTripContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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

        public async Task<HotelMaster> PostImage([FromForm] HotelFormModule hotelFormModule)
        {
            if (hotelFormModule == null)
            {
                throw new ArgumentException("Invalid file");
            }

            string HotelImagepath1 = await SaveImage(hotelFormModule.FormFile);
            var hotel = new HotelMaster();
            hotel.HotelName = hotelFormModule.HotelName;
            hotel.PlaceId = hotelFormModule.PlaceId;
            hotel.HotelImagepath = HotelImagepath1;
            _context.HotelMasters.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
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
