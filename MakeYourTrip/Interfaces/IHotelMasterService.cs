using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Interfaces
{
    public interface IHotelMasterService
    {
        Task<HotelMaster?> Add_HotelMaster(HotelMaster newHotel);
        Task<List<HotelMaster>?> Get_all_HotelMaster();
        Task<HotelMaster?> View_HotelMaster(IdDTO idDTO);

    }
}
