using TBApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}