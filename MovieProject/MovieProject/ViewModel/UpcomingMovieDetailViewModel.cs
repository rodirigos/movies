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
        public List<Genre> genres;

        public string genresToString
        {
            get
            {
                string str= "";
                foreach (var item in genres)
                {
                    str += item.Name + " ";
                }
                return str;
            }
        }
        public string title { get; set; }
        public string overview { get; set; }
        public double vote_average;
        public string vote_averageToString
        {
            get
            {
                return vote_average.ToString();
            }
        }
        public string runtime { get; set; }
        public DateTime release_date;

        public string release_date_formatted
        {
            get
            {
                return release_date.ToString("dd/MM/yyyy");

            }
        }
        public double budget { get; set; }
        public string budgetToString
        {
            get
            {
                return budget.ToString();
            }
        }
        public double revenue { get; set; }
    
    }
}
