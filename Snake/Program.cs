using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.WorldContent;
using SFML.Graphics;
using Snake.Controller;
using Snake.Game;
using Snake.Gui;

namespace Snake
{
    class Program
    {
         static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(900, 600), "Test");
            window.SetFramerateLimit(60);
           // window.
            MainMenu menu = new MainMenu(window);
            window.Closed += Window_Closed;
            while (window.IsOpen)
            {
                window.Clear();
                window.DispatchEvents();
                menu.ShowMenu();
                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((Window)sender).Close();
        }
    }
}
