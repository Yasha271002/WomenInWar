using System.Windows.Input;
using Core;
using Microsoft.UI.Xaml.Controls;
using WomenInWar.View.Pages;
using WomenInWar.ViewModel.Pages;

namespace WomenInWar.Helpers
{
    public static class CommonCommands
    {
        private static Page? GetPageByType(PageTypes pageType)
        {
            return pageType switch
            {
               PageTypes.MainMenuPage => new MainMenuPage(),
               PageTypes.CharacterPage => new CharacterPage(),
            };
        }
        private static Page? GetPageByContent(object content)
        {
            var page = content switch
            {
                MainMenuViewModel mainMenuViewModel => new CharacterPage()
                {
                    DataContext = new CharacterViewModel(mainMenuViewModel)
                },
                _ => (Page?)null
            };
            return page;
        }
        
        public static ICommand NavigateCommand { get; } = new RelayCommand(f =>
        {
            Page? page;
            if (f is PageTypes pageType)
            {
                page = GetPageByType(pageType);
            }
            else
            {
                page = GetPageByContent(f);
            }
            if (page == null) return;
            NavigationManager.Instance.MainFrame.Navigate(page.GetType());

        });
    }
}
