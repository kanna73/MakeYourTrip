using MakeYourTrip.Interfaces;
using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Repos;

namespace MakeYourTrip.Services
{
    public class PackageDetailsMasterService: IPackageDetailsMasterService
    {
        private readonly ICrud<PackageDetailsMaster, IdDTO> _PackageDetailsMasterRepo;

        public PackageDetailsMasterService(ICrud<PackageDetailsMaster, IdDTO> PackageDetailsMasterRepo)
        {
            _PackageDetailsMasterRepo = PackageDetailsMasterRepo;
        }

        public async Task<List<PackageDetailsMaster>?> Add_PackageDetailsMaster(List<PackageDetailsMaster> PackageDetailsMaster)
        {

            List<PackageDetailsMaster> addedPackageDetailsMaster = new List<PackageDetailsMaster>();

            var PackageDetailsMasters = await _PackageDetailsMasterRepo.GetAll();

            foreach (var packageDetailsMaster in PackageDetailsMaster)
            {

                Console.WriteLine(packageDetailsMaster);

                var myPackageDetailsMaster = await _PackageDetailsMasterRepo.Add(packageDetailsMaster);

                if (myPackageDetailsMaster != null)
                {
                    addedPackageDetailsMaster.Add(myPackageDetailsMaster);
                }

            }
            return addedPackageDetailsMaster;

        }

        public async Task<List<PackageDetailsMaster>?> Get_all_PackageDetailsMaster()
        {
            var PackageDetailsMasters = await _PackageDetailsMasterRepo.GetAll();
            return PackageDetailsMasters;

        }
    }
}
