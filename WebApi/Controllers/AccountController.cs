using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using System.Web.Http;
using WebApi.Filters;
using WebApi.Models;
using BLL;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/account")]
    public class AccountController:ApiController
    {
        public IUserService UserService => Request.GetOwinContext().GetUserManager<IUserService>();

        [ModelValidation]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register([FromBody]RegisterModel model)
        {
            IdentityOperation operation;
            UserDTO userDTO = new UserDTO
            {
                Email = model.Email,
                Password = model.Password,
                UserName = model.UserName,
                FullName = model.FullName,
                Role = "user"
            };
            try
            {
                operation = await UserService.CreateUserAsync(userDTO);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            if (!operation.Succeeded)
                return BadRequest(operation.Message);
            return Ok(operation);
        }

        [AccessActionFilter]
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IHttpActionResult> DeleteUser([FromUri] string userId)
        {
            IdentityOperation operation;
            try
            {
                operation = await UserService.DeleteUser(userId);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            if (!operation.Succeeded)
                return BadRequest(operation.Message);
            return Ok(operation);
        }
    }
}