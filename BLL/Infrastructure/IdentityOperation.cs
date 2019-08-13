using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class IdentityOperation
    {
        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
        public IdentityOperation(bool succeeded,string message, string prop )
        {
            Succeeded = succeeded;
            Message = message;
            Property = prop;
        }
    }
}
