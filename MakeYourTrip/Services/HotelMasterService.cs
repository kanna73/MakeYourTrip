using MakeYourTrip.Interfaces;
using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Repos;

namespace MakeYourTrip.Services
{
    public class HotelMasterService: IHotelMasterService
    {
        private readonly ICrud<HotelMaster, IdDTO> _hotelMasterRepo;
        public HotelMasterService(ICrud<HotelMaster, IdDTO> hotelMasterRepo)
        {
            _hotelMasterRepo = hotelMasterRepo;
        }

        public async Task<HotelMaster?> Add_HotelMaster(HotelMaster hotel)
        {
            var hotelMastertable = await _hotelMasterRepo.GetAll();
            var newHotelMaster = hotelMastertable?.SingleOrDefault(h => h.Id == hotel.Id);
            if (newHotelMaster == null)
            {
                var myHotelMaster = await _hotelMasterRepo.Add(hotel);
                if (myHotelMaster != null)
                    return myHotelMaster;
            }
            return null;

        }

        public async Task<List<HotelMaster>?> Get_all_HotelMaster()
        {
            var HotelMasters = await _hotelMasterRepo.GetAll();
            return HotelMasters;

        }

        public async Task<HotelMaster?> View_HotelMaster(IdDTO idDTO)
        {
            var HotelMaster = await _hotelMasterRepo.GetValue(idDTO);
            return HotelMaster;
        }
    }
}
