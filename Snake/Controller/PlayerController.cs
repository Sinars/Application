using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.GameObject;
using SFML.Graphics;
using SFML.Window;
using Snake.WorldContent;

namespace Snake.Controller
{
    class PlayerController
    {
        const int fps = 60;
        Python snake;
        private RenderWindow window;
        Map map;
        World world;
        bool up, down, left, right;
        const int distance = 30;

        public PlayerController(RenderWindow window, World world) 
        {
            this.world = world;
            snake = world.snake;
            map = world.Map;
            left = false;
            up = false;
            down = false;
            right = true;
            this.window = window;
            DispatchEvents();
            snake.Speed = 30f;
        }
        private void DispatchEvents()
        {
            window.KeyPressed += Window_KeyPressed;
            window.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }

        public void Update()
        {
            if (left)
            {
                if (!map.IsBrick((int)(snake.Head.Position.X - distance) / 30, (int)(snake.Head.Position.Y / 30)))
                {
                    if (world.Food.ChangePosition((int)(snake.Head.Position.X - snake.Speed) / 30, (int)(snake.Head.Position.Y / 30)))
                        snake.Grow();
                    snake.MoveLeft();
                }
            }
            if (right)
            {
                if (!map.IsBrick((int)((snake.Head.Position.X + distance) / 30), (int)(snake.Head.Position.Y / 30)))
                {
                    if (world.Food.ChangePosition((int)(snake.Head.Position.X - snake.Speed) / 30, (int)(snake.Head.Position.Y / 30)))
                        snake.Grow();
                    snake.MoveRight();
                }
            }
            if (down)
            {
                if (!map.IsBrick((int)(snake.Head.Position.X) / 30, (int)((snake.Head.Position.Y + distance) / 30)))
                {

                    if (world.Food.ChangePosition((int)(snake.Head.Position.X) / 30, (int)((snake.Head.Position.Y + snake.Speed) / 30)))
                        snake.Grow();
                        snake.MoveDown();
                }
            }
            if (up)
            {
                if (!map.IsBrick((int)(snake.Head.Position.X) / 30, (int)((snake.Head.Position.Y - distance) / 30)))
                {
                    if (world.Food.ChangePosition((int)(snake.Head.Position.X / 30), (int)((snake.Head.Position.Y - snake.Speed) / 30)))
                        snake.Grow();
                    snake.MoveUp();
                }
            
            }
        }

        public void Render(RenderWindow window)
        {
            snake.Draw(window, RenderStates.Default);
        }
        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            if (e.Code.Equals(Keyboard.Key.A) && !right)
            {
                left = true;
                down = false;
                up = false;
            }
            else
                if(e.Code.Equals(Keyboard.Key.D) && !left)
            {
                right = true;
                down = false;
                up = false;
            }
            else
                if(Keyboard.IsKeyPressed(Keyboard.Key.W) && !down)
            {
                up = true;
                left = false;
                right = false;
            }
            else
                if (Keyboard.IsKeyPressed(Keyboard.Key.S) && !up)
            {
                down = true;
                left = false;
                right = false;
            }
        }
    }
}
