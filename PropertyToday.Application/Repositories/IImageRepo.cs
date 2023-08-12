using PropertyToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyToday.Application.Repositories
{
    public interface IImageRepo
    {
        Task AddNewImageAsync(Image image);
        Task DeleteImageAsync(Image image);
        Task<List<Image>> GetImagesAsync();
        Task UpdateImageAsync(Image image);
        Task<Image> GetImageByIdAsync(int id);
    }
}
