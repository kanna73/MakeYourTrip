using MakeYourTrip.Models;

namespace MakeYourTrip.Interfaces
{
    public interface IVehicleDetailsMasterService
    {
        Task<List<VehicleDetailsMaster>?> Add_VehicleDetailsMaster(List<VehicleDetailsMaster> VehicleDetailsMaster);

        Task<List<VehicleDetailsMaster>?> Get_all_VehicleDetailsMaster();
    }
}
