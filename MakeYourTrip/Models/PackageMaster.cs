using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeYourTrip.Models;

public partial class PackageMaster
{
    public int Id { get; set; }

    public decimal? PackagePrice { get; set; }

    public string? PackageName { get; set; }

    public int? TravelAgentId { get; set; }

    public string? Region { get; set; }

    public string? Imagepath { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Hotel image is required.")]
   /* [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
    [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]*/
    public IFormFile? HotelImage { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<PackageDetailsMaster> PackageDetailsMasters { get; set; } = new List<PackageDetailsMaster>();

    public virtual User? TravelAgent { get; set; }
}
