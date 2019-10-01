using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Util
{
    public static class HttpHelpers
    {
        public static string BaseApiUrl = "https://api.themoviedb.org/3/";
        public static string PosterUrl = " https://image.tmdb.org/t/p/w154";
        public static string BackDropUrl = "https://image.tmdb.org/t/p/w780";
        public static int TotalPages;
        public static Dictionary<string, string> MovieUpcomingQuery(int page)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("api_key", "2e508b40194129537006b7a38aadd526");
            dictionary.Add("page", page.ToString());
           
            return dictionary;
        }

        public static Dictionary<string, string> MovieDetailQuery()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("api_key", "2e508b40194129537006b7a38aadd526");

            return dictionary;
        }

    }
}
