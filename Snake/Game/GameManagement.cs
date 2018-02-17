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
        public PlayerController Controller { get; set; }
        Map map;
        Python snake;
        public Leaderboard Leaderboard { get; private set; }
        public RenderWindow window;
        public bool IsRunning
        {
            get
            {
                return Controller.isRunning;
            }
            set
            {
                Controller.isRunning = value;
            }
        }

        

        public GameManagement(RenderWindow window)
        {
            
            //window.SetFramerateLimit(5);
            window.DispatchEvents();          
            this.window = window;
            Leaderboard = new Leaderboard();
            SetUpGame();
            

        }
        
        private void SetUpGame()
        {
            snake = new Python();
            map = new Map();
            world = new World();
            world.AddSnake(snake);
            world.LoadMap(map);
            world.Leaderboard = Leaderboard;
            Controller = new PlayerController(window, world);
        }


        public void StartGame()
        {
            world.Food = new Apple();
            Controller.DispatchEvents();
        }
        public void Update()
        {
            Controller.Update();
        }
        public void Draw()
        {
            world.Draw(window);
            Controller.Render(window);
        }
    }
}
