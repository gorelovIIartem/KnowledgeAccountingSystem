using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entities;

namespace BLL
{
    public class AutomapperConfiguration:AutoMapper.Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<ProgrammerDTO, Programmer>().ReverseMap();
            CreateMap<ProjectDTO, Project>().ReverseMap();
            CreateMap<ProgrammerSkillDTO, ProgrammerSkill>().ReverseMap();
            CreateMap<SkillDTO, Skill>().ReverseMap();
            CreateMap<EducationDTO, Education>().ReverseMap();
            CreateMap<WorkExperienceDTO, WorkExperience>().ReverseMap();

        }
    }
}
