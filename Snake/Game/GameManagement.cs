using SFML.Graphics;
using Snake.Controller;
using Snake.GameObject;
using Snake.GameObjects;
using Snake.WorldContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Game
{
    class GameManagement
    {

        World world;
        PlayerController controller;
        Map map;
        Python snake;
        public RenderWindow window;
        public GameManagement(RenderWindow window)
        {
            window.SetFramerateLimit(10);
            window.DispatchEvents();
            map = new Map();
            world = new World();
            this.window = window;
            snake = new Python();
            
        }
        
        public void SetUpGame()
        {
            world.AddSnake(snake);
            world.LoadMap(map);
            world.Food = new Apple();
            controller = new PlayerController(window, world);
        }
        public void Update()
        {
            controller.Update();
        }
        public void Draw()
        {
            world.Draw(window);
            controller.Render(window);
        }
    }
}
