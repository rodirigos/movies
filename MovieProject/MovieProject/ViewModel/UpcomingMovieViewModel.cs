using AsyncAwaitBestPractices.MVVM;
using AutoMapper;
using MovieProject.Model;
using MovieProject.Services;
using MovieProject.Util;
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
            MovieSelectCommand = new Command<UpcomingItemViewModel>(async (model) => await OpenDetailMovie(model));
            activePage = 1;
        }

        #region Properties
        private PagedList<UpcomingItemViewModel> PagedList;

        private ObservableCollection<UpcomingItemViewModel> upcomingMovieLst;
        public ObservableCollection<UpcomingItemViewModel> UpcomingMovieLst
        {
            get
            {
                return new ObservableCollection<UpcomingItemViewModel>(PagedList);
            }
            set
            {
                SetValue(ref upcomingMovieLst, value, "UpcomingMovieLst");
            }
        }

        public string TextWelcome { get; set; }

        public string SearchText { get; set; }

        private int activePage;
        public int ActivePage
        {
            get
            {
                return activePage;
            }
            set
            {
                SetValue(ref activePage, value, "ActivePage");
            }
        }


        #endregion

        #region Commands
        public ICommand OnApperingCommand { get; set; }
        public ICommand CallUpcomingMoviesCommand { get; set; }
        public ICommand SearchMovieCommand { get; set; }
        public ICommand MovieSelectCommand { get; set; }
        public ICommand SelectNextCommand { get; set; }
        public ICommand SelectPreviousCommand { get; set; }

        #endregion

        #region Function

        public async Task GetUpcomingMovies()
        {
            PagedList = await _movieService.GetUpcomingMovieAsync(activePage);
           // UpcomingMovieLst = new ObservableCollection<UpcomingItemViewModel>(PagedList);
        }

        public void FilterMovies()
        {
            var moviesFiltered = upcomingMovieLst.Where(c => c.Title.ToLower().Contains(SearchText.ToLower()));
            UpcomingMovieLst = new ObservableCollection<UpcomingItemViewModel>(moviesFiltered);

        }

        public async Task OpenDetailMovie(UpcomingItemViewModel selected)
        {
            UpcomingMovieDetailViewModel viewmodel = await _movieService.GetMovieDetailAsync(selected.Id);
            await _pageService.PushAsync(new MovieDetailPage(viewmodel));
        }

        public async Task SelectNext()
        {
            if (PagedList.TotalPages >= ActivePage)
            {
                ActivePage++;
                await GetUpcomingMovies();
            }
        }

        public async Task SelectPrevious()
        {
            if (ActivePage > 0)
            {
                ActivePage--;
                await GetUpcomingMovies();
            }
        }

        #endregion

    }
}
