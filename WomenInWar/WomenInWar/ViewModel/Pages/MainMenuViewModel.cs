using System.Collections.ObjectModel;
using Core;
using WomenInWar.Helpers;
using WomenInWar.Model;

namespace WomenInWar.ViewModel.Pages
{
    public class MainMenuViewModel : ObservableObject
    {
        public ObservableCollection<CharacterModel> Assets
        {
            get => GetOrCreate<ObservableCollection<CharacterModel>>();
            set => SetAndNotify(value);
        }

        public MainMenuViewModel()
        {
            var characters = ContentLoader.GetCharacters();
            Assets = new(characters);
        }
    }
}
