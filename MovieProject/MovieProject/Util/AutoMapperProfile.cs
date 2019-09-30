using AutoMapper;
using MovieProject.DTO;
using MovieProject.Model;
using MovieProject.ViewModel;

namespace MovieProject.Util
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UpcomingMovieItemToReceiveDto, UpcomingMovie>();
            CreateMap<UpcomingItemViewModel,UpcomingMovie>();
            CreateMap<UpcomingMovieItemToReceiveDto, UpcomingItemViewModel>();
        }
    }
}
