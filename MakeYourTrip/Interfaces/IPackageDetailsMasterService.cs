using MakeYourTrip.Models;

namespace MakeYourTrip.Interfaces
{
    public interface IPackageDetailsMasterService
    {
        Task<List<PackageDetailsMaster>?> Add_PackageDetailsMaster(List<PackageDetailsMaster> PackageDetailsMaster);

        Task<List<PackageDetailsMaster>?> Get_all_PackageDetailsMaster();
    }
}
