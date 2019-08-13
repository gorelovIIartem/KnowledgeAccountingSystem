using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using BLL.Interfaces;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class WorkExperienceService: IWorkExperienceService
    {
        IUnitOfWork DataBase { get; set; }
        public WorkExperienceService(IUnitOfWork uow)
        {
            DataBase = uow;
        }
        public void Delete(int id)
        {
            var workExperience = DataBase.WorkExperiences.Get(id);
            if (workExperience == null)
                throw new ValidationException("Work experience for this id does not exist", "Id");
            DataBase.WorkExperiences.Delete(id);
            DataBase.Save();
        }
        //+++++++++=
        public IEnumerable<WorkExperienceDTO> GetWorkExperienceOfProgrammer(string id)
        {
            var programmer = DataBase.Programmers.Get(id);
            if (programmer == null)
                throw new ValidationException("Incorrect programmer id.Try some more", "Id");
            var workExperience = DataBase.WorkExperiences.GetAll().Where(x => x.ProgrammerId == id);
            return Mapper.Map<IEnumerable<WorkExperience>, IEnumerable<WorkExperienceDTO>>(workExperience);
        }
        //+++++++++++++
        public void Insert(WorkExperienceDTO workExperienceDTO)
        {
            if (workExperienceDTO == null)
                throw new ValidationException("Information of this work experience does not exist. Try some more", "Id");
            var workExperience = DataBase.WorkExperiences.Get(workExperienceDTO.Id);
            if (workExperience != null)
                throw new ValidationException("Work experience with this id already exists. Try some more", "Id");
            DataBase.WorkExperiences.Insert(Mapper.Map<WorkExperienceDTO, WorkExperience>(workExperienceDTO));
            DataBase.Save();
        }
        //+++
        public void Update(int workExperienceId, WorkExperienceDTO workExperienceDTO)
        {
            if (workExperienceDTO == null)
                throw new ValidationException("Information about this work experience does not exist. Try some more", "Id");
            if (workExperienceId != workExperienceDTO.Id)
                throw new ValidationException("Skill`s id don`t match", "Id");
            var workExperience = DataBase.WorkExperiences.Get(workExperienceDTO.Id);
            if (workExperience == null)
                throw new ValidationException("Incorrect id. Try some more", "Id");
            DataBase.WorkExperiences.Update(Mapper.Map<WorkExperienceDTO, WorkExperience>(workExperienceDTO));
            DataBase.Save();
        }
    }
}
