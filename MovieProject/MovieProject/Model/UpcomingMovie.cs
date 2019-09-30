using MovieProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Model
{
    public class UpcomingMovie
    {
        
        public string title { get; set; }
        public double vote_average { get; set; }
        public DateTime release_date { get; set; }
        public string poster_path { get; set; }
    }
}
