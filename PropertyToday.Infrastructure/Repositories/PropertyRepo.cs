using Microsoft.EntityFrameworkCore;
using PropertyToday.Application.Repositories;
using PropertyToday.Domain;
using PropertyToday.Infrastructure.Context;

namespace PropertyToday.Infrastructure.Repositories
{
    public class PropertyRepo : IPropertyRepo
    {
        private PropertyTodayDbContext _Context;
        public PropertyRepo(PropertyTodayDbContext context)
        {
            _Context = context;
        }
        public async Task AddNewPropertyAsync(Property property)
        {
           await  _Context.Properties.AddAsync(property);
           await _Context.SaveChangesAsync();

        }

        public async Task DeletePropertyAsync(Property property)
        {
              _Context.Remove(property);
            await _Context.SaveChangesAsync();
        }

        public async Task<List<Property>> GetAllPropertiesAsync() 
        {
           List<Property> properties = await _Context.Properties.ToListAsync();
            return properties;
        }

        public async Task<Property> GetPropertyAsync(int propertyId)
        {
            Property property = await _Context.Properties.Where(x => x.Id == propertyId).FirstOrDefaultAsync();
            return property;
        }

        public async Task UpdatePropertyAsync(Property property)
        {
             _Context.Properties.Update(property);
            await _Context.SaveChangesAsync();
        }
    }
}
