using System.Windows.Input;
using Core;
using Microsoft.UI.Xaml.Controls;
using WomenInWar.View.Pages;

namespace WomenInWar.Helpers
{
    public static class CommonCommands
    {
        private static Page? GetPageByType(PageTypes pageType)
        {
            return pageType switch
            {
               PageTypes.MainMenuPage => new MainMenuPage(),
            };
        }
        private static Page? GetPageByContent(object content)
        {
            var page = content switch
            {
                
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
