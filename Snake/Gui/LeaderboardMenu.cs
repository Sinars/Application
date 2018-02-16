using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Gui
{
    class LeaderboardMenu
    {
        RenderWindow window;
        Sprite bg, back;
        public bool IsFinished { get; set; }
        public LeaderboardMenu(RenderWindow window)
        {
            IsFinished = false;
            this.window = window;
            window.MouseButtonPressed += Window_MouseButtonPressed;
            LoadComponent();
        }

        private void Window_MouseButtonPressed(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            if (back.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
            {
                window.MouseButtonPressed -= Window_MouseButtonPressed;
                IsFinished = true;
            }
        }

        private void LoadComponent()
        {
            bg = new Sprite(new Texture("Resources\\background_lb.png"));
            back = new Sprite(new Texture("Resources\\back.png"));
            back.Position = new SFML.System.Vector2f(20, 550);
        }
        public void Draw()
        {
            window.Clear();
            window.Draw(bg);
            window.Draw(back);
            window.DispatchEvents();
            window.Display();
        }
    }

}
