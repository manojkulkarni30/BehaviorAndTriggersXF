using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TBApp.Behaviours
{
    public class AlphabetValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            var result = Regex.IsMatch(entry.Text, @"^[a-zA-Z ]+$"); ;
            entry.TextColor = result ? Color.Default : Color.Red;
        }
    }
}
