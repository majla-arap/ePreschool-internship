using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ePreschool.Infrastructure.Reporsitories;
using ePreschool.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ePreschool.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DatabaseContext _dbContext;
        public readonly IApplicationUsersRepository _usersRepository;
        public readonly ICitiesRepository _citiesRepository;
        public readonly ILogRepository _logRepository;
        public readonly ICountriesRepository _countiresRepository;
        public readonly IPreschoolsRepository _preschoolsRepository;
        public readonly IBusinessUnitRepository _businessUnitRepository;
        public readonly IApplicationUserRoleRepository _applicationUserRoleRepository;
        public readonly IBusinessUnitProgramRepository _businessUnitProgramRepository;
        public readonly IChildRepository _childRepository;
        public readonly IParentChildRepository _parentChildRepository;
        public readonly IParentRepository _parentRepository;
        public readonly IWorkingProgramRepository _programRepository;


        public UnitOfWork(DatabaseContext dbContext, IPreschoolsRepository preschoolsRepository,
            IApplicationUsersRepository userRepository, ICitiesRepository cityRepository, ILogRepository logRepository,
            ICountriesRepository countriesRepository, IApplicationUserRoleRepository applicationUserRoleRepository,
            IBusinessUnitRepository businessUnitRepository, IWorkingProgramRepository programRepository, IBusinessUnitProgramRepository businessUnitProgramRepository, IChildRepository childRepository,
            IParentChildRepository parentChildRepository, IParentRepository parentRepository)
        {
            _dbContext = dbContext;
            _usersRepository = userRepository;
            _citiesRepository = cityRepository;
            _logRepository = logRepository;
            _countiresRepository = countriesRepository;
            _preschoolsRepository = preschoolsRepository;
            _businessUnitRepository = businessUnitRepository;
            _applicationUserRoleRepository = applicationUserRoleRepository;
            _programRepository = programRepository;
            _businessUnitProgramRepository = businessUnitProgramRepository;
            _childRepository = childRepository;
            _parentChildRepository = parentChildRepository;
            _parentRepository = parentRepository;
        }

        public async Task<int> ExecuteAsync(Func<Task> action)
        {
            using (var transaction = BeginTransaction())
            {
                try
                {
                    await action();

                    var affectedRows = await SaveChangesAsync();
                    await transaction.CommitAsync();
                    return affectedRows;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public Task CommitTransactionAsync()
        {
            return _dbContext.Database.CommitTransactionAsync();
        }

        public Task RollbackTransactionAsync()
        {
            return _dbContext.Database.RollbackTransactionAsync();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
