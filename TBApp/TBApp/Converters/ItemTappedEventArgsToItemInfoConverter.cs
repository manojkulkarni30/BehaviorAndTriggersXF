using System;
using System.Globalization;
using TBApp.ConvertersModels;
using Xamarin.Forms;

namespace TBApp.Converters
{
    public class ItemTappedEventArgsToItemInfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var itemTappedEventArgs = (ItemTappedEventArgs)value;

            return new ItemInfoModel
            {
                SelectedItem = itemTappedEventArgs.Item
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
