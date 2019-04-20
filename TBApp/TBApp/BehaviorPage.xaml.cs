using TBApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BehaviorPage : ContentPage
    {
        public BehaviorPage()
        {
            InitializeComponent();
            BindingContext = new BehaviorPageViewModel();
        }

    }
}