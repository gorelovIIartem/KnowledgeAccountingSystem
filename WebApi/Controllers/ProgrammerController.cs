using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Filters;
using WebApi.Models;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL;
using AutoMapper;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/profile")]
    public class ProgrammerController:ApiController
    {
        private readonly IProgrammerService _programmerService;
        public ProgrammerController(IProgrammerService programmerService)
        {
            _programmerService = programmerService;
        }

        [HttpGet]
        [Route("{userId/programmer}")]
        public IHttpActionResult GetProgrammer(string userId)
        {
            ProgrammerDTO programmer=null;
            try
            {
                programmer = _programmerService.Get(userId);
            }
            catch(ValidationException)
            {
                return NotFound();
            }
            catch(Exception)
            {
                InternalServerError();
            }
            return Ok(Mapper.Map<ProgrammerDTO, ProgrammerModel>(programmer));
        }
    }
}