using MakeYourTrip.Interfaces;
using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Repos;

namespace MakeYourTrip.Services
{
    public class PlaceMasterService: IPlaceMasterService
    {
        private readonly ICrud<PlaceMaster, IdDTO> _placemasterRepo;
        public PlaceMasterService(ICrud<PlaceMaster, IdDTO> placemasterRepo)
        {
            _placemasterRepo= placemasterRepo;
        }

        public async Task<PlaceMaster?> Add_PlaceMaster(PlaceMaster placeMaster)
        {
            var palcemastertable = await _placemasterRepo.GetAll();
            var newpalcemaster = palcemastertable?.SingleOrDefault(h => h.Id == placeMaster.Id);
            if (newpalcemaster == null)
            {
                var mypalcemaster = await _placemasterRepo.Add(placeMaster);
                if (mypalcemaster != null)
                    return mypalcemaster;
            }
            return null;

        }
        public async Task<List<PlaceMaster>?> Get_all_placemaster()
        {
            var PlaceMasters = await _placemasterRepo.GetAll();
            return PlaceMasters;

        }

        public async Task<PlaceMaster?> Delete_PlaceMaster(IdDTO idDTO)
        {
            var placeMaster = await _placemasterRepo.Delete(idDTO);
            return placeMaster;
        }


    }
}
