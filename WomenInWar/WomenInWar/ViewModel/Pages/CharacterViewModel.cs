using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using WomenInWar.Model;

namespace WomenInWar.ViewModel.Pages
{
    public class CharacterViewModel : ObservableObject
    {
        public CharacterModel CharacterModel
        {
            get => GetOrCreate<CharacterModel>();
            set => SetAndNotify(value);
        }
        public CharacterViewModel(CharacterModel character)
        {
            CharacterModel = character;
        }

        public CharacterViewModel() { }
    }
}
