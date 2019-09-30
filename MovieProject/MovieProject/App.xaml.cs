using MovieProject.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieProject
{
    public partial class App : Application
    {
        public static NavigationPage navigationPage;
        public App()
        {
            InitializeComponent();
            Startup.Init();
            navigationPage = new NavigationPage();
            navigationPage.Navigation.PushAsync(new UpcomingMoviesPage());
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
