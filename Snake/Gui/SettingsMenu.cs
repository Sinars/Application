using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Gui
{
    class SettingsMenu
    {
        Sprite background;
        Sprite menuItem;
        Sprite back, up, down;
        Sprite shadow;
        RenderWindow window;
        Text text;
        Text speed;
        uint fps;
        public uint FrameLimit { get { return fps; } }
        public bool Finished { get; set; }
        public SettingsMenu(RenderWindow window)
        {
            fps = 3;
            Finished = false;
            this.window = window;
            Texture back = new Texture("Resources\\background.png");
            background = new Sprite(back);
            CreateMenuItem();
            
        }

        public void ActivateEvents()
        {
            window.MouseButtonPressed += Window_MouseButtonPressed;
        }
        private void Window_MouseButtonPressed(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            if (e.X >= 20 && e.X <= 50 && e.Y >= 550 && e.Y <= 580)
            {
                Finished = true;
                window.MouseButtonPressed -= Window_MouseButtonPressed;
            }
            if (e.X >= 550 && e.X <= 580 && e.Y >= 210 && e.Y <= 240)
            {
                if (int.Parse(speed.DisplayedString) < 5)
                {
                    speed.DisplayedString = (int.Parse(speed.DisplayedString) + 1).ToString();
                    fps += 3;
                }
            }
            if (e.X >= 550 && e.X <= 580 && e.Y >= 250 && e.Y <= 280)
            {
                if (int.Parse(speed.DisplayedString) > 1)
                {
                    speed.DisplayedString = (int.Parse(speed.DisplayedString) - 1).ToString();
                    fps -= 3;
                }
            }
        }
        

        private void CreateMenuItem()
        {
            speed = new Text("1", new Font("Resources\\Fonts\\Typolino.ttf"));
            speed.Position = new SFML.System.Vector2f(520, 220);
            text = new Text("Speed: ", new Font("Resources\\Fonts\\Typolino.ttf"));
            text.Position = new SFML.System.Vector2f(320, 220);
            shadow = new Sprite(new Texture("Resources\\shadow.png"), new IntRect(0, 0, 300, 100));
            shadow.Position = new SFML.System.Vector2f(305, 205);
            Texture texture = new Texture("Resources\\menuitem.png");
            menuItem = new Sprite(texture);
            menuItem.Position = new SFML.System.Vector2f(300, 200);
            menuItem.TextureRect = new IntRect(0,0,300, 100);
            Texture backTexture = new Texture("Resources\\back.png");
            back = new Sprite(backTexture);
            back.Position = new SFML.System.Vector2f(20, 550);
            up = new Sprite(new Texture("Resources\\up.png"));
            down = new Sprite(new Texture("Resources\\down.png"));
            up.Position = new SFML.System.Vector2f(550, 210);
            down.Position = new SFML.System.Vector2f(550, 250);
        }

        public void Draw()
        {
            window.Draw(background);
            //window.Draw(shadow);
            //window.Draw(menuItem);
            window.Draw(text);
            window.Draw(back);
            window.Draw(up);
            window.Draw(down);
            window.Draw(speed);
        }
    }
}
