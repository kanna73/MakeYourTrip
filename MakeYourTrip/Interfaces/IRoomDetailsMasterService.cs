using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;

namespace MakeYourTrip.Interfaces
{
    public interface IRoomDetailsMasterService
    {
        Task<List<RoomDetailsMaster>?> Add_RoomDetailsMaster(List<RoomDetailsMaster> RoomDetailsMaster);

        Task<List<RoomDetailsMaster>?> Get_all_RoomDetailsMaster();
        Task<List<RoomdetailsDTO>> getRoomDetailsByHotel(IdDTO id);
    }
}
