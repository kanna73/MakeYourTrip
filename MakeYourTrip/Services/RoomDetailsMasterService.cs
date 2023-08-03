using MakeYourTrip.Interfaces;
using MakeYourTrip.Models.DTO;
using MakeYourTrip.Models;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip.Services
{
    public class RoomDetailsMasterService : IRoomDetailsMasterService
    {
        private readonly ICrud<RoomDetailsMaster, IdDTO> _RoomDetailsMasterRepo;
        private readonly ICrud<RoomTypeMaster, IdDTO> _RoomTypeMasterRepo;
        private readonly ICrud<HotelMaster, IdDTO> _hotelMasterRepo;



        public RoomDetailsMasterService(ICrud<RoomDetailsMaster, IdDTO> RoomDetailsMasterRepo,
            ICrud<RoomTypeMaster, IdDTO> RoomTypeMasterRepo, ICrud<HotelMaster, IdDTO> hotelMasterRepo)
        {
            _RoomDetailsMasterRepo = RoomDetailsMasterRepo;
            _RoomTypeMasterRepo=RoomTypeMasterRepo;
            _hotelMasterRepo = hotelMasterRepo;
        }

        public async Task<List<RoomDetailsMaster>?> Add_RoomDetailsMaster(List<RoomDetailsMaster> RoomDetailsMaster)
        {

            List<RoomDetailsMaster> addedRoomDetailsMaster = new List<RoomDetailsMaster>();

            var RoomDetailsMasters = await _RoomDetailsMasterRepo.GetAll();

            foreach (var roomDetailsMaster in RoomDetailsMaster)
            {

                Console.WriteLine(roomDetailsMaster);

                var myRoomDetailsMaster = await _RoomDetailsMasterRepo.Add(roomDetailsMaster);

                if (myRoomDetailsMaster != null)
                {
                    addedRoomDetailsMaster.Add(myRoomDetailsMaster);
                }

            }
            return addedRoomDetailsMaster;

        }

        public async Task<List<RoomDetailsMaster>?> Get_all_RoomDetailsMaster()
        {
            var RoomDetailsMasters = await _RoomDetailsMasterRepo.GetAll();
            return RoomDetailsMasters;

        }

        public async Task<List<RoomdetailsDTO>> getRoomDetailsByHotel(IdDTO id)
        {
            var RoomDetailsMasters = await _RoomDetailsMasterRepo.GetAll();
            var RoomTypeMasters = await _RoomTypeMasterRepo.GetAll();
            var HotelMasters = await _hotelMasterRepo.GetAll();

            var query = (from hm in HotelMasters
                        join rd in RoomDetailsMasters on hm.Id equals rd.HotelId
                        join rt in RoomTypeMasters on rd.RoomTypeId equals rt.Id
                        where hm.Id == id.IdInt
                        select new RoomdetailsDTO
                        {
                            RoomDetailsMasterId= rd.Id,
                            Price=rd.Price,
                            Description=rd.Description,
                            RoomType=rt.RoomType,

                        }).ToList();
            return query;



        }
    }
}
