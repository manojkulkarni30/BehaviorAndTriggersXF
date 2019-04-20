using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TBApp.TriggerActions
{
    public class AlphabetValidationTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            var result = Regex.IsMatch(sender.Text, @"^[a-zA-Z ]+$"); ;
            sender.TextColor = result ? Color.Default : Color.Red;
        }
    }
}
