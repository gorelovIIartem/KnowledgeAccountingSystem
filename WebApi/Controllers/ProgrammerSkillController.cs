using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using System.Web.Http;
using WebApi.Filters;
using WebApi.Models;
using BLL;
using System.Collections.Generic;
using System;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("{api/programmer}")]
    public class ProgrammerSkillController : ApiController
    {
        private readonly ISkillService _skillService;

        public ProgrammerSkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        [Route("{userId/skills}")]
        public IHttpActionResult GetProgrammerSkils(string userId)
        {
            IEnumerable<ProgrammerSkillModel> skills;
            try
            {
                skills = Mapper.Map<IEnumerable<ProgrammerSkillDTO>, IEnumerable<ProgrammerSkillModel>>(_skillService.GetSkillOfProgrammer(userId));
            }
            catch (ValidationException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok(skills);
        }

        [ModelValidation]
        [AccessActionFilter]
        [HttpPost]
        [Route("{userId/skills}")]
        public IHttpActionResult AddSkillToProgrammer(string userId, [FromBody]ProgrammerSkillModel programmerSkill)
        {
            try
            {
                _skillService.AddSkillToProgrammer(Mapper.Map<ProgrammerSkillModel, ProgrammerSkillDTO>(programmerSkill));
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Skill added succesfully!" });
        }

        [ModelValidation]
        [AccessActionFilter]
        [HttpPut]
        [Route("{userId}/skills/{skillId}")]
        public IHttpActionResult UpdateSkillOfProgrammer(string userId, int skillId, [FromBody]ProgrammerSkillModel programmerSkill)
        {
            try
            {
                _skillService.UpdateSkillOfProgrammer(skillId, Mapper.Map<ProgrammerSkillModel, ProgrammerSkillDTO>(programmerSkill));

            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Skill updated succesfully!" });
        }

        [AccessActionFilter]
        [HttpDelete]
        [Route("{userId}/skills/{skillId}")]
        public IHttpActionResult DeleteSkillProgrammer(string userId, int skillId)
        {
            try
            {
                _skillService.DeleteSkillProgrammer(userId, skillId);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Skill deleted succesfully!" });
        }

        [HttpGet]
        [Route("{userId}/untouched-skills")]
        public IHttpActionResult GetProgrammerUntouchedSkills(string userId)
        {
            IEnumerable<SkillModel> skills;
            try
            {
                skills = Mapper.Map<IEnumerable<SkillDTO>, IEnumerable<SkillModel>>(_skillService.GetSkillProgrammerHavent(userId));
            }
            catch(ValidationException ex)
            {
                return NotFound();
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(skills);
        }
    }
}