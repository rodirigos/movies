using MovieProject.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingMoviesPage : ContentPage
    {
        
        public UpcomingMoviesPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<UpcomingMovieViewModel>();
        }
    }
}