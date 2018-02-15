using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.GameObjects;
using SFML.Graphics;
using SFML.Window;
using Snake.WorldContent;
using Snake.Gui;
using Snake.Game;

namespace Snake.Controller
{
    class PlayerController
    {
        const int fps = 60;
        Python snake;
        private RenderWindow window;
        Map map;
        World world;
        int direction = 1;
        /**
         * 0 - move left
         * 1 - move right
         * 2 - move up
         * 3 - move down
         **/
        const int distance = 30;
        public bool isRunning;
        Score score;
        public PlayerController(RenderWindow window, World world) 
        {
            score = new Score();
            isRunning = false;
            this.world = world;
            snake = world.snake;
            map = world.Map;
            this.window = window;
            DispatchEvents();
            
        }
        public void ResetPosition()
        {
            snake.Head.Position = new SFML.System.Vector2f(400, 400);
            snake.MoveRight();
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
            switch (direction)
            {
                case 0:
                    {
                        if (map.IsBrick((int)(snake.Head.Position.X - distance) / 30, (int)(snake.Head.Position.Y / 30)))
                        {
                            GameStop();
                        }
                        else
                        {
                            if (world.Food.ChangePosition((int)(snake.Head.Position.X - snake.Speed) / 30, (int)(snake.Head.Position.Y / 30)))
                            {
                                snake.Grow();
                                score.UpdateScore(world.Food.Points);
                            }
                            if (snake.Canibalism(snake.Head.Position.X - snake.Speed, snake.Head.Position.Y))
                            {
                                GameStop();
                            }
                            snake.MoveLeft();

                        }
                        break;
                    }
                case 1:
                    {
                        if (map.IsBrick((int)((snake.Head.Position.X + distance) / 30), (int)(snake.Head.Position.Y / 30)))
                        {
                            GameStop();
                        }
                        else
                        {
                            if (world.Food.ChangePosition((int)(snake.Head.Position.X + snake.Speed) / 30, (int)(snake.Head.Position.Y / 30)))
                            {
                                snake.Grow();
                                score.UpdateScore(world.Food.Points);
                            }
                            if (snake.Canibalism(snake.Head.Position.X + snake.Speed, snake.Head.Position.Y))
                            {
                                GameStop();
                            }
                            snake.MoveRight();
                        }
                        break;
                    }
                
                case 2:
                    {

                        if (map.IsBrick((int)(snake.Head.Position.X) / 30, (int)((snake.Head.Position.Y - distance) / 30)))
                        {
                            GameStop();
                        }
                        else
                        {
                            if (world.Food.ChangePosition((int)(snake.Head.Position.X / 30), (int)((snake.Head.Position.Y - snake.Speed) / 30)))
                            {
                                snake.Grow();
                                score.UpdateScore(world.Food.Points);
                            }
                            if (snake.Canibalism(snake.Head.Position.X, snake.Head.Position.Y - snake.Speed))
                            {
                                GameStop();
                            }
                            snake.MoveUp();
                        }
                        break;

                    }
                case 3:
                    {
                        if (map.IsBrick((int)(snake.Head.Position.X) / 30, (int)((snake.Head.Position.Y + distance) / 30)))
                            GameStop();
                        else
                        {

                            if (world.Food.ChangePosition((int)(snake.Head.Position.X) / 30, (int)((snake.Head.Position.Y + snake.Speed) / 30)))
                            {
                                snake.Grow();
                                score.UpdateScore(world.Food.Points);
                            }
                            if (snake.Canibalism(snake.Head.Position.X, snake.Head.Position.Y + snake.Speed))
                            {
                                GameStop();

                            }
                            snake.MoveDown();
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        private void GameStop()
        {
            isRunning = false;
            snake.ResetSnake();
            score.ResetScore();
            direction = 1;
        }
        public void Render(RenderWindow window)
        {
            snake.Draw(window, RenderStates.Default);
            score.Draw(window, RenderStates.Default);
        }
        private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            if (e.Code.Equals(Keyboard.Key.A) && direction != 1 )
            {
                direction = 0;
                snake.HeadLeft();
            }
            else
                if(e.Code.Equals(Keyboard.Key.D) && direction != 0)
            {
                direction = 1;
                snake.HeadRight();
            }
            else
                if(Keyboard.IsKeyPressed(Keyboard.Key.W) && direction != 3)
            {
                direction = 2;
                snake.HeadUp();
            }
            else
                if (Keyboard.IsKeyPressed(Keyboard.Key.S) && direction != 2)
            {
                direction = 3;
                snake.HeadDown();
            }
        }
    }
}
