using MakeYourTrip.Exceptions;
using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Repos
{
    public class PackageMasterRepo : ICrud<PackageMaster, IdDTO>, IImageRepo<PackageMaster, PackageFormModel>
    {
        private readonly MakeYourTripContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public PackageMasterRepo(MakeYourTripContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment= hostEnvironment;
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

        public async Task<PackageMaster> PostImage([FromForm] PackageFormModel packageFormModel)
        {
            if (packageFormModel == null)
            {
                throw new ArgumentException("Invalid file");
            }

            packageFormModel.Imagepath = await SaveImage(packageFormModel.FormFile);
            var newPackageMaster = new PackageMaster();
            newPackageMaster.PackagePrice= packageFormModel.PackagePrice;
            newPackageMaster.PackageName = packageFormModel.PackageName;
            newPackageMaster.TravelAgentId = packageFormModel.TravelAgentId;
            newPackageMaster.Region = packageFormModel.Region;
            newPackageMaster.Duration = packageFormModel.Duration;
            newPackageMaster.Imagepath = packageFormModel.Imagepath;


            _context.PackageMasters.Add(newPackageMaster);
            await _context.SaveChangesAsync();
            return newPackageMaster;
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
