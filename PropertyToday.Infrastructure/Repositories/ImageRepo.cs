using Microsoft.EntityFrameworkCore;
using PropertyToday.Application.Repositories;
using PropertyToday.Domain;
using PropertyToday.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyToday.Infrastructure.Repositories
{
    public class ImageRepo : IImageRepo
    {
        private PropertyTodayDbContext _Context;

        public ImageRepo(PropertyTodayDbContext context)
        {
            _Context = context;
        }

        public async Task AddNewImageAsync(Image image)
        {
            await _Context.Images.AddAsync(image);
            await _Context.SaveChangesAsync();
        }

        public async Task DeleteImageAsync(Image image)
        {
            _Context.Images.Remove(image);
            await _Context.SaveChangesAsync();
        }

        public async Task<Image> GetImageByIdAsync(int id)
        {
            return await _Context.Images.Where(x => x.Id == id)
                                        .Include(x => x.Property)
                                        .FirstOrDefaultAsync();
        }

        public async Task<List<Image>> GetImagesAsync()
        {
            return await _Context.Images.Include(x => x.Property).ToListAsync();
        }

        public async Task UpdateImageAsync(Image image)
        {
            _Context.Images.Update(image);
            await _Context.SaveChangesAsync();
        }
    }
}
