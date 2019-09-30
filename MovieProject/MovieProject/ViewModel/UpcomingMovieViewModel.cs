using AsyncAwaitBestPractices.MVVM;
using AutoMapper;
using MovieProject.Model;
using MovieProject.Services;
using MovieProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieProject.ViewModel
{
    public class UpcomingMovieViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        private readonly IMovieService _movieService;
        public UpcomingMovieViewModel(IPageService pageService, IMovieService movieService
           )
        {
            _pageService = pageService;
            _movieService = movieService;
            SearchMovieCommand = new Command(() => FilterMovies());
            OnApperingCommand = new AsyncCommand(async () => await GetUpcomingMovies());
            CallUpcomingMoviesCommand = new Command(async () => await GetUpcomingMovies());
            MovieSelectCommand = new Command(async () => await OpenDetailMovie());
        }

        #region Properties

        private ObservableCollection<UpcomingItemViewModel> upcomingMovieLst;
        public ObservableCollection<UpcomingItemViewModel> UpcomingMovieLst
        {
            get
            {
                return upcomingMovieLst;
            }
            set
            {
                SetValue(ref upcomingMovieLst, value, "UpcomingMovieLst");
            }
        }

        public UpcomingItemViewModel SelectedMovie { get; set; }

        public string TextWelcome { get; set; }

        public string SearchText { get; set; }


        #endregion

        #region Commands
        public ICommand OnApperingCommand { get; set; }
        public ICommand CallUpcomingMoviesCommand { get; set; }
        public ICommand SearchMovieCommand { get; set; }
        public ICommand MovieSelectCommand { get; set; }

        #endregion

        #region Function

        public async Task GetUpcomingMovies()
        {
            UpcomingMovieLst = new ObservableCollection<UpcomingItemViewModel>(await _movieService.GetUpcomingMovieAsync(1));
        }

        public void FilterMovies()
        {
            var moviesFiltered = upcomingMovieLst.Where(c => c.Title.Contains(SearchText));
            UpcomingMovieLst = new ObservableCollection<UpcomingItemViewModel>(moviesFiltered);
        }

        public async Task OpenDetailMovie()
        {
            await _pageService.PushAsync(new MovieDetailPage(SelectedMovie));
        }

        #endregion

    }
}
