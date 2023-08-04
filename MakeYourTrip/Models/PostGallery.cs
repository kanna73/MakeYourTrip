using System;
using System.Collections.Generic;

namespace MakeYourTrip.Models;

public partial class PostGallery
{
    public int Id { get; set; }

    public int? AdminId { get; set; }

    public string? Adminimage { get; set; }

    public string? ImageType { get; set; }

    public virtual User? Admin { get; set; }
}
