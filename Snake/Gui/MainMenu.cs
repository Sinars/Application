using SFML.Graphics;
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
        Sprite topSprite,behindTop, behindBottom, bottomSprite, menu, settings;
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
            font = new Font("Resources\\Fonts\\Typolino.ttf");
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
            behindTop = new Sprite(shadow, new IntRect(0, 0, 200, 50));
            behindBottom = new Sprite(shadow, new IntRect(0, 0, 200, 50));
            
            Texture texture = new Texture("Resources\\menuitem.png");
            topSprite = new Sprite(texture, new IntRect(100, 100, 200, 50));
            topSprite.Position = new SFML.System.Vector2f(350, 300);
            bottomSprite = new Sprite(texture, new IntRect(100, 100, 200, 50));
            bottomSprite.Position = new SFML.System.Vector2f(350, 400);
            behindTop.Position = new SFML.System.Vector2f(355, 305);
            behindBottom.Position = new SFML.System.Vector2f(355, 405);
            topText = new Text("Play", font);
            topText.Color = fillColor;
            bottomText = new Text("Exit", font);
            bottomText.Color = fillColor;
            bottomText.Position = new SFML.System.Vector2f(425, 400);
            topText.Position = new SFML.System.Vector2f(410, 300);
            Texture settingsTexture = new Texture("Resources\\settings.png");
            settings = new Sprite(settingsTexture);
            settings.Position = new SFML.System.Vector2f(20, 550);
            settings.Color = new Color(187, 193, 189, 255);

        }
        
        public void ShowMenu()
        {
           
                window.Draw(menu);
                window.Draw(behindTop);
                window.Draw(topSprite);
                window.Draw(behindBottom);
                window.Draw(bottomSprite);
                window.Draw(topText);
                window.Draw(bottomText);
            window.Draw(settings);
        }
        
    }
}
