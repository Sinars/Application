using SFML.Graphics;
using Snake.Controller;
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
        public bool IsRunning
        {
            get
            {
                return controller.isRunning;
            }
            set
            {
                controller.isRunning = value;
            }
        }
        public GameManagement(RenderWindow window)
        {
            
            //window.SetFramerateLimit(5);
            window.DispatchEvents();          
            this.window = window;
            SetUpGame();


        }
        
        private void SetUpGame()
        {
            snake = new Python();
            map = new Map();
            world = new World();
            world.AddSnake(snake);
            world.LoadMap(map);
            controller = new PlayerController(window, world);
        }


        public void StartGame()
        {
            world.Food = new Apple();
            controller.DispatchEvents();
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
