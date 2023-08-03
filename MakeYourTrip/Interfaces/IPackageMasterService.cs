using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Interfaces
{
    public interface IPackageMasterService
    {
        Task<PackageMaster?> Add_PackageMaster(PackageMaster PackageMaster);

        Task<List<PackageMaster>?> Get_all_PackageMaster();
        Task<PackageMaster?> View_PackageMaster(IdDTO idDTO);

        Task<PackageDTO?> Get_package_details(IdDTO id);

        Task<PackageMaster> PostDashboardImage([FromForm] PackageFormModel packageFormModel);


    }
}
