using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;

namespace MakeYourTrip.Services
{
    public class RoomTypeMasterService : IRoomTypeMasterService
    {
        private readonly ICrud<RoomTypeMaster, IdDTO> _RoomTypeMasterRepo;
        public RoomTypeMasterService(ICrud<RoomTypeMaster, IdDTO> RoomTypeMasterRepo)
        {
            _RoomTypeMasterRepo = RoomTypeMasterRepo;
        }

        public async Task<RoomTypeMaster?> Add_RoomTypeMaster(RoomTypeMaster RoomTypeMaster)
        {
            var palcemastertable = await _RoomTypeMasterRepo.GetAll();
            var newpalcemaster = palcemastertable?.SingleOrDefault(h => h.Id == RoomTypeMaster.Id);
            if (newpalcemaster == null)
            {
                var mypalcemaster = await _RoomTypeMasterRepo.Add(RoomTypeMaster);
                if (mypalcemaster != null)
                    return mypalcemaster;
            }
            return null;

        }
        public async Task<List<RoomTypeMaster>?> Get_all_RoomTypeMaster()
        {
            var RoomTypeMasters = await _RoomTypeMasterRepo.GetAll();
            return RoomTypeMasters;

        }

    }
}
