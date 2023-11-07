using Dapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Infrastructure.Repositories;

namespace ePreschool.Infrastructure.Repositories
{
    public class CountriesRepository : BaseRepository<Country, int>, ICountriesRepository
    {
        public CountriesRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
       
    }
}
