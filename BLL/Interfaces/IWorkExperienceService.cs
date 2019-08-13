using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IWorkExperienceService
    {
        IEnumerable<WorkExperienceDTO> GetWorkExperienceOfProgrammer(string id);
        void Insert(WorkExperienceDTO workExperience);
        void Update(int workExperienceId, WorkExperienceDTO workExperience);
        void Delete(int workExperienceId);
    }
}
