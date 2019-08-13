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

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/profile")]
    public class WorkExperienceController:ApiController
    {
        private readonly IWorkExperienceService _workExperienceService;

        public WorkExperienceController(IWorkExperienceService workExperience)
        {
            _workExperienceService = workExperience;
        }

        [HttpGet]
        [Route("userId/workExperience")]
        public IHttpActionResult GetWOrkExperienceByProgrammerId(string userId)
        {
            IEnumerable<WorkExperienceModel> workExperience;
            try
            {
                workExperience = Mapper.Map<IEnumerable<WorkExperienceDTO>, IEnumerable<WorkExperienceModel>>(_workExperienceService.GetWorkExperienceOfProgrammer(userId));
            }
            catch(ValidationException)
            {
                return NotFound();
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(workExperience);
        }

        [ModelValidation]
        [AccessActionFilter]
        [Route("{userId}/work-experience")]
        public IHttpActionResult CreateWorkExperience(string userId,[FromBody]WorkExperienceModel workExperience)
        {
            try
            {
                _workExperienceService.Insert(Mapper.Map<WorkExperienceModel, WorkExperienceDTO>(workExperience));
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Work experience added succesfully!" });
        }

        [ModelValidation]
        [AccessActionFilter]
        [Route("{userId}/work-experience/{workExperienceId}")]
        public IHttpActionResult UpdateWorkExperience(string userId,int workExperienceId,[FromBody]WorkExperienceModel workExperience)
        {
            try
            {
                _workExperienceService.Update(workExperienceId, Mapper.Map<WorkExperienceModel, WorkExperienceDTO>(workExperience));
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Work experience updated succesfully!" });
        }

        [ModelValidation]
        [AccessActionFilter]
        [Route("{userId}/work-experience/{workExperienceId}")]
        public IHttpActionResult DeleteWorkExperience(string userId,int workExperienceId)
        {
            try
            {
                _workExperienceService.Delete(workExperienceId);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Workexperience deleted succesfulyy!" });
        }
    }
}