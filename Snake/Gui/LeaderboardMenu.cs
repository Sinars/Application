using SFML.Graphics;
using SFML.Window;
using Snake.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Gui
{
    class LeaderboardMenu
    {
        RenderWindow window;
        Sprite bg, back;
        private GameManagement game;
        List<Text> textData;
        Font font;
        public bool IsFinished { get; set; }
        public LeaderboardMenu(RenderWindow window, GameManagement game)
        {
            textData = new List<Text>();
            font = new Font("Resources\\Fonts\\arial.otf");
            this.game = game;
            IsFinished = false;
            this.window = window;
            window.MouseButtonPressed += Window_MouseButtonPressed;
            LoadData();
            LoadComponent();
            
        }
        private void LoadData()
        {
            
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
            int initX = 200, initY = 200;
            int i = 1;
            Text title = new Text("HighScores", font);
            title.Position = new SFML.System.Vector2f(350, 140);
            textData.Add(title);
            foreach (var a in game.Leaderboard.GetHighScores().ToList())
            {
                Text name = new Text(i.ToString() + ". " + a.name, font);
                Text score = new Text(a.score.ToString(), font);
                i++;
                name.Position = new SFML.System.Vector2f(initX, initY);
                score.Position = new SFML.System.Vector2f(initX + 400, initY);
                initY += 40;
                textData.Add(name);
                textData.Add(score);
            }
        }
        public void Draw()
        {
            window.Clear();
            window.Draw(bg);
            window.Draw(back);
            textData.ForEach(x => window.Draw(x));
;            window.DispatchEvents();
            window.Display();
        }
    }

}
