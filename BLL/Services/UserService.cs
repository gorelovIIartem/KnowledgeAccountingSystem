using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace BLL.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork DataBase { get; set; }
        public UserService(IUnitOfWork uow)
        {
            DataBase = uow;
        }
        public async Task<IdentityOperation> CreateUserAsync(UserDTO userDTO)
        {
         
            var user = await DataBase.UserManager.FindByEmailAsync(userDTO.Email);
            if(userDTO==null)
            {
                user = new ApplicationUser { Email = userDTO.Email, UserName = userDTO.UserName };
                IdentityResult result = await DataBase.UserManager.CreateAsync(user, userDTO.Password);
                if (result.Errors.Count() > 0)
                    return new IdentityOperation(false, result.Errors.FirstOrDefault(), "");
                await DataBase.UserManager.AddToRoleAsync(user.Id, userDTO.Role);
                Programmer programmer = new Programmer { Id = user.Id, WorkEmail = user.Email, FullName = userDTO.FullName };
                DataBase.Programmers.Insert(programmer);
                await DataBase.SaveAsync();
                return new IdentityOperation(true, "Congrtulations!!! You are successfully registrated", "");
            }
            else
            {
                return new IdentityOperation(false, "User with this data already exists", "WorkEmail");
            }
        }

        public async Task<IdentityUser> FindUserAsync(string userName, string password)
        {
            var user = await DataBase.UserManager.FindAsync(userName, password);
            return user;
        }

        public async Task<IdentityOperation> DeleteUser(string userId)
        {
            var user = await DataBase.UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                DataBase.Programmers.Delete(userId);
                var logins = user.Logins;
                var rolesForUser = await DataBase.UserManager.GetRolesAsync(userId);
                foreach (var login in logins.ToList())
                {
                    await DataBase.UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        var result = await DataBase.UserManager.RemoveFromRoleAsync(user.Id, item);
                    }
                }
                await DataBase.UserManager.DeleteAsync(user);
                await DataBase.SaveAsync();
                return new IdentityOperation(true, "User successfully deleted", "user");
            }
            else
                return new IdentityOperation(false, "Incorrect Id.Try some more", "user");

        }

        public IList<string> GetRoleByUserId(string id)
        {
            var roles = DataBase.UserManager.GetRoles(id);
            return roles;
        }

       
      

        public void Dispose()
        {
            DataBase.Dispose();
        }
       

    }
}
