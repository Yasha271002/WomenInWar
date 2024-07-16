using Core;
using Microsoft.UI.Xaml.Controls;

namespace WomenInWar.Helpers
{
    public enum PageTypes
    {
        MainMenuPage,
        CharacterPage,
    }
    public class NavigationManager : ObservableObject
    {
        public static NavigationManager Instance { get; } = new NavigationManager();

        public Frame MainFrame
        {
            get => GetOrCreate<Frame>();
            set => SetAndNotify(value);
        }
       
    }
}
