using SFML.Graphics;
using SFML.Window;
using Snake.GameObject;
using Snake.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.WorldContent
{
    class World
    {
        public Map Map { get; set; }
        public Python Snake { get { return snake; } }
        public Python snake;
        public Food Food { get; set; }
        public World()
        {

        }

        
        public void LoadMap(Map map)
        {
            Map = map;
            map.GenerateLevel();
        }

        public void AddSnake(Python snake)
        {
            this.snake = snake;

        }


        public void Draw(RenderWindow target)
        {
            Map.Draw(target, RenderStates.Default);
            snake.Draw(target, RenderStates.Default);
            Food.Draw(target, RenderStates.Default);
        }
        
    }
}
