using ePreschool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public interface IParentChildRepository : IBaseRepository<ParentChild, int>
    {
        Task<IEnumerable<dynamic>> AddChildParent(string mail, string cguid);
    }
}
