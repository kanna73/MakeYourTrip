using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Interfaces
{
    public interface IVehicleDetailsMasterService
    {
        Task<List<VehicleDetailsMaster>?> Add_VehicleDetailsMaster(List<VehicleDetailsMaster> VehicleDetailsMaster);

        Task<List<VehicleDetailsMaster>?> Get_all_VehicleDetailsMaster();
        Task<VehicleDetailsMaster> PostImage([FromForm] VehicleFormModel vehicleFormModel);

    }
}
