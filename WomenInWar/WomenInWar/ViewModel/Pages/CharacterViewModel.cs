using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace WomenInWar.ViewModel.Pages
{
    public class CharacterViewModel : ObservableObject
    {
        public ObservableCollection<MainMenuViewModel> MainCharacterModel
        {
            get => GetOrCreate<ObservableCollection<MainMenuViewModel>>();
            set => SetAndNotify(value);
        }
        public CharacterViewModel(MainMenuViewModel mwViewModel)
        {
        }
    }
}
