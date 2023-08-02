using MakeYourTrip.Models;

namespace MakeYourTrip.Interfaces
{
    public interface IRoomTypeMasterService
    {
        Task<RoomTypeMaster?> Add_RoomTypeMaster(RoomTypeMaster RoomTypeMaster);

        Task<List<RoomTypeMaster>?> Get_all_RoomTypeMaster();
    }
}
