using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IProgrammerService
    {
        ProgrammerDTO Get(string id);

        void Update(string userId, ProgrammerDTO programmer);
        IEnumerable<ProgrammerDTO> GetProgrammersBySkill(int? idSkill, int knowledgeLevel);
        byte[] GenerateReport(List<ProgrammerDTO> programmers);
    }
}
