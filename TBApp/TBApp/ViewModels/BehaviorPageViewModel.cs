using MvvmHelpers;
using System.Windows.Input;
using TBApp.ConvertersModels;
using Xamarin.Forms;

namespace TBApp.ViewModels
{
    public class BehaviorPageViewModel : BaseViewModel
    {
        private ICommand _txtChangedCommand;
        public ICommand TextChangedCommand => _txtChangedCommand ?? (_txtChangedCommand = new Command<TextInfoModel>((args) => ExecuteTextChangeEvent(args)));

        private ICommand _sliderValueCommand;
        public ICommand SliderValueCommand => _sliderValueCommand ?? (_sliderValueCommand = new Command<ValueInfoModel>((args) => ExecuteSliderValueChangeEvent(args)));


        private string _sliderValue = "0";

        public string SliderValue
        {
            get => _sliderValue;
            set => SetProperty(ref _sliderValue, value);
        }


        private void ExecuteTextChangeEvent(TextInfoModel args)
        {
            var test = args.OldTextValue;
        }

        private void ExecuteSliderValueChangeEvent(ValueInfoModel args)
        {
            SliderValue = args.NewValue.ToString();
        }
    }
}
