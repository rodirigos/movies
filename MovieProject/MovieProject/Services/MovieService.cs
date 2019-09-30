using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MovieProject.DTO;
using MovieProject.Model;
using MovieProject.Util;
using MovieProject.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Services
{
    public class MovieService : IMovieService
    {
        private readonly ILogger<MovieService> _logger;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public MovieService(ILogger<MovieService> logger, 
            IHttpClientFactory httpClientFactory,
            IMapper mapper)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri(HttpHelpers.BaseApiUrl);
            _mapper = mapper;
        }

        public async Task<UpcomingMovieDetailViewModel> GetMovieDetailAsync(int id)
        {
            //https://api.themoviedb.org/3/movie/{movie_id}?api_key=<<api_key>>&language=en-US
            string url = QueryHelpers.AddQueryString($"movie/{id}", HttpHelpers.MovieDetailQuery());
            var responseString = await _client.GetStringAsync(url);
            var movie = JsonConvert.DeserializeObject<UpcomingMovieDetailViewModel>(responseString);
            return movie;
        }

        public async Task<List<UpcomingItemViewModel>> GetUpcomingMovieAsync(int page)
        {
            string url = QueryHelpers.AddQueryString("movie/upcoming", HttpHelpers.MovieUpcomingQuery(page));
            var responseString = await _client.GetStringAsync(url);
            var list = JsonConvert.DeserializeObject<UpcomingMovieToReceiveDTO>(responseString);
            List<UpcomingItemViewModel> converterdList = _mapper.Map<List<UpcomingItemViewModel>>(list.Results);
            return converterdList;
        }


    }
}
