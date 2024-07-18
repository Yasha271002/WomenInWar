using System;
using System.Windows.Input;
using Microsoft.UI.Xaml.Controls;
using WomenInWar.Model;
using WomenInWar.View.Pages;
using WomenInWar.ViewModel.Pages;
using RelayCommand = WomenInWar.Utilities.RelayCommand;

namespace WomenInWar.Helpers
{
    public static class CommonCommands
    {
        private static Type? GetPageByType(PageTypes pageType)
        {
            return pageType switch
            {
               PageTypes.MainMenuPage => typeof(MainMenuPage),
               PageTypes.InactivityPage => typeof(InactivityPage),
            };
        }
        private static Type? GetPageByContent(object content)
        {
            var page = content switch
            {
                CharacterModel character => typeof(CharacterPage),
                _ => null
            };
            return page;
        }
        
        public static ICommand NavigateCommand { get; }= new RelayCommand(f =>
        {
            Type? page;
            if (f is PageTypes pageType)
            {
                page = GetPageByType(pageType);
                if (page is null) return;
                NavigationManager.Instance.MainFrame.Navigate(page);
            }
            else
            {
                page = GetPageByContent(f);
                if (page is null) return;
                NavigationManager.Instance.MainFrame.Navigate(page, f);
            }
        });

        public static ICommand GoBackCommand { get; } = new RelayCommand(f =>
        {
            NavigationManager.Instance.MainFrame.GoBack();
        });
    }
}
