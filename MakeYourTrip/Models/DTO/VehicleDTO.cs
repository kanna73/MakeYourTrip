﻿namespace MakeYourTrip.Models.DTO
{
    public class VehicleDTO
    {
        public int? VehicleDetailsId { get; set; }
        public string? VehicleName { get; set; }

        public int? NumberOfSeats { get; set; }
        public decimal? CarPrice { get; set; }
    }
}