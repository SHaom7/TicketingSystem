using Microsoft.AspNetCore.Identity;
using TicketingSystem.Data.IServices;
using TicketingSystem.Data.Dtos;
using TicketingSystem.Data.Models;

namespace TicketingSystem.Services.Services
{
    public class UserRepo : IUser
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepo(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<string> postLogin(UserLoginDto userLoginDto)
        {
            User user = null;

            if (!string.IsNullOrEmpty(userLoginDto.Email))
            {
                user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            }
            else if (!string.IsNullOrEmpty(userLoginDto.Username))
            {
                user = await _userManager.FindByNameAsync(userLoginDto.Username);
            }

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, userLoginDto.Password, userLoginDto.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Manager"))
                    {
                        return "ManagerDashboard";
                    }
                    else if (roles.Contains("Employee"))
                    {
                        return "EmployeeDashboard";
                    }
                    else if (roles.Contains("Client"))
                    {
                        return "ClientDashboard";
                    }
                }
            }

            return "LoginFailed";
        }

        public async Task postRegisterClient(UserRegisterDto userRegisterDto)
        {
            UserImage img = new UserImage()
            { 
                ImgId = Guid.NewGuid(),
                Path = userRegisterDto.ImgPath,
            };

            User user = new User()
            {
                UserId = Guid.NewGuid(),
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                PasswordHash = userRegisterDto.Password,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Birthday = userRegisterDto.Birthday,
                Address = userRegisterDto.Address,
                ImgId = img.ImgId,
                Status = UserStatus.Active,
  
            };

            img.User = user;

            var obj = await _userManager.CreateAsync(user);
            if(obj != null)
            {
                await _userManager.AddToRoleAsync(user, "Client");
            }
        }


        public async Task postRegisterEmployee(UserRegisterDto userRegisterDto)
        {
            UserImage img = new UserImage()
            {
                ImgId = Guid.NewGuid(),
                Path = userRegisterDto.ImgPath,
            };

            User user = new User()
            {
                UserId = Guid.NewGuid(),
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                PasswordHash = userRegisterDto.Password,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Birthday = userRegisterDto.Birthday,
                Address = userRegisterDto.Address,
                ImgId = img.ImgId,
                Status = UserStatus.Active,

            };

            img.User = user;

            var obj = await _userManager.CreateAsync(user);
            if (obj != null)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
            }
        }
    }
}
