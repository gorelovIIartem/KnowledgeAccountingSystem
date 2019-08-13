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

namespace WebApi.Controllers
{
    [RoutePrefix("api/manager")]
    [Authorize(Roles ="admin")]
    public class ManagerController:ApiController
    {
        private readonly IProgrammerService _programmerService;

        public ManagerController(IProgrammerService programmerService)
        {
            _programmerService = programmerService;
        }

        [Route("programmers")]
        public IHttpActionResult GetProgrammersBySkills(int? skillId, int programmerSkillLevel)
        {
            IEnumerable<ProgrammerModel> programmers;
            try
            {
                programmers = Mapper.Map<IEnumerable<ProgrammerDTO>, IEnumerable<ProgrammerModel>>(_programmerService.GetProgrammersBySkill(skillId, programmerSkillLevel));
            }
            catch(ValidationException)
            {
                return NotFound();
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(programmers);
        }

        [ModelValidation]
        [Route("programmers/{skillId}{programmerSkillLevel}/create-report")]
        public HttpResponseMessage CreateReport(List<ProgrammerModel> programmers)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            try
            {
                responseMessage.Content = new ByteArrayContent(_programmerService.GenerateReport(Mapper.Map<List<ProgrammerModel>, List<ProgrammerDTO>>(programmers)));
            }
            catch (ValidationException ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
            responseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            { FileName = "Programmers.xlsx" };
            responseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.speadsheetml.sheet");
            return responseMessage;
        }
    }
}