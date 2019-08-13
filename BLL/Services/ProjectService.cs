using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ProjectService:IProjectService
    {
        private IUnitOfWork DataBase { get; set; }
        public ProjectService(IUnitOfWork uow)
        {
            DataBase = uow;
        }
        //+++++++++
        public IEnumerable<ProjectDTO> GetProjectByProgrammerId(string id)
        {
            var programmer = DataBase.Programmers.Get(id);
            if (programmer == null)
                throw new ValidationException("Incorrect programmer`s Id. Try some more", "Id");
            var project = DataBase.Projects.GetAll().Where(x => x.ProgrammerId == id).ToList() ;
            return Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(project);
        }
        //+++++
        public void Insert(ProjectDTO projectDTO)
        {
            if (projectDTO == null)
                throw new ValidationException("No information about this project. Try some more", "Id");
            var project = DataBase.Projects.Get(projectDTO.Id);
            if (project != null)
                throw new ValidationException("Project with this Id already exists. Try some more", "Id");
            DataBase.Projects.Insert(Mapper.Map<ProjectDTO, Project>(projectDTO));
            DataBase.Save();
        }
        //++++
        public void Update(int projectId, ProjectDTO projectDTO)
        {
            if (projectDTO == null)
                throw new ValidationException("No information about this project. Try some more", "Id");
            if (projectId != projectDTO.Id)
                throw new ValidationException("Project`s Id does not match", "Id");
            var project = DataBase.Projects.Get(projectDTO.Id);
            if (project == null)
                throw new ValidationException("Incorrect project`s Id. Try some more", "Id");
            DataBase.Projects.Update(Mapper.Map<ProjectDTO, Project>(projectDTO));
            DataBase.Save();
        }
        //+++++
        public void Delete(int id)
        {
            var project = DataBase.Projects.Get(id);
            if (project == null)
                throw new ValidationException("Incoorect project`s id. try some more", "Id");
            DataBase.Projects.Delete(id);
            DataBase.Save();
        }
    }
}
