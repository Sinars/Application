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
            
            if (e.X >= 20 && e.X <= 220 && e.Y >= 150 && e.Y <= 200)
                 window.Close();
            else
            if (e.X >= 20 && e.X <= 220 && e.Y >= 100 && e.Y <= 150)
            {
                    
                window.MouseButtonPressed -= Window_MouseButtonPressed;
                window.SetFramerateLimit(settingsMenu.FrameLimit);
                game.IsRunning = true;
                RunGame();
            }
            if (e.X >= 20 && e.X <= 50 && e.Y >= 550 && e.Y <= 580)
            {
                
                window.MouseButtonPressed -= Window_MouseButtonPressed;
                
                settingsMenu.ActivateEvents();
                ShowSettingsMenu();
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
    }
}
