using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.DTO
{
    public class UpcomingMovieDetailDTO
    {
        public string backdrop_path { get; set; }
        public string genres { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public double vote_average { get; set; }
        public string runtime { get; set; }
        public DateTime release_date { get; set; }
        public double budget { get; set; }
        public double revenue { get; set; }
    }
}
