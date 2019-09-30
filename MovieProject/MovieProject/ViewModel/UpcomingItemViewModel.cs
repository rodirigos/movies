using MovieProject.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.ViewModel
{
    public class UpcomingItemViewModel : BaseViewModel
    {

        private int id;
        private string title;
        private double vote_average;
        private DateTime release_date;
        private string poster_path;

        public int Id { 
            get
            {
                return id;
            }
            set
            {
                SetValue(ref id, value, "Id");
            }
        }
        public string Title
        {
            get 
            {
                return title;
            }
            set
            {
                SetValue(ref title, value, "Title");
            }
        }
        public double Vote_Average
        {
            get
            {
                return vote_average;
            }
            set
            {
                SetValue(ref vote_average, value, "VoteAverage");
            }
        }
        public DateTime Release_Date
        {
            get
            {
                return release_date;
            }
            set
            {
                SetValue(ref release_date, value, "ReleaseDate");
            }
        }

        public String ReleaseDateString
        {
            get { return Release_Date.ToString("dd/MM/yyyy"); }
        }

        public string Poster_Path
        {
            get
            {
                return HttpHelpers.PosterUrl +  poster_path;
            }
            set
            {
                SetValue(ref poster_path, value, "PosterPath");
            }
        }

    }
}
