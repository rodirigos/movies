using MovieProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieProject.Services
{
    public class PageService : IPageService
    {
        public async Task<bool> DisplayAlert(string title, string Message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, Message, ok, cancel);
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushModalAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public async Task PushDetailAsync(Page page)
        {
            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(page);
            // App.masterPage.IsPresented = false;
        }

        public async Task PopDetailAsync()
        {
            await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
        }

        public async Task PopModalAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
