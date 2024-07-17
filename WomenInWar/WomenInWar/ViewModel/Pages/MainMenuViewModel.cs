using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Core;
using Microsoft.UI.Xaml;
using WomenInWar.Helpers;
using WomenInWar.Model;

namespace WomenInWar.ViewModel.Pages
{
    public class MainMenuViewModel : ObservableObject
    {
        //public ObservableCollection<string> CardCharacterPath
        //{
        //    get => GetOrCreate<ObservableCollection<string>>();
        //    set => SetAndNotify(value);
        //}

        public ObservableCollection<CharacterModel> Assets
        {
            get => GetOrCreate<ObservableCollection<CharacterModel>>();
            set => SetAndNotify(value);
        }

        public MainMenuViewModel()
        {
            Assets = new();
            //CardCharacterPath = new();
            LoadCharacterContent();
            //GetCardWomen();
            //const string contentPath = "Content/content.json";
            //if (!File.Exists(contentPath))
            //{
            //    var defaultValue = JsonConvert.SerializeObject(new List<CharacterModel> { new() });
            //    File.WriteAllText(contentPath, defaultValue);
            //}
            //Assets = JsonConvert.DeserializeObject<ObservableCollection<CharacterModel>>(File.ReadAllText(contentPath));
        }

        //private void GetCardWomen()
        //{
        //    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WomenCard");
        //    if (!Directory.Exists(Path.GetFullPath(path)))
        //        Directory.CreateDirectory(Path.GetFullPath(path));

        //    var cardPaths = Directory.GetFiles(Path.GetFullPath(path));
        //    foreach (var cardPath in cardPaths)
        //        CardCharacterPath.Add(cardPath);
        //}

       

        private void LoadCharacterContent()
        {
            var contentLoader = new ContentLoader();
            var characters = contentLoader.GetCharacterContent();

            foreach (var character in characters)
            {
                Assets.Add(character);
                //CardCharacterPath.Add(character.CardPath);
            }
        }
    }
}
