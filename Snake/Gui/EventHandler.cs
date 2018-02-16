using SFML.Window;
using Snake.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Gui
{
    partial class MainMenu
    {
        SettingsMenu settingsMenu;
        GameManagement game;

        private void Window_MouseButtonPressed(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            
            if (bottomSprite.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
                 window.Close();
            else
            if (topSprite.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
            {
                    
                window.MouseButtonPressed -= Window_MouseButtonPressed;
                window.SetFramerateLimit(settingsMenu.FrameLimit);
                game.IsRunning = true;
                RunGame();
            }
            if (settings.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
            {
                
                window.MouseButtonPressed -= Window_MouseButtonPressed;
                
                settingsMenu.ActivateEvents();
                ShowSettingsMenu();
            }
            if (lBoard.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
            {
                window.MouseButtonPressed -= Window_MouseButtonPressed;
                ShowLeaderBoardMenu(); 
                
            }

        }
        private void ShowSettingsMenu()
        {
            while (!settingsMenu.Finished)
            {
                window.Clear();
                settingsMenu.Draw();
                window.DispatchEvents();
                window.Display();
            }
            window.MouseButtonPressed += Window_MouseButtonPressed;
            settingsMenu.Finished = false;
        }
        private void RunGame()
        {

            game.StartGame();
            while (game.IsRunning)
            {
                window.Clear();
                window.DispatchEvents();
                game.Update();
                game.Draw();
                
                window.Display();
            }
            window.SetFramerateLimit(60);
            window.MouseButtonPressed += Window_MouseButtonPressed;
        }
        private void ShowLeaderBoardMenu()
        {
            LeaderboardMenu menu = new LeaderboardMenu(window);
            while(!menu.IsFinished)
            {
                menu.Draw();
            }
            window.MouseButtonPressed += Window_MouseButtonPressed;
        }
    }
}
