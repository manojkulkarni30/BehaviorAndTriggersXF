using MvvmHelpers;
using System.Threading.Tasks;
using System.Windows.Input;
using TBApp.ConvertersModels;
using Xamarin.Forms;

namespace TBApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ICommand _selectedItemCommand;
        public ICommand SelectedItemCommand => _selectedItemCommand ?? (_selectedItemCommand = new Command<ItemInfoModel>(async (args) => await NavigateToDetailPageAsync(args)));

        private async Task NavigateToDetailPageAsync(ItemInfoModel args)
        {
            var page = args.SelectedItem.ToString().Replace(" ", string.Empty) + "Page";
            switch (page)
            {
                case "PropertyTriggerPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new PropertyTriggerPage());
                    break;

                case "DataTriggerPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new DataTriggerPage());
                    break;

                case "EventTriggerPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new EventTriggerPage());
                    break;

                case "MultiTriggerPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new MultiTriggerPage());
                    break;

                case "BehaviorPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new BehaviorPage());
                    break;
            }
        }
    }
}
