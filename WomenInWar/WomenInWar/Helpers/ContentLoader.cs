﻿using System;
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
    public static class ContentLoader
    {
        private static List<CharacterModel> characters;

        public static void LoadCharacters()
        {
            characters = GetCharacterContent();
        }

        public static List<CharacterModel> GetCharacters()
        {
            return characters; 
        }

        public static List<CharacterModel> GetCharacterContent()
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

        private static CharacterModel GetCharacter(string directoryPath)
        {
            var jsonFilePath = GetFileByExtension(directoryPath, ".json");
            var characterJson = File.ReadAllText(jsonFilePath);
            var character = JsonConvert.DeserializeObject<CharacterModel>(characterJson);

            var imagePath = Path.Combine(directoryPath, "Фото");
            if (Directory.Exists(imagePath))
                character.ImagePaths = Directory.GetFiles(imagePath).ToList();

            character.CardPath = GetFileByExtension(directoryPath, ".png");
            character.VideoPath = GetFileByExtension(directoryPath, ".mp4");

            var relatedCharacterPath = Directory.GetDirectories(directoryPath).FirstOrDefault((d) => d != imagePath);
            if (relatedCharacterPath is not null)
                character.RelatedCharacterModel = GetCharacter(relatedCharacterPath);

            return character;
        }

        private static string GetFileByExtension(string directoryPath, string extension)
        {
            return Directory.GetFiles(directoryPath).FirstOrDefault(f => Path.GetExtension(f) == extension);
        }
    }
}
