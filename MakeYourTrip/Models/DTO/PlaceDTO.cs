namespace MakeYourTrip.Models.DTO
{
    public class PlaceDTO
    {
        public string? PlaceName { get; set; }
        public int? DayNumber { get; set; }

        public List<HotelDTO>? HotelList { get; set; }
        public List<VehicleDTO>? VechileList { get; set; }


    }
}
