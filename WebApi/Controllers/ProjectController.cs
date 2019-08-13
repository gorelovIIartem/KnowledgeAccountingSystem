using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Filters;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/profile")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("{userId}/project")]
        public IHttpActionResult GetProjectByProgrammerId(string userId)
        {
            IEnumerable<ProjectModel> project;
            try
            {
                project = Mapper.Map<IEnumerable<ProjectDTO>, IEnumerable<ProjectModel>>(_projectService.GetProjectByProgrammerId(userId));
            }
            catch (ValidationException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok(project);
        }

        [ModelValidation]
        [AccessActionFilter]
        [HttpPost]
        [Route("{userId}/project")]
        public IHttpActionResult CreateProject(string userId, [FromBody]ProjectModel project)
        {
            try
            {
                _projectService.Insert(Mapper.Map<ProjectModel, ProjectDTO>(project));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                InternalServerError();
            }
            return Ok(new { Message = "Project created succesfully!" });
        }

        [ModelValidation]
        [AccessActionFilter]
        [Route("{userId}/project/{projectId}")]
        public IHttpActionResult UpdateProject(string userId, int projectId,[FromBody]ProjectModel project)
        {
            try
            {
                _projectService.Update(projectId, Mapper.Map<ProjectModel, ProjectDTO>(project));
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { Message = "Project updated succesfully!" });
        }

        [ModelValidation]
        [AccessActionFilter]
        [Route("{userId}/project/{projectId}")]
        public IHttpActionResult DeleteProject(string userId, int projectId)
        {
            try
            {
                _projectService.Delete(projectId);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
            return Ok(new { message = "Project deleted succesfully!" });
        }
    }
}