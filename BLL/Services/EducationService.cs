using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Entities;


namespace BLL.Services
{
    public class EducationService:IEducationService
    {
        IUnitOfWork DataBase { get; set; }
        public EducationService(IUnitOfWork uow)
        {
            DataBase = uow;
        }
        //++++++
        public IEnumerable<EducationDTO>GetEducationByProgrammerId(string id)
        {
            var programmer = DataBase.Programmers.Get(id);
            if (programmer == null)
                throw new ValidationException("Incorrect Id. Programmer is not foud", "Id");
            var education = DataBase.Educations.GetAll().Where(x => x.ProgrammerId == id);
            return Mapper.Map<IEnumerable<Education>, IEnumerable<EducationDTO>>(education);
        }

        //+++++++
        public void Insert(EducationDTO educationDTO)
        {
            if (educationDTO == null)
                throw new ValidationException("Information about this education is not exist", "Id");
            var education = DataBase.Educations.Get(educationDTO.Id);
            if (education != null)
                throw new ValidationException("Education with this id already exists.Try some more", "Id");
            DataBase.Educations.Insert(Mapper.Map<EducationDTO, Education>(educationDTO));
            DataBase.Save();
        }
        //+++++++
        public void Delete(int id)
        {
            var education = DataBase.Educations.Get(id);
            if (education == null)
                throw new ValidationException("Education with this id does not exist", "Id");
            DataBase.Educations.Delete(id);
            DataBase.Save();
        }


        public void Update(int educationId, EducationDTO educationDTO)
        {
            if (educationDTO == null)
                throw new ValidationException("Information about this education is not exist", "Id");
            if (educationId != educationDTO.Id)
                throw new ValidationException("Incorrect education id.Try some more", "Id");
            var education = DataBase.Educations.Get(educationDTO.Id);
            if (education == null)
                throw new ValidationException("Education has not foud", "Id");
            DataBase.Educations.Update(Mapper.Map<EducationDTO, Education>(educationDTO));
            DataBase.Save();
        }
    }
}
