using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Services
{
    public class VehicleDetailsMasterService : IVehicleDetailsMasterService
    {
        private readonly ICrud<VehicleDetailsMaster, IdDTO> _VehicleDetailsMasterRepo;
        private readonly IImageRepo<VehicleDetailsMaster, VehicleFormModel> _imageRepo;


        public VehicleDetailsMasterService(ICrud<VehicleDetailsMaster, IdDTO> VehicleDetailsMasterRepo, IImageRepo<VehicleDetailsMaster, VehicleFormModel> imageRepo)
        {
            _VehicleDetailsMasterRepo = VehicleDetailsMasterRepo;
            _imageRepo = imageRepo;
        }

        public async Task<List<VehicleDetailsMaster>?> Add_VehicleDetailsMaster(List<VehicleDetailsMaster> VehicleDetailsMaster)
        {

            List<VehicleDetailsMaster> addedVehicleDetailsMaster = new List<VehicleDetailsMaster>();

            var VehicleDetailsMasters = await _VehicleDetailsMasterRepo.GetAll();

            foreach (var vehicleDetailsMaster in VehicleDetailsMaster)
            {

                Console.WriteLine(vehicleDetailsMaster);

                var myVehicleDetailsMaster = await _VehicleDetailsMasterRepo.Add(vehicleDetailsMaster);

                if (myVehicleDetailsMaster != null)
                {
                    addedVehicleDetailsMaster.Add(myVehicleDetailsMaster);
                }

            }
            return addedVehicleDetailsMaster;

        }

        public async Task<List<VehicleDetailsMaster>?> Get_all_VehicleDetailsMaster()
        {
            var VehicleDetailsMasters = await _VehicleDetailsMasterRepo.GetAll();
            return VehicleDetailsMasters;

        }

        public async Task<VehicleDetailsMaster> PostImage([FromForm] VehicleFormModel vehicleFormModel)
        {
            if (vehicleFormModel == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostImage(vehicleFormModel);
            if (item == null)
            {
                return null;
            }
            return item;
        }
    }
}
