using Dapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Infrastructure.Repositories;

namespace ePreschool.Infrastructure.Repositories
{
    public class PreschoolsRepository : BaseRepository<Preschool, int>, IPreschoolsRepository
    {
        public PreschoolsRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }     
    }
}
