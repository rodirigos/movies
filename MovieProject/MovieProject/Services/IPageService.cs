using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieProject.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PushModalAsync(Page page);
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task PushDetailAsync(Page page);
        Task PopDetailAsync();
        Task PopModalAsync();
    }
}
