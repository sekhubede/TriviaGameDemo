using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace ConsoleUI
{
    internal class Game
    {
        private string GameTitle = "Trivia Quest";
        private string GameTitleArt = @"Trivia Quest";
        private string GameDescription = @"Welcome to Trivia Quest
Battle your friends for the top score in silly trivia.";

        public void Start()
        {
            Title = GameTitle; 
            Write("What is your name: ");
            string name = ReadLine();

            WriteLine($"Welcome to trivia {name}");

            ReadKey(true);

        }
        
    }
}
