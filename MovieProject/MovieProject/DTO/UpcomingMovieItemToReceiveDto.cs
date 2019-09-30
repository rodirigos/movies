using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.DTO
{
    public class UpcomingMovieItemToReceiveDto
    {
        public string popularity { get; set; }
        public string vote_count { get; set; }
        public string video { get; set; }
        public string poster_path { get; set; }
        public string id { get; set; }
        public string adult { get; set; }
        public string backdrop_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string[] genre_ids { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public string overview { get; set; }
        public DateTime release_date { get; set; }
    }
}
