using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;

namespace MakeYourTrip.Interfaces
{
    public interface IVehicleBookingService
    {
        Task<VehicleBooking?> Add_VehicleBooking(VehicleBooking newHotel);
        Task<List<VehicleBooking>?> Get_all_VehicleBooking();
        Task<VehicleBooking?> View_VehicleBooking(IdDTO idDTO);
    }
}
