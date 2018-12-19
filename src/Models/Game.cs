using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BTN1.Models{
    
   public class Game
    {
        public Game(string _theme, string _nbImages, int _score)
        {
            Theme = _theme;
            NbImages = _nbImages;
            Score = _score;
        }

        public string Theme { get;  set; }
        public string NbImages { get;  set; }
        public int Score { get;  set; }
    }
}