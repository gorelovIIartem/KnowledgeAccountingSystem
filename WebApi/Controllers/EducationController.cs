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
    public class EducationController:ApiController
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        [HttpGet]
        [Route("{userId}/education")]
        public IHttpActionResult GetEducationByProgrammerId(string userId)
        {
            IEnumerable<EducationModel> education;
            try
            {
                education = Mapper.Map<IEnumerable<EducationDTO>, IEnumerable<EducationModel>>(_educationService.GetEducationByProgrammerId(userId));
            }
            catch(ValidationException)
            {
                return NotFound();
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(education);
        }

        [ModelValidation]
        [AccessActionFilter]
        [HttpPost]
        [Route("{userId}/education")]
        public IHttpActionResult CreateEducationProgrammer(string userId,[FromBody]EducationModel education )
        {
            try
            {
                _educationService.Insert(Mapper.Map<EducationModel,EducationDTO>(education));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Education added successfully!" });
        }

        [ModelValidation]
        [AccessActionFilter]
        [Route("{userId}/education/{educationId}")]
        public IHttpActionResult UpdateEducation(string userId, int educationId,[FromBody]EducationModel education)
        {
            try
            {
                _educationService.Update(educationId, Mapper.Map<EducationModel, EducationDTO>(education));
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Education updated succesfully!" });
        }
        [ModelValidation]
        [AccessActionFilter]
        [Route("{userId}/education/{educationId}")]
        public IHttpActionResult DeleteEducation(string userId,int educationId)
        {
            try
            {
                _educationService.Delete(educationId);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Education deleted succesfully!" });
        }
    }
    
}