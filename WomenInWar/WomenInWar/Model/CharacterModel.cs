using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WomenInWar.Model
{
    public class CharacterModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public List<string> ImagePaths { get; set; }
        public string CardPath { get; set; }
        public string VideoPath { get; set; }
    }
}
