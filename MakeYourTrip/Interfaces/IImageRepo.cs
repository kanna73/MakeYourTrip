using MakeYourTrip.Models;
using Microsoft.AspNetCore.Mvc;

namespace MakeYourTrip.Interfaces
{
    public interface IImageRepo
    {
        Task<PackageMaster> PostPackageMasterImage([FromForm] PackageMaster packageMaster);
    }
}
