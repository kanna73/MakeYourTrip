using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;

namespace MakeYourTrip.Services
{
    public class VehicleMasterService : IVehicleMasterService
    {
        private readonly ICrud<VehicleMaster, IdDTO> _VehicleMasterRepo;
        public VehicleMasterService(ICrud<VehicleMaster, IdDTO> VehicleMasterRepo)
        {
            _VehicleMasterRepo = VehicleMasterRepo;
        }

        public async Task<VehicleMaster?> Add_VehicleMaster(VehicleMaster VehicleMaster)
        {
            var palcemastertable = await _VehicleMasterRepo.GetAll();
            var newpalcemaster = palcemastertable?.SingleOrDefault(h => h.Id == VehicleMaster.Id);
            if (newpalcemaster == null)
            {
                var mypalcemaster = await _VehicleMasterRepo.Add(VehicleMaster);
                if (mypalcemaster != null)
                    return mypalcemaster;
            }
            return null;

        }
        public async Task<List<VehicleMaster>?> Get_all_VehicleMaster()
        {
            var VehicleMasters = await _VehicleMasterRepo.GetAll();
            return VehicleMasters;

        }

        public async Task<VehicleMaster?> View_VehicleMaster(IdDTO idDTO)
        {
            var VehicleMaster = await _VehicleMasterRepo.GetValue(idDTO);
            return VehicleMaster;
        }
    }
}
