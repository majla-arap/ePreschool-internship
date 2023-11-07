using ePreschool.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Service
{
    public interface IParentService : IBaseService<ParentDto>
    {
        Task<IEnumerable<ParentDto>> GetParentByEmail(string mail);
    }
}
