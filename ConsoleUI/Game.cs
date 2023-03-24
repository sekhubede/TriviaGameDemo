using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TriviaLibrary;
using MenuLibrary;

using static System.Console;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace ConsoleUI
{
    internal class Game
    {
        private string GameTitle = "Trivia Quest";
        private string GameTitleArt = @"
████████╗██████╗ ██╗██╗   ██╗██╗ █████╗      ██████╗ ██╗   ██╗███████╗███████╗████████╗
╚══██╔══╝██╔══██╗██║██║   ██║██║██╔══██╗    ██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝
   ██║   ██████╔╝██║██║   ██║██║███████║    ██║   ██║██║   ██║█████╗  ███████╗   ██║   
   ██║   ██╔══██╗██║╚██╗ ██╔╝██║██╔══██║    ██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║   
   ██║   ██║  ██║██║ ╚████╔╝ ██║██║  ██║    ╚██████╔╝╚██████╔╝███████╗███████║   ██║   
   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═══╝  ╚═╝╚═╝  ╚═╝     ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝   
                                                                                       
";
        private string GameDescription = @"Welcome to Trivia Quest
Battle your friends for the top score in silly trivia.";

        public void Start()
        {
            Title = GameTitle;

            GameIntro();

            ConsoleUtils.WaitForKey();

            WriteLine(GameTitle);
            WriteLine();

            string prompt = "What would you like to do?";
            string[] options = { "Play", "About", "Credits", "Exit" };

            Menu mainMenu = new Menu(prompt, options);

            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Play();
                    ConsoleUtils.WaitForKey();
                    break;
                case 1:
                    About();
                    ConsoleUtils.WaitForKey();
                    break;
                case 2:
                    Credits();
                    ConsoleUtils.WaitForKey();
                    break;
                case 3:
                    Exit();
                    break;
            }

       
        }

        private void GameIntro()
        {

            WriteLine(GameTitleArt);
            WriteLine(GameDescription);

        }

        private void Play()
        {
            Write("What is your name: ");
            string name = ReadLine();

            WriteLine($"Welcome to trivia {name}");

        }

        private void About()
        {
            WriteLine("About the game...");
        }

        private void Credits()
        {
            WriteLine("Game credits...");
        }

        private void Exit()
        {
            ConsoleUtils.QuitApplication();
        }
        
    }
}
