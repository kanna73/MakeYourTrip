﻿using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Interfaces
{
    public interface IPackageDetailsMasterService
    {
        Task<List<PackageDetailsMaster>?> Add_PackageDetailsMaster(List<PackageDetailsMaster> PackageDetailsMaster);

        Task<List<PackageDetailsMaster>?> Get_all_PackageDetailsMaster();

        Task<PackageDetailsMaster> PostImage([FromForm] PlaceFormModel placeFormModel);

    }
}
