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

namespace Snake
{
    class Program
    {
         static void Main(string[] args)
        {
            World world = new World();
            RenderWindow window = new RenderWindow(new VideoMode(900, 900), "Test");
            GameManagement game = new GameManagement(window);
            
            game.SetUpGame();
            while (window.IsOpen)
            {
                window.Clear();
                window.DispatchEvents();
                game.Update();
                game.Draw();
                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((Window)sender).Close();
        }
    }
}
