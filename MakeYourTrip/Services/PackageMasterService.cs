using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using MakeYourTrip.Repos;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

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
        private readonly IImageRepo _imageRepo;
        public PackageMasterService(ICrud<PackageMaster, IdDTO> PackageMasterRepo,
            ICrud<PlaceMaster, IdDTO> placemasterRepo,ICrud<PackageDetailsMaster, IdDTO> packageDetailsMasterRepo
            , ICrud<HotelMaster, IdDTO> hotelMasterRepo, ICrud<VehicleMaster, IdDTO> vehicleMasterRepo,
            ICrud<VehicleDetailsMaster, IdDTO> vehicleDetailsMasterRepo, IImageRepo imageRepo)
        {
            _packageMasterRepo = PackageMasterRepo;
            _placemasterRepo = placemasterRepo;
            _packageDetailsMasterRepo = packageDetailsMasterRepo;
            _hotelMasterRepo = hotelMasterRepo;
            _vehicleMasterRepo = vehicleMasterRepo;
            _vehicleDetailsMasterRepo = vehicleDetailsMasterRepo;
            _imageRepo = imageRepo;
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
            return PackageMasters;

        }

        public async Task<PackageMaster?> View_PackageMaster(IdDTO idDTO)
        {
            var packageMaster = await _packageMasterRepo.GetValue(idDTO);
            return packageMaster;
        }

        public async Task<PackageMaster> PostDashboardImage([FromForm] PackageMaster packageMaster)
        {
            if (packageMaster == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostPackageMasterImage(packageMaster);
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

            var result = (from pm in packageMasterData
                         where pm.Id == 1
                         select new PackageDTO
                         {
                             PackageName = pm.PackageName,
                             PackagePrice = pm.PackagePrice,
                             TravelAgentId=pm.TravelAgentId,
                             Region= pm.Region,

                             placeList = (from pm1 in packageMasterData
                                         join pd in packageDetailsData on pm1.Id equals pd.PackageId
                                         join pl in placeData on pd.PlaceId equals pl.Id
                                         where pm1.Id == id.IdInt
                                          select new PlaceDTO
                                         {
                                             PlaceName = pl.PlaceName,
                                             DayNumber = pd.DayNumber,
                                             HotelList = (from pm in packageMasterData
                                                         join pd in packageDetailsData on pm.Id equals pd.PackageId
                                                         join pl in placeData on pd.PlaceId equals pl.Id
                                                         join hm in hotelMasterData on pl.Id equals hm.PlaceId
                                                         where pm.Id == id.IdInt
                                                          select new HotelDTO
                                                         {
                                                             HotelId= hm.Id,
                                                             HotelName =hm.HotelName,
                                                         }).ToList(),

                             VechileList= (from pm in packageMasterData
                                          join pd in packageDetailsData on pm.Id equals pd.PackageId
                                          join pl in placeData on pd.PlaceId equals pl.Id
                                          join vd in VehicleDetailsData on pl.Id equals vd.PlaceId
                                          join vm in vehicleMasterData on vd.VehicleId equals vm.Id
                                           where pm.Id == id.IdInt
                                               select new VehicleDTO
                                               {
                                                 VehicleDetailsId= vd.VehicleId,
                                                  CarPrice =vd.CarPrice,
                                                  VehicleName = vm.VehicleName,
                                                  NumberOfSeats = vm.NumberOfSeats,
                                               }).ToList(),
                                         }).ToList(),



                         }).FirstOrDefault();
            return result;

        }
    }
}
