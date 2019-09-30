using MovieProject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieProject.Services
{
   public interface IMovieService
    {
        Task<List<UpcomingItemViewModel>> GetUpcomingMovieAsync(int page);
        Task<UpcomingMovieDetailViewModel> GetMovieDetailAsync(int id);        
    }
}
