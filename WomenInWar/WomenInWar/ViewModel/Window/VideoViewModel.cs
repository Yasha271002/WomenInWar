using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using WomenInWar.Helpers;
using WomenInWar.Model;

namespace WomenInWar.ViewModel.Window
{
    public class VideoViewModel : ObservableObject
    {
        public VideoViewModel()
        {
            NavigationManager.Instance.MainFrameNavigated += OnMainFrameNavigated;
        }

        private void OnMainFrameNavigated(object sender, NavigationEventArgs e)
        { 
            CharacterModel = e.Parameter as CharacterModel;
        }

        public CharacterModel CharacterModel
        {
            get => GetOrCreate<CharacterModel>();
            set => SetAndNotify(value);
        }
    }
}
