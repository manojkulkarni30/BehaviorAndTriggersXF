using System;
using System.Globalization;
using TBApp.ConvertersModels;
using Xamarin.Forms;

namespace TBApp.Converters
{
    public class TextChangedEventArgsToTextInfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var eventArgs = value as TextChangedEventArgs;

            return new TextInfoModel
            {
                OldTextValue = eventArgs.OldTextValue,
                NewTextValue = eventArgs.NewTextValue
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var textInfoModel = (TextInfoModel)value;
            return new TextChangedEventArgs(textInfoModel.OldTextValue, textInfoModel.NewTextValue);
        }
    }
}
