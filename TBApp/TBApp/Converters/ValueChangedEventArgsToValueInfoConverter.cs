using System;
using System.Globalization;
using TBApp.ConvertersModels;
using Xamarin.Forms;

namespace TBApp.Converters
{
    public class ValueChangedEventArgsToValueInfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var valueChangedArgs = (ValueChangedEventArgs)value;

            return new ValueInfoModel
            {
                NewValue = valueChangedArgs.NewValue,
                OldValue = valueChangedArgs.OldValue
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var valueInfoModel = (ValueInfoModel)value;
            return new ValueChangedEventArgs(valueInfoModel.OldValue, valueInfoModel.NewValue);
        }
    }
}
