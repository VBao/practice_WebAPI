using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Api.Repository
{
    public class SettingRepository : ISettingRepository
    {
        private readonly CustomerManagementContext myDbContext;
        public SettingRepository(CustomerManagementContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        public async Task<Setting> AddSetting(Setting setting)
        {
            var result = await myDbContext.Settings.AddAsync(setting);
            await myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Setting> DeleteSetting(string attributeID)
        {
            var result = await myDbContext.Settings.FirstOrDefaultAsync(x => x.AttributeId == attributeID);
            if (result != null)
            {
                myDbContext.Settings.Remove(result);
                await myDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Setting>> GetSettings()
        {
            return await myDbContext.Settings.ToListAsync();
        }

        public async Task<Setting> GetSetting(string attributeID)
        {
            return await myDbContext.Settings.FirstOrDefaultAsync(x => x.AttributeId == attributeID);
        }

        public async Task<IEnumerable<Setting>> Search(string attributeID)
        {
            IQueryable<Setting> query = myDbContext.Settings;
            if (!string.IsNullOrEmpty(attributeID))
            {
                query = query.Where(x => x.AttributeId.Contains(attributeID));
            }
            return await query.ToListAsync();
        }

        public async Task<Setting> UpdateSetting(Setting setting)
        {
            var result = await myDbContext.Settings.FirstOrDefaultAsync(x => x.AttributeId == setting.AttributeId);
            if (result != null)
            {
                result.AttributeId = setting.AttributeId;
                result.AttributeName = setting.AttributeName;
                result.Description = setting.Description;
                result.IsDistributorAttribute = setting.IsDistributorAttribute;
                result.IsCustomerAttribute = setting.IsCustomerAttribute;
                result.Used = setting.Used;

                await myDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
