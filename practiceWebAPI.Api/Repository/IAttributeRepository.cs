using CustomerManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Api.Repository
{
    public interface IAttributeRepository
    {
        Task<IEnumerable<Attribute>> GetAttributes();
        Task<Attribute> GetAttribute(string code);
        // Task<Attribute> GetEmployeeByEmail(string email);
        Task<Attribute> AddAttribute(Attribute attribute);
        Task<Attribute> UpdateAttribute(Attribute attribute);
        Task<Attribute> DeleteAttribut(string code);
        Task<IEnumerable<Attribute>> Search(string code);
    }
}
