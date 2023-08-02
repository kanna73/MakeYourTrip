﻿using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;

namespace MakeYourTrip.Services
{
    public class VehicleDetailsMasterService : IVehicleDetailsMasterService
    {
        private readonly ICrud<VehicleDetailsMaster, IdDTO> _VehicleDetailsMasterRepo;

        public VehicleDetailsMasterService(ICrud<VehicleDetailsMaster, IdDTO> VehicleDetailsMasterRepo)
        {
            _VehicleDetailsMasterRepo = VehicleDetailsMasterRepo;
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
    }
}
