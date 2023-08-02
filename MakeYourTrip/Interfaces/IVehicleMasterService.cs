using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;

namespace MakeYourTrip.Interfaces
{
    public interface IVehicleMasterService
    {
        Task<VehicleMaster?> Add_VehicleMaster(VehicleMaster VehicleMaster);

        Task<List<VehicleMaster>?> Get_all_VehicleMaster();
        Task<VehicleMaster?> View_VehicleMaster(IdDTO idDTO);

    }
}
