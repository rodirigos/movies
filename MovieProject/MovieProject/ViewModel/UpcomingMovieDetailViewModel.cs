using MovieProject.Model;
using MovieProject.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.ViewModel
{
    public class UpcomingMovieDetailViewModel : BaseViewModel
    {
        public UpcomingMovieDetailViewModel()
        { }
           
        public int id { get; set; }
        public string backdrop_path { get; set; }

        public string backdrop_path_formatted { 
            get
            {
                return HttpHelpers.BackDropUrl + backdrop_path;
            } 
        }
        public List<Genre> genres { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public double vote_average { get; set; }
        public string runtime { get; set; }
        public DateTime release_date { get; set; }

        public string release_date_formatted
        {
            get
            {
                return release_date.ToString("dd/MM/yyyy");

            }
        }
        public double budget { get; set; }
        public double revenue { get; set; }
    
    }
}
