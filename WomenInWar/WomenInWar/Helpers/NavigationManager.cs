using System;
using Core;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace WomenInWar.Helpers
{
    public enum PageTypes
    {
        MainMenuPage,
        InactivityPage,
        CharacterPage,
    }
    public class NavigationManager : ObservableObject
    {
        public static NavigationManager Instance { get; } = new();

        public event EventHandler<NavigationEventArgs> MainFrameNavigated;

        public Frame MainFrame
        {
            get => GetOrCreate<Frame>();
            set => SetAndNotify(value, callback: MainFrameChangedCallback);
        }

        private void MainFrameChangedCallback(PropertyChangingArgs<Frame> args)
        {
            if (args.OldValue is not null)
                args.OldValue.Navigated -= MainFrameOnNavigated;
            
            if (args.NewValue is not null)
                args.NewValue.Navigated += MainFrameOnNavigated;
        }

        private void MainFrameOnNavigated(object sender, NavigationEventArgs e)
        {
            MainFrameNavigated?.Invoke(sender, e);
        }
    }
}