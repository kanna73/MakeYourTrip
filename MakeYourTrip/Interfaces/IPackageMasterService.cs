using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;

namespace MakeYourTrip.Interfaces
{
    public interface IPackageMasterService
    {
        Task<PackageMaster?> Add_PackageMaster(PackageMaster PackageMaster);

        Task<List<PackageMaster>?> Get_all_PackageMaster();
        Task<PackageMaster?> View_PackageMaster(IdDTO idDTO);


    }
}
