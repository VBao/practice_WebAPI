using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Api.Repository
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly CustomerManagementContext myDbContext;
        public AttributeRepository(CustomerManagementContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public async Task<Attribute> AddAttribute(Attribute attribute)
        {
            var result = await myDbContext.Attributes.AddAsync(attribute);
            await myDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Attribute> DeleteAttribut(string code)
        {
            var result = await myDbContext.Attributes
                .FirstOrDefaultAsync(x => x.Code == code);
            if (result != null)
            {
                myDbContext.Attributes.Remove(result);
                await myDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Attribute> GetAttribute(string code)
        {
            return await myDbContext.Attributes.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<IEnumerable<Attribute>> GetAttributes()
        {
            return await myDbContext.Attributes.ToListAsync();
        }

        // search by "code"
        public async Task<IEnumerable<Attribute>> Search(string code)
        {
            IQueryable<Attribute> query = myDbContext.Attributes;

            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(x => x.Code.Contains(code));
            }
            return await query.ToListAsync();
        }

        public async Task<Attribute> UpdateAttribute(Attribute attribute)
        {
            var result = await myDbContext.Attributes
                .FirstOrDefaultAsync(x => x.Code == attribute.Code);

            if (result != null)
            {
                result.Code = attribute.Code;
                result.Description = attribute.Description;
                result.ShortName = attribute.ShortName;
                result.EffectiveDate = attribute.EffectiveDate;
                result.ValidUntil = attribute.ValidUntil;

                await myDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
