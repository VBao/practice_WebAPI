using CustomerManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Api.Repository
{
    public interface ISettingRepository
    {
        Task<IEnumerable<Setting>> GetSettings();
        Task<Setting> GetSetting(string attributeID);
        Task<Setting> AddSetting(Setting setting);
        Task<Setting> UpdateSetting(Setting setting);
        Task<Setting> DeleteSetting(string attributeID);
        Task<IEnumerable<Setting>> Search(string attributeID);
    }
}
