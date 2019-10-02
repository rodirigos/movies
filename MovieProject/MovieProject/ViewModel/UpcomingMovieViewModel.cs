using AsyncAwaitBestPractices.MVVM;
using MovieProject.Services;
using MovieProject.Util;
using MovieProject.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            OnApperingCommand = new AsyncCommand(async () => await GetUpcomingMovies());
            CallUpcomingMoviesCommand = new Command(async () => await GetUpcomingMovies());
            MovieSelectCommand = new Command<UpcomingItemViewModel>(async (model) => await OpenDetailMovie(model));
            SelectNextCommand = new Command(async () => await SelectNext());
            SelectPreviousCommand = new Command(async () => await SelectPrevious());
            activePage = 1;
            Loading = true;
        }

        #region Properties

        private ObservableCollection<UpcomingItemViewModel> upcomingMovieLst;
        public ObservableCollection<UpcomingItemViewModel> UpcomingMovieLst
        {
            get
            {
                if (Filtered)
                {
                    return new ObservableCollection<UpcomingItemViewModel>(upcomingMovieLst.Where(c => c.Title.ToLower().Contains(SearchText.ToLower())));
                }

                return upcomingMovieLst;
            }
            set
            {
                SetValue(ref upcomingMovieLst, value, "UpcomingMovieLst");
            }
        }

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

        public EventArgs SelectedItemArgs { get; set; }

        public UpcomingItemViewModel SelectedMovie { get; set; }

        public string TextWelcome { get; set; }

        public string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                SetValue(ref searchText, value, "Filtered");
                Filtered = string.IsNullOrEmpty(SearchText) ? false : true;
            }
        }

        private bool loading;
        public bool Loading
        {
            get
            {
                return loading;
            }
            set
            {
                SetValue(ref loading, value, "Loading");
                OnPropertyChanged("ListViewVisibility");
            }
        }

        public bool ListViewVisibility
        {
            get
            {
                return !loading;
            }
        }

        private bool filtered;
        public bool Filtered
        {
            get
            {
                return filtered;
            }
            set
            {
                SetValue(ref filtered, value, "Filtered");
                OnPropertyChanged("UpcomingMovieLst");
            }
        }

        #endregion

        #region Commands
        public ICommand OnApperingCommand { get; set; }
        public ICommand CallUpcomingMoviesCommand { get; set; }
        public ICommand SearchMovieCommand { get; set; }
        public ICommand MovieSelectCommand { get; set; }
        public ICommand SelectPreviousCommand { get; set; }
        public ICommand SelectNextCommand { get; set; }


        #endregion

        #region Function
        public async Task GetUpcomingMovies()
        {
            Loading = true;
            UpcomingMovieLst = new ObservableCollection<UpcomingItemViewModel>(await _movieService.GetUpcomingMovieAsync(activePage));
            Loading = false;
        }

    

        public async Task OpenDetailMovie(UpcomingItemViewModel selected)
        {
            UpcomingMovieDetailViewModel viewmodel = await _movieService.GetMovieDetailAsync(selected.Id);
            await _pageService.PushAsync(new MovieDetailPage(viewmodel));
        }

        public async Task SelectNext()
        {
            activePage++;
            if (activePage < HttpHelpers.TotalPages)
            {
                await GetUpcomingMovies();
            } else
            {
                activePage--;
            }
        }

        public async Task SelectPrevious()
        {
            activePage--;
            if (activePage > 0)
            {
                await GetUpcomingMovies();
            } else
            {
                activePage++;
            }
        }

        #endregion

    }
}
