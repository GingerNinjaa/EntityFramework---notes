using System.Collections.Generic;

namespace EntityFramework.Database
{
    public interface ISettingsRepository
   {
       List<Setting> GetAll();
       void UpdateSetting(Setting setting);
       void SaveChanges();
   }
}
