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
    partial class MainMenu
    {
        Texture  texture, backgroundTexture;
        Sprite topSprite, lBoard, bottomSprite, menu, settings;
        Font font;
        Color fillColor;
        Texture shadow;
        private RenderWindow window;

        
        Text topText;
        Text bottomText;
        public MainMenu(RenderWindow windows)
        {
            this.window = windows;
            settingsMenu = new SettingsMenu(window);
            game = new GameManagement(window);
            shadow = new Texture("Resources\\shadow.png");
            //fillColor = new Color(4, 48, 30, 255);
            fillColor = new Color(255, 255, 255, 255);
            font = new Font("Resources\\Fonts\\JMH THE SPIDER bold.ttf");
            window.MouseButtonPressed += Window_MouseButtonPressed;
            CreateMenu();
        }

      

        private void CreateMenu()
        {
            Texture backgroundTexture = new Texture("Resources\\background.png");
            menu = new Sprite(backgroundTexture);
            CreateMenuItems();

        }
        private void CreateMenuItems()
        {
            
            //play
            Texture texture = new Texture("Resources\\glow_test.png");
            topSprite = new Sprite(texture, new IntRect(0, 0, 200, 50));
            topSprite.Position = new SFML.System.Vector2f(20, 100);
            topText = new Text("Play", font);
            topText.Color = fillColor;
            topText.Position = new SFML.System.Vector2f(90, 100);

            //exit
            bottomSprite = new Sprite(texture, new IntRect(0, 0, 200, 50));
            bottomSprite.Position = new SFML.System.Vector2f(20, 150);
            bottomText = new Text("Exit", font);
            bottomText.Color = fillColor;
            bottomText.Position = new SFML.System.Vector2f(90, 150);

            //setings
            Texture settingsTexture = new Texture("Resources\\settings.png");
            settings = new Sprite(settingsTexture);
            settings.Position = new SFML.System.Vector2f(20, 550);
            settings.Color = new Color(187, 193, 189, 255);
            //leaderboard

            Texture lBoardTexture = new Texture("Resources\\leadboard.png");
            lBoard = new Sprite(lBoardTexture);
            lBoard.Position = new SFML.System.Vector2f(60, 550);

        }
        
        public void ShowMenu()
        {
           
          
                window.Draw(menu);
            if((topSprite.GetGlobalBounds().Contains(SFML.Window.Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y)))
            //    window.Draw(behindTop);
                window.Draw(topSprite);
            //  window.Draw(behindBottom);
            if (bottomSprite.GetGlobalBounds().Contains(SFML.Window.Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
            window.Draw(bottomSprite);
                window.Draw(topText);
                window.Draw(bottomText);
                window.Draw(settings);
            window.Draw(lBoard);
        }
        
    }
}
