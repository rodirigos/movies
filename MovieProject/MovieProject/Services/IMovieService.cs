using MovieProject.Util;
using MovieProject.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieProject.Services
{
   public interface IMovieService
    {
        Task<PagedList<UpcomingItemViewModel>> GetUpcomingMovieAsync(int page);
        Task<UpcomingMovieDetailViewModel> GetMovieDetailAsync(int id);        
    }
}
