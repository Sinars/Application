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
            
            if (e.X >= 350 && e.X <= 550 && e.Y >= 400 && e.Y <= 450)
                    window.Close();
            else
            if (e.X >= 350 && e.X <= 550 && e.Y >= 300 && e.Y <= 350)
            {
                    
                window.MouseButtonPressed -= Window_MouseButtonPressed;
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
            while (game.IsRunning)
            {
                window.Clear();
                window.DispatchEvents();
                game.Update();
                game.Draw();
                
                window.Display();
            }
            window.MouseButtonPressed += Window_MouseButtonPressed;
        }
    }
}
