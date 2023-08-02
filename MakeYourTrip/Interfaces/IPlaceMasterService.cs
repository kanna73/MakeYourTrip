using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Interfaces
{
    public interface IPlaceMasterService
    {
        Task<PlaceMaster?> Add_PlaceMaster(PlaceMaster placeMaster);

        Task<List<PlaceMaster>?> Get_all_placemaster();

        Task<PlaceMaster?> Delete_PlaceMaster(IdDTO idDTO);

    }
}
