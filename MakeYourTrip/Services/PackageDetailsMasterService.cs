using MakeYourTrip.Interfaces;
using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Repos;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Services
{
    public class PackageDetailsMasterService: IPackageDetailsMasterService
    {
        private readonly ICrud<PackageDetailsMaster, IdDTO> _PackageDetailsMasterRepo;
        private readonly IImageRepo<PackageDetailsMaster, PlaceFormModel> _imageRepo;


        public PackageDetailsMasterService(ICrud<PackageDetailsMaster, IdDTO> PackageDetailsMasterRepo, IImageRepo<PackageDetailsMaster, PlaceFormModel> imageRepo)
        {
            _PackageDetailsMasterRepo = PackageDetailsMasterRepo;
            _imageRepo = imageRepo;
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

        public async Task<PackageDetailsMaster> PostImage([FromForm] PlaceFormModel placeFormModel)
        {
            if (placeFormModel == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _imageRepo.PostImage(placeFormModel);
            if (item == null)
            {
                return null;
            }
            return item;
        }
    }
}
