using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectDTO> GetProjectByProgrammerId(string id);
        void Insert(ProjectDTO project);
        void Update(int projectId, ProjectDTO project);
        void Delete(int projectId);
    }
}
