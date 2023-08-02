using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using MakeYourTrip.Repos;

namespace MakeYourTrip.Services
{
    public class PackageMasterService: IPackageMasterService
    {
        private readonly ICrud<PackageMaster, IdDTO> _PackageMasterRepo;
        public PackageMasterService(ICrud<PackageMaster, IdDTO> PackageMasterRepo)
        {
            _PackageMasterRepo = PackageMasterRepo;
        }

        public async Task<PackageMaster?> Add_PackageMaster(PackageMaster PackageMaster)
        {
            var palcemastertable = await _PackageMasterRepo.GetAll();
            var newpalcemaster = palcemastertable?.SingleOrDefault(h => h.Id == PackageMaster.Id);
            if (newpalcemaster == null)
            {
                var mypalcemaster = await _PackageMasterRepo.Add(PackageMaster);
                if (mypalcemaster != null)
                    return mypalcemaster;
            }
            return null;

        }
        public async Task<List<PackageMaster>?> Get_all_PackageMaster()
        {
            var PackageMasters = await _PackageMasterRepo.GetAll();
            return PackageMasters;

        }

        public async Task<PackageMaster?> View_PackageMaster(IdDTO idDTO)
        {
            var packageMaster = await _PackageMasterRepo.GetValue(idDTO);
            return packageMaster;
        }
    }
}
