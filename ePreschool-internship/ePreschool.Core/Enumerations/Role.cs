using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Enumerations
{
    public enum Role
    {
        SuperAdministrator = 1,
        Ministry, //predstavnici ministarstva
        PreschoolAdministrator, //administrator vrtića
        PreschoolManagement, //menadzment vrtića
        BusinessUnitAdministrator,//admin organizacione jedinice vrtića
        BusinessUnitEmployee,//uposlenici vrtića
        Parent,
        Expert//logoped, pedagog
    }
}
