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
    public class SkillService:ISkillService
    {
        private readonly IUnitOfWork DataBase;
        public SkillService(IUnitOfWork uow)
        {
            DataBase = uow;
        }
        //++++++
        public void UpdateSkillOfProgrammer(int skillId, ProgrammerSkillDTO skillDTO)
        {
            if (skillDTO == null)
                throw new ValidationException("No information about programmer`s skil", "Id");
            if (skillId != skillDTO.SkillId)
                throw new ValidationException("Skill`s id do not match", "Id");
            var skill = DataBase.ProgrammerSkills.Get(skillDTO.ProgrammerId, skillId);
            if (skill == null)
                throw new ValidationException("Programmer does not have this skill", "Id");
            DataBase.ProgrammerSkills.Update(Mapper.Map<ProgrammerSkillDTO, ProgrammerSkill>(skillDTO));
            DataBase.Save();
        }
        //++++++++++
        public void DeleteSkillProgrammer(string idProgrammer, int idSkill)
        {
            var skill = DataBase.Skills.Get(idSkill);
            if (skill == null)
                throw new ValidationException("SKill is not found", "Id");
            var programmerSkill = DataBase.ProgrammerSkills.Get(idProgrammer, idSkill);
            if (programmerSkill == null)
                throw new ValidationException("Programer does not have this skill", "Id");
            DataBase.ProgrammerSkills.Delete(idProgrammer, idSkill);
            DataBase.Save();
        }
        //+++++++
        public void AddSkillToProgrammer(ProgrammerSkillDTO skillDTO)
        {
            if (skillDTO == null)
                throw new ValidationException("No information about programmer`s skills", "Id");
            var skill = DataBase.ProgrammerSkills.Get(skillDTO.ProgrammerId, skillDTO.SkillId);
            if (skill != null)
                throw new ValidationException("Skill of programmer with this Id already exists. Try some more", "Id");
            DataBase.ProgrammerSkills.Insert(Mapper.Map<ProgrammerSkillDTO, ProgrammerSkill>(skillDTO));
            DataBase.Save();
        }
        //+++
        public IEnumerable<SkillDTO> GetSkillProgrammerHavent(string id)
        {
            var programmer = DataBase.Programmers.Get(id);
            if (programmer == null)
                throw new ValidationException("Incorrect programmer id. Try some more", "Id");
            var programmerSkills = DataBase.ProgrammerSkills.GetAll().Where(y => y.ProgrammerId == id).Select(x => x.SkillId).ToList();
            if (programmerSkills.Count() == 0)
                return Mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDTO>>(DataBase.Skills.GetAll());
            var skills = DataBase.Skills.GetAll().ToList();
            var skillsIdProgrammerHavent = skills.Select(x => x.Id).Except(programmerSkills);
            var skillsProgramerHavent = skills.Where(x => skillsIdProgrammerHavent.Contains(x.Id));
            return Mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDTO>>(skillsProgramerHavent);
        }
        //+++++++
        public IEnumerable<ProgrammerSkillDTO> GetSkillOfProgrammer(string id)
        {
            var programmer = DataBase.Programmers.Get(id);
            if (programmer == null)
                throw new ValidationException("Incorrect programmer id. Try some more", "Id");
            var programmerSkill = DataBase.ProgrammerSkills.GetAll().Where(x => x.ProgrammerId == id);
            return Mapper.Map<IEnumerable<ProgrammerSkill>, IEnumerable<ProgrammerSkillDTO>>(programmerSkill);
        }
        //+++++
        public IEnumerable<SkillDTO> GetSkills()
        {
            var skills = DataBase.Skills.GetAll();
            return Mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDTO>>(skills);
        }
        //+++
        public void Delete(int id)
        {
            var skill = DataBase.Skills.Get(id);
            if (skill == null)
                throw new ValidationException("Incorrect skill id. Try some more", "Id");
            DataBase.Skills.Delete(skill.Id);
            DataBase.Save();
        }
        //++++++
        public void Update(int skillId, SkillDTO skillDTO)
        {
            if (skillDTO == null)
                throw new ValidationException("Information about this skill does not exist. Try some more", "Id");
            if (skillId != skillDTO.Id)
                throw new ValidationException("Skill`s id doesn`t match", "Id");
            var skill = DataBase.Skills.Get(skillDTO.Id);
            if (skill == null)
                throw new ValidationException("No information about this skill. Try some more", "Id");
            DataBase.Skills.Update(Mapper.Map<SkillDTO, Skill>(skillDTO));
            DataBase.Save();
        }
        //++++++++
        public void Insert(SkillDTO skillDTO)
        {
            if (skillDTO == null)
                throw new ValidationException("No information about this skill.Try some more", "Id");
            var skill = DataBase.Skills.GetAll().Where(x => x.Name == skillDTO.Name || x.Id == skillDTO.Id).FirstOrDefault();
            if (skill != null)
                throw new ValidationException("This skill already exists", "Name");
            DataBase.Skills.Insert(Mapper.Map<SkillDTO, Skill>(skillDTO));
            DataBase.Save();
        }
    }
}
