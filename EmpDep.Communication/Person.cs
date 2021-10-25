using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDep.Communication.EmpDepService
{
    public partial class Person : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
