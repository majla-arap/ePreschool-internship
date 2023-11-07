using ePreschool.Core;

using Microsoft.EntityFrameworkCore;

namespace ePreschool.Infrastructure
{
    public partial class DatabaseContext
    {

        private void ModifyTimestamps()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                var entity = (IBaseEntity)entry.Entity;
                if (entry.State == EntityState.Modified)
                    entity.ModifiedAt = DateTime.Now;
                else if (entry.State == EntityState.Added)
                    entity.CreatedAt = DateTime.Now;
            }
        }

        public override int SaveChanges()
        {
            ModifyTimestamps();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ModifyTimestamps();

            return base.SaveChangesAsync(cancellationToken);
        }
       
    }
}
