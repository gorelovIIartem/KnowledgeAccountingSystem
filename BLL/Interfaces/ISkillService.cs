using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface ISkillService
    {
        IEnumerable<ProgrammerSkillDTO> GetSkillOfProgrammer(string id);
        IEnumerable<SkillDTO> GetSkillProgrammerHavent(string id);
        void AddSkillToProgrammer(ProgrammerSkillDTO skill);
        void UpdateSkillOfProgrammer(int skillId, ProgrammerSkillDTO skill);
        void DeleteSkillProgrammer(string idProgrammer, int skillId);
        IEnumerable<SkillDTO> GetSkills();
        void Insert(SkillDTO skil);
        void Delete(int skillId);
        void Update(int skillId, SkillDTO skill);
    }
}
