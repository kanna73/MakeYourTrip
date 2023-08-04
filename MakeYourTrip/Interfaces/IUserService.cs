using MakeYourTrip.Models;
using MakeYourTrip.Models.DTO;

namespace MakeYourTrip.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Register(UserRegisterDTO userRegisterDTO);
        Task<UserDTO> LogIN(UserDTO userDTO);
        Task<UserDTO> Update(UserRegisterDTO user);
        Task<bool> Update_Password(UserDTO userRegisterDTO);

        Task<User?> ApproveAgent(User agent);
        Task<List<User>?> GetUnApprovedAgent();

        Task<User?> DeleteAgent(UserDTO user);
    }
}
