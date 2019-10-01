using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.DTO
{
    public class UpcomingMovieToReceiveDTO
    {
        public List<UpcomingMovieItemToReceiveDto> Results;
        public int Total_results;
        public int Total_pages;
        public int Page;
    }
}
