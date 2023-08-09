using PropertyToday.Domain;

namespace PropertyToday.Application.Repositories
{
    public interface IPropertyRepo
    {
        Task AddNewPropertyAsync(Property property);
        Task DeletePropertyAsync(Property property);
        Task<List<Property>> GetAllPropertiesAsync(); 
        Task UpdatePropertyAsync(Property property);
        Task<Property> GetPropertyAsync(int propertyId);

    }
}
