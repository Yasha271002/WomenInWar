using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WomenInWar.Model;

namespace WomenInWar.Helpers
{
    public class ContentLoader
    {
        public List<CharacterModel> GetCharacterContent()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WomenCard");
            var directories = Directory.GetDirectories(path);
            var characterModels = new List<CharacterModel>();
            foreach (var directory in directories)
            {
                var character = GetCharacter(directory);
                if (character != null)
                    characterModels.Add(character);
            }

            return characterModels;
        }

        private CharacterModel GetCharacter(string directoryPath)
        {

            var jsonFilePath = GetFileByExtension(directoryPath, ".json");
            var characterJson = File.ReadAllText(jsonFilePath);
            var character = JsonConvert.DeserializeObject<CharacterModel>(characterJson);

            var imagePath = Path.Combine(directoryPath, "Фото");
            if (Directory.Exists(imagePath))
                character.ImagePaths = Directory.GetFiles(imagePath).ToList();

            character.CardPath = GetFileByExtension(directoryPath, ".png");
            character.VideoPath = GetFileByExtension(directoryPath, ".mp4");
            return character;
        }

        private string GetFileByExtension(string directoryPath, string extension)
        {
            return Directory.GetFiles(directoryPath).FirstOrDefault(f => Path.GetExtension(f) == extension);
        }
    }
}
