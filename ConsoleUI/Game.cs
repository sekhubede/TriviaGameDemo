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
        private Player CurrentPlayer;
        private TriviaItem OctoTrivia;
        private TriviaItem UnicornTrivia;
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

        private TriviaItem[] triviaItems;

        public Game() 
        {
            string octoQuestion = "An octopus can fit through any hole larger than its beak?";
            OctoTrivia = new TriviaItem(octoQuestion, true);
            string unicornQuestion = "The National Animal of Scotland is the Unicorn?";
            UnicornTrivia = new TriviaItem(unicornQuestion, true);

            triviaItems = new TriviaItem[] {OctoTrivia, UnicornTrivia};
        }
        public void Start()
        {
            Title = GameTitle;

            GameIntro();

            ConsoleUtils.WaitForKey();

            Play();
        }

        private void GameIntro()
        {

            WriteLine(GameTitleArt);
            WriteLine(GameDescription);

        }

        private void Play()
        {
            Clear();
            string prompt = @$"{GameTitleArt}
What would you like to do?";
            string[] options;

            options = new string[] { "Play", "About", "Credits", "Exit" };

            Menu mainMenu = new Menu(prompt, options);

            int selectedIndex;
            selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    FirstChoice();

                    do
                    {
                        Clear();
                        string propmt = "Would you like to play again?";
                        options = new string[] { "Yes", "No" };

                        Menu firstChoiceMenu = new Menu(propmt, options);
                        selectedIndex = firstChoiceMenu.Run();

                        if (selectedIndex == 0)
                        {
                            CurrentPlayer.Score = 0;
                            AskQuestion();
                            ConsoleUtils.WaitForKey();
                        }

                    } while (selectedIndex == 0);

                        ExitGame();

                    break;
                case 1:
                    Clear();
                    About();
                    ConsoleUtils.WaitForKey();
                    Play();
                    break;
                case 2:
                    Clear();
                    Credits();
                    ConsoleUtils.WaitForKey();
                    Play();
                    break;
                case 3:
                    ExitGame();
                    break;
            }

        }


        private void FirstChoice()
        {
            Write("What is your name: ");
            string name = ReadLine();

            CurrentPlayer = new Player(name);

            WriteLine($"Welcome to Trivia Quest, {CurrentPlayer.Name}");
            WriteLine($"Your sore: {CurrentPlayer.Score}");

            AskQuestion();
                       
            ConsoleUtils.WaitForKey();
            Clear();
            
        }

        private void AskQuestion()
        {
            Menu itemMenu;

            foreach (TriviaItem item in triviaItems)
            {
                string propmt = item.Question;
                string[] options = {"true", "false"};

                itemMenu = new Menu(propmt,options);
                int selectedIndex = itemMenu.Run();

                bool playerAnswer;
                if (selectedIndex == 0)
                {
                    playerAnswer = true;
                }
                else
                {
                    playerAnswer = false;
                }

                if (item.CheckAnswer(playerAnswer))
                {
                    CurrentPlayer.Score += 1;
                }
            }

            WriteLine($"\nThanks for playing {CurrentPlayer.Name}");
            WriteLine($"Your score: {CurrentPlayer.Score}/{triviaItems.Length}");

        }

        private void About()
        {
            WriteLine("About the game...");

        }

        private void Credits()
        {
            WriteLine("Game credits...");
        }

        private void ExitGame()
        {
            WriteLine($"\nThanks for playing {CurrentPlayer.Name}");
            ConsoleUtils.QuitApplication();
        }
        
    }
}
