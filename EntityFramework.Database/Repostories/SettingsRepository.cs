using System.Collections.Generic;
using System.Linq;
using EntityFramework.Database.Repostories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFramework.Database
{
    public class SettingsRepository : BaseRepository<Setting>, ISettingsRepository
    {
        protected override DbSet<Setting> DbSet => _dbContext.Settings;

        public SettingsRepository(EntityFrameworkDbContext dbContext) : base(dbContext) { }

        public void UpdateSetting(Setting setting)
        {
            var foundSetting = DbSet.Where(x => x.Name == setting.Name).FirstOrDefault();
            if (foundSetting == null)
            {
                DbSet.Add(setting);
                SaveChanges();
                return;
            }

            foundSetting.Name = setting.Name;
            foundSetting.Value = setting.Value;
            SaveChanges();
            return;
            
        }

  
    }
}
