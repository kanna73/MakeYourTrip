using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;

namespace MakeYourTrip.Services
{
    public class RoomDetailsMasterService : IRoomDetailsMasterService
    {
        private readonly ICrud<RoomDetailsMaster, IdDTO> _RoomDetailsMasterRepo;

        public RoomDetailsMasterService(ICrud<RoomDetailsMaster, IdDTO> RoomDetailsMasterRepo)
        {
            _RoomDetailsMasterRepo = RoomDetailsMasterRepo;
        }

        public async Task<List<RoomDetailsMaster>?> Add_RoomDetailsMaster(List<RoomDetailsMaster> RoomDetailsMaster)
        {

            List<RoomDetailsMaster> addedRoomDetailsMaster = new List<RoomDetailsMaster>();

            var RoomDetailsMasters = await _RoomDetailsMasterRepo.GetAll();

            foreach (var roomDetailsMaster in RoomDetailsMaster)
            {

                Console.WriteLine(roomDetailsMaster);

                var myRoomDetailsMaster = await _RoomDetailsMasterRepo.Add(roomDetailsMaster);

                if (myRoomDetailsMaster != null)
                {
                    addedRoomDetailsMaster.Add(myRoomDetailsMaster);
                }

            }
            return addedRoomDetailsMaster;

        }

        public async Task<List<RoomDetailsMaster>?> Get_all_RoomDetailsMaster()
        {
            var RoomDetailsMasters = await _RoomDetailsMasterRepo.GetAll();
            return RoomDetailsMasters;

        }
    }
}
