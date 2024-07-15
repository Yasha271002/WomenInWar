using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using WomenInWar.Model;

namespace WomenInWar.ViewModel.Pages
{
    public class MainMenuViewModel : ObservableObject
    {
        public ObservableCollection<string> CardCharacterPath
        {
            get => GetOrCreate<ObservableCollection<string>>();
            set => SetAndNotify(value);
        }

        public MainMenuViewModel()
        {
            GetCardWomen();
            //const string contentPath = "Content/content.json";
            //if (!File.Exists(contentPath))
            //{
            //    var defaultValue = JsonConvert.SerializeObject(new List<AssetsModel> { new() });
            //    File.WriteAllText(contentPath, defaultValue);
            //}
            //Assets = JsonConvert.DeserializeObject<ObservableCollection<AssetsModel>>(File.ReadAllText(contentPath));
        }

        private void GetCardWomen()
        {
            var path = "WomenCard";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var cardPath = Directory.GetFiles(path);
            foreach (var card in cardPath)
            {
                CardCharacterPath.Add(card);
            }
        }

        public ObservableCollection<AssetsModel> Assets
        {
            get => GetOrCreate<ObservableCollection<AssetsModel>>();
            set => SetAndNotify(value);
        }
    }
}
