﻿using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using MakeYourTrip.Repos;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using NuGet.Packaging;

namespace MakeYourTrip.Services
{
    public class PackageMasterService: IPackageMasterService
    {
        private readonly ICrud<PackageMaster, IdDTO> _packageMasterRepo;
        private readonly ICrud<PlaceMaster, IdDTO> _placemasterRepo;
        private readonly ICrud<PackageDetailsMaster, IdDTO> _packageDetailsMasterRepo;
        private readonly ICrud<HotelMaster, IdDTO> _hotelMasterRepo;
        private readonly ICrud<VehicleMaster, IdDTO> _vehicleMasterRepo;
        private readonly ICrud<VehicleDetailsMaster, IdDTO> _vehicleDetailsMasterRepo;
        private readonly IImageRepo<PackageMaster, PackageFormModel> _imageRepo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PackageMasterService(ICrud<PackageMaster, IdDTO> PackageMasterRepo,
            ICrud<PlaceMaster, IdDTO> placemasterRepo,ICrud<PackageDetailsMaster, IdDTO> packageDetailsMasterRepo
            , ICrud<HotelMaster, IdDTO> hotelMasterRepo, ICrud<VehicleMaster, IdDTO> vehicleMasterRepo,
            ICrud<VehicleDetailsMaster, IdDTO> vehicleDetailsMasterRepo, 
            IImageRepo<PackageMaster, PackageFormModel> imageRepo,IWebHostEnvironment hostEnvironment)
        {
            _packageMasterRepo = PackageMasterRepo;
            _placemasterRepo = placemasterRepo;
            _packageDetailsMasterRepo = packageDetailsMasterRepo;
            _hotelMasterRepo = hotelMasterRepo;
            _vehicleMasterRepo = vehicleMasterRepo;
            _vehicleDetailsMasterRepo = vehicleDetailsMasterRepo;
            _imageRepo = imageRepo;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<PackageMaster?> Add_PackageMaster(PackageMaster PackageMaster)
        {
            var packageMastertable = await _packageMasterRepo.GetAll();
            var newpackageMaster = packageMastertable?.SingleOrDefault(h => h.Id == PackageMaster.Id);
            if (newpackageMaster == null)
            {
                var mypackageMaster = await _packageMasterRepo.Add(PackageMaster);
                if (mypackageMaster != null)
                    return mypackageMaster;
            }
            return null;

        }
        public async Task<List<PackageMaster>?> Get_all_PackageMaster()
        {
            var PackageMasters = await _packageMasterRepo.GetAll();
            var images = await _packageMasterRepo.GetAll();
            var imageList = new List<PackageMaster>();
            foreach (var image in images)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploadsFolder, image.Imagepath);

                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                var tourData = new PackageMaster
                {
                    Id = image.Id,
                    PackagePrice = image.PackagePrice,
                    PackageName = image.PackageName,
                    TravelAgentId = image.TravelAgentId,
                    Duration= image.Duration,
                    Region = image.Region,

                    Imagepath = Convert.ToBase64String(imageBytes)
                };
                imageList.Add(tourData);
            }
            return imageList;

        }

        public async Task<PackageMaster?> View_PackageMaster(IdDTO idDTO)
        {
            var packageMaster = await _packageMasterRepo.GetValue(idDTO);
            return packageMaster;
        }

        public async Task<PackageMaster> PostDashboardImage([FromForm] PackageFormModel packageFormModel)
        {
            if (packageFormModel == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostImage(packageFormModel);
            if (item == null)
            {
                return null;
            }
            return item;
        }



       

        public async Task<PackageDTO?> Get_package_details(IdDTO id)
        {
            var placeData = await _placemasterRepo.GetAll();
            var packageMasterData = await _packageMasterRepo.GetAll();
            var packageDetailsData = await _packageDetailsMasterRepo.GetAll();
            var hotelMasterData = await _hotelMasterRepo.GetAll();
            var vehicleMasterData = await _vehicleMasterRepo.GetAll();
            var VehicleDetailsData = await _vehicleDetailsMasterRepo.GetAll();

            var places = (from pd in packageDetailsData
                          join pl in placeData on pd.PlaceId equals pl.Id
                          where pd.PackageId == id.IdInt
                          select pl).Distinct().ToList();

            var vehiclesGroupedByPlace = (from vd in VehicleDetailsData
                                          join vm in vehicleMasterData on vd.VehicleId equals vm.Id
                                          join pl in placeData on vd.PlaceId equals pl.Id
                                          where places.Any(p => p.Id == pl.Id) // Filter vehicles for places linked to the package
                                          group new { vd, vm } by pl into g
                                          select new
                                          {
                                              PlaceId = g.Key.Id,
                                              Vehicles = g.Select(async item => new VehicleDTO
                                              {
                                                  VehicleDetailsId = item.vd.VehicleId,
                                                  CarPrice = item.vd.CarPrice,
                                                  VehicleName = item.vm.VehicleName,
                                                  NumberOfSeats = item.vm.NumberOfSeats,
                                                  VehicleImagepath = await getImage(item.vd.VehicleImagepath),
                                              }).ToList()
                                          }).ToList();

            var result = (from pm in packageMasterData
                          where pm.Id == id.IdInt
                          select new PackageDTO
                          {
                              PackageName = pm.PackageName,
                              PackagePrice = pm.PackagePrice,
                              TravelAgentId = pm.TravelAgentId,
                              Region = pm.Region,
                              Imagepath = pm.Imagepath,

                              placeList = (from pm1 in packageMasterData
                                           join pd in packageDetailsData on pm1.Id equals pd.PackageId
                                           join pl in placeData on pd.PlaceId equals pl.Id
                                           where pm1.Id == id.IdInt
                                           select new PlaceDTO
                                           {
                                               placeId = pl.Id,
                                               PlaceName = pl.PlaceName,
                                               DayNumber = pd.DayNumber,
                                               PlaceImagepath=pd.PlaceImagepath,
                                               HotelList = (from hm in hotelMasterData
                                                            where hm.PlaceId == pl.Id
                                                            select new HotelDTO
                                                            {
                                                                HotelId = hm.Id,
                                                                HotelName = hm.HotelName,
                                                                HotelImagepath = hm.HotelImagepath, // Just assign the path here
                                                            }).ToList(),
                                           }).ToList(),
                          }).FirstOrDefault();

            if (result != null && !string.IsNullOrEmpty(result.Imagepath))
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploadsFolder, result.Imagepath);

                // Check if the image file exists
                if (File.Exists(filePath))
                {
                    var imageBytes = await File.ReadAllBytesAsync(filePath);
                    result.Imagepath = Convert.ToBase64String(imageBytes);
                } // Calculate the image data for the package
            }

            // Populate the VechileList for each place
            if (result != null && result.placeList != null)
            {
                foreach (var place in result.placeList)
                {
                    place.PlaceImagepath = await getImage(place.PlaceImagepath);

                    foreach (var hotel in place.HotelList)
                    {
                        hotel.HotelImagepath = await getImage(hotel.HotelImagepath);
                    }
                }

                foreach (var place in result.placeList)
                {
                    var vehiclesForPlace = vehiclesGroupedByPlace.FirstOrDefault(g => g.PlaceId == place.placeId)?.Vehicles;
                    if (vehiclesForPlace != null)
                    {
                        place.VechileList = new List<VehicleDTO>();
                        foreach (var vehicleTask in vehiclesForPlace)
                        {
                            var vehicle = await vehicleTask; // Await the task to get the VehicleDTO
                            place.VechileList.Add(vehicle); // Add the VehicleDTO to VechileList
                        }
                    }
                }
            }


            return result;
        }

        [NonAction]
        public async Task<string?> getImage(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                // Handle the case where the path is null or empty
                return null;
            }
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
            var filePath = Path.Combine(uploadsFolder, path);

            // Check if the image file exists
            if (File.Exists(filePath))
            {
                var imageBytes = await File.ReadAllBytesAsync(filePath);
                string image = Convert.ToBase64String(imageBytes);
                return image;
            }
            return null;
        }


    }
}
