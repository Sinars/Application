using SFML.Graphics;
using SFML.Window;
using Snake.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Gui
{
    class EndGameMenu
    {
        Sprite background, main, shadow, okButton;
        RenderWindow window;
        Font font;
        Text name, input, finalScore, okText;
        RectangleShape textArea;
        int size = 0;
        string inputText;

        GameManagement game;
        public bool IsFinished { get; private set; }
        public EndGameMenu(RenderWindow window, GameManagement game)
        {
            this.game = game;
            inputText = "";
            font = new Font("Resources\\Fonts\\arial.otf");
            IsFinished = false;
            this.window = window;
            LoadComponents();
            DispatchEvents();
        }

        private void LoadComponents()
        {
            okText = new Text("Ok", font);
            okText.Position = new SFML.System.Vector2f(430, 355);
            okButton = new Sprite(new Texture("Resources\\ok.png"));
            okButton.Position = new SFML.System.Vector2f(400, 350);
            finalScore = new Text("Final Score:     " + game.Controller.Score.Points.ToString(), font);
            finalScore.Position = new SFML.System.Vector2f(250, 200);
            input = new Text("", font);
            input.Color = new Color(Color.Black);
            input.Position = new SFML.System.Vector2f(450, 250);
            textArea = new RectangleShape(new SFML.System.Vector2f(200, 40));
            textArea.Position = new SFML.System.Vector2f(450, 250);
            textArea.FillColor = new Color(Color.White);
            name = new Text("Name:", font);
            name.Position = new SFML.System.Vector2f(250, 250);
            main = new Sprite(new Texture("Resources\\menuitem.png"), new IntRect(0, 0, 500, 200));
            main.Position = new SFML.System.Vector2f(200, 200);
            shadow = new Sprite(new Texture("Resources\\shadow.png"), new IntRect(0, 0, 500, 200));
            shadow.Position = new SFML.System.Vector2f(205, 205);
            background = new Sprite(new Texture("Resources\\end2.png"));
        }
        private void DispatchEvents()
        {
            window.TextEntered += Window_TextEntered;
            window.MouseButtonPressed += Window_MouseButtonPressed;
        }

        private void Window_MouseButtonPressed(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            if (size > 0 && okButton.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
            {
                window.MouseButtonPressed -= Window_MouseButtonPressed;
                window.TextEntered -= Window_TextEntered;
                IsFinished = true;
            }
                
        }

        private void Window_TextEntered(object sender, SFML.Window.TextEventArgs e)
        {
            int output = (int)e.Unicode.ToCharArray()[0];
            if (size < 11)
            {
                if (output >= 48 && output < 57)
                {
                    inputText += e.Unicode;
                    size++;
                }
                if (output > 64 && output < 91)
                {
                    inputText += e.Unicode;
                    size++;
                }
                if (output > 96 && output < 123)
                {
                    size++;
                    inputText += e.Unicode;
                }
            }
            if ((int)(e.Unicode.ToCharArray()[0]) == 8 && size > 0)
            {
                inputText = inputText.Remove(size - 1, 1);
                size--;
            }
            input.DisplayedString = inputText;
            if (output == 13 && size > 0)
            {
                window.TextEntered -= Window_TextEntered;
                window.MouseButtonPressed -= Window_MouseButtonPressed;
                game.Controller.Score.Name = inputText;
                game.Leaderboard.Add(inputText, game.Controller.Score);
                IsFinished = true;
            }
        }

        public void Draw()
        {
            window.Draw(background);
            window.Draw(finalScore);
            window.Draw(okButton);
            window.Draw(okText);
            //window.Draw(shadow);
            //window.Draw(main);
            window.Draw(name);
            window.Draw(textArea);
            window.Draw(input);
        }
    }
}
