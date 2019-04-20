using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace TBApp.Behaviours
{
    public class EventToCommandBehavior : BindableBase<View>
    {
        #region Fields

        private Delegate eventHandler;

        #endregion

        #region Bindable Properties

        public static readonly BindableProperty EventNameProperty = BindableProperty.Create(nameof(EventName), typeof(string), typeof(EventToCommandBehavior), null, propertyChanged: OnEventNameChanged);
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior), null);
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(EventToCommandBehavior), null);
        public static readonly BindableProperty InputConverterProperty = BindableProperty.Create(nameof(InputConverter), typeof(IValueConverter), typeof(EventToCommandBehavior), null);


        public string EventName
        {
            get => (string)GetValue(EventNameProperty);

            set => SetValue(EventNameProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);

            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);

            set => SetValue(CommandParameterProperty, value);
        }

        public IValueConverter InputConverter
        {
            get => (IValueConverter)GetValue(InputConverterProperty);

            set => SetValue(InputConverterProperty, value);
        }

        #endregion

        #region Event Name Change Method

        private static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (EventToCommandBehavior)bindable;
            if (behavior.AssociatedObject == null)
            {
                return;
            }

            behavior.DeRegisterEvent((string)oldValue);
            behavior.RegisterEvent((string)newValue);
        }

        #endregion

        #region Utility Methods

        private EventInfo GetEventInfo(string eventName)
        {
            var eventInfo = AssociatedObject.GetType().GetRuntimeEvent(eventName);
            if (eventInfo == null)
            {
                throw new ArgumentException($"{nameof(EventToCommandBehavior)}: can`t register/deregister the event {EventName}");
            }

            return eventInfo;
        }

        private void RegisterEvent(string eventName)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                return;
            }

            EventInfo eventInfo = GetEventInfo(eventName);

            var methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod(nameof(OnEvent));
            eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(AssociatedObject, eventHandler);
        }

        private void DeRegisterEvent(string eventName)
        {
            if (string.IsNullOrEmpty(eventName) || eventHandler == null)
            {
                return;
            }

            var eventInfo = GetEventInfo(eventName);
            eventInfo.RemoveEventHandler(AssociatedObject, eventHandler);
            eventHandler = null;
        }

        private void OnEvent(object sender, object eventArgs)
        {
            if (Command == null)
            {
                return;
            }

            object parameters = CommandParameter ?? eventArgs;

            if (InputConverter != null)
                parameters = InputConverter.Convert(parameters, typeof(object), null, null);

            if (Command.CanExecute(parameters))
            {
                Command.Execute(parameters);
            }
        }

        #endregion

        #region Behavior Methods

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
            RegisterEvent(EventName);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            DeRegisterEvent(EventName);
            base.OnDetachingFrom(bindable);
        }

        #endregion

    }
}
