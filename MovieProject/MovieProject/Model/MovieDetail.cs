using MovieProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Model
{
    public class MovieDetail 
    {
        public string backdrop_path { get; set; }
        public string genres { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string vote_average { get; set; }
        public string runtime { get; set; }
        public DateTime release_date { get; set; }
        public string budget { get; set; }
        public string revenue { get; set; }
    }
}
