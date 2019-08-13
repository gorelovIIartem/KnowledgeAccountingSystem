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
    [RoutePrefix("api/skill")]
    [Authorize(Roles ="admin")]
    public class SkillController:ApiController
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [OverrideFilter]
        [Authorize]
        [Route("")]
        public IHttpActionResult GetSkills()
        {
            IEnumerable<SkillModel> skills;
            try
            {
                skills = Mapper.Map<IEnumerable<SkillDTO>, IEnumerable<SkillModel>>(_skillService.GetSkills());
            }
            catch(ValidationException)
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
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateSkill([FromBody]SkillModel skill)
        {
            try
            {
                _skillService.Insert(Mapper.Map<SkillModel, SkillDTO>(skill));
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Skill created succesfully!" });
        }

        [Route("{skillId:int}")]
        public IHttpActionResult DeleteSkill(int skillId)
        {
            try
            {
                _skillService.Delete(skillId);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Skill deletae succesfully" });
        }

        [ModelValidation]
        [HttpPut]
        [Route("{skillId:int}")]
        public IHttpActionResult UpdateSkill(int skillId, [FromBody]SkillModel skill)
        {
            try
            {
                _skillService.Update(skillId, Mapper.Map<SkillModel, SkillDTO>(skill));
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Skill changed succesfully!" });
        }


    }
}