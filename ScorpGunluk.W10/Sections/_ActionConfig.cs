using System;
using System.Windows.Input;
using AppStudio.DataProviders;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;

namespace ScorpGunluk.Sections
{
    public class ActionConfig<T> where T : SchemaBase
    {
        public string Text { get; set; }
        public string Style { get; set; }
        public ICommand Command { get; set; }
        public Func<T, object> CommandParameter { get; set; }

        public static ActionConfig<T> Link(string text, Func<T, string> param)
        {
            return new ActionConfig<T>
            {
                Text = text,
                Style = ActionKnownStyles.Link,
                Command = ActionCommands.NavigateToUrl,
                CommandParameter = param
            };
        }
    }
}