using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;

namespace MakeYourTrip.Interfaces
{
    public interface IRoomBookingService
    {
        Task<RoomBooking?> Add_RoomBooking(RoomBooking newHotel);
        Task<List<RoomBooking>?> Get_all_RoomBooking();
        Task<RoomBooking?> View_RoomBooking(IdDTO idDTO);
    }
}
