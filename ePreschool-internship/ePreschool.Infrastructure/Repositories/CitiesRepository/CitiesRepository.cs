using Dapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Infrastructure.Repositories;

namespace ePreschool.Infrastructure.Repositories
{
    public class CitiesRepository : BaseRepository<City, int>, ICitiesRepository
    {
        public CitiesRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<dynamic>> GetByParametersAsync(string pName, int pCountryId)
        {
            var query = "SELECT * FROM fn_cities_getbyparameters(@pName,@pCountryId);";

           return await DbConnection.QueryAsync(query,
                         new DynamicParameters(new { pName = pName, pCountryId = pCountryId}));
        }    
    }
}
