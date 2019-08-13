using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IEducationService
    {
        IEnumerable<EducationDTO> GetEducationByProgrammerId(string id);
        void Insert(EducationDTO education);
        void Update(int educationId, EducationDTO education);
        void Delete(int educationId);
       
    }
}
