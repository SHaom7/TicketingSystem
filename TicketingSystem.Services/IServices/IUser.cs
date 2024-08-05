using TicketingSystem.Data.Models;
using TicketingSystem.Data.Dtos;

namespace TicketingSystem.Data.IServices
{
    public interface IUser
    {
        public Task<string> postLogin(UserLoginDto userLoginDto);

        public Task postRegisterClient(UserRegisterDto userRegisterDto);

        public Task postRegisterEmployee(UserRegisterDto userRegisterDto);


    }
}
