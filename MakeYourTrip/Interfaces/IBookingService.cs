using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;

namespace MakeYourTrip.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> Add_Booking(Booking newHotel);
        Task<List<Booking>?> Get_all_Booking();
        Task<Booking?> View_Booking(IdDTO idDTO);
    }
}
