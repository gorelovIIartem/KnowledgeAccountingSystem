using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Microsoft.AspNet.Identity.EntityFramework;
using BLL.DTO;
using BLL.Infrastructure;


namespace BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        Task<IdentityOperation> CreateUserAsync(UserDTO userDTO);
        Task<IdentityUser> FindUserAsync(string userName, string password);
        Task<IdentityOperation> DeleteUser(string userId);
        IList<string> GetRoleByUserId(string userId);
    }
}
