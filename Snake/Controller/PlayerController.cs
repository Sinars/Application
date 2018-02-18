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
        public Score Score { get; private set; }
        
        public PlayerController(RenderWindow window, World world) 
        {
            Score = new Score();
            //score.UpdateScore(27);
            isRunning = false;
            this.world = world;
            snake = world.snake;
            map = world.Map;
            this.window = window;
        }

        private void DeactivateEvents()
        {
            window.KeyPressed -= Window_KeyPressed;
        }

        private void UpdatePositions(int x, int y)
        {
            snake.Positions.RemoveFirst();
            snake.Positions.Add(x, y);
            //snake.Positions.XList.ForEach(z => Console.WriteLine(z+ " "));
            //Console.WriteLine("\n");
            //snake.Positions.YList.ForEach(z => Console.WriteLine(z+ " "));
        }

        private void AddPosition(int x, int y)
        {
            snake.Positions.Add(x, y);
           
        }
        public void ResetPosition()
        {
            snake.Head.Position = new SFML.System.Vector2f(400, 400);
            snake.MoveRight();
        }
        public void DispatchEvents()
        {
            window.KeyPressed += Window_KeyPressed;
            window.KeyReleased += Window_KeyReleased;
            window.Closed += Window_Closed;
        }

        private void Window_KeyReleased(object sender, KeyEventArgs e)
        {
           // throw new NotImplementedException();
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
                            if (world.Food.Eat((int)(snake.Head.Position.X - snake.Speed) / 30, (int)(snake.Head.Position.Y / 30)))
                            {
                                world.Food.ChangePosition(map.Available, snake.Positions);
                                snake.Grow();
                                Score.UpdateScore(world.Food.Points);
                                AddPosition((int)snake.Head.Position.X, (int)snake.Head.Position.Y);
                            }
                            if (snake.Canibalism(snake.Head.Position.X - snake.Speed, snake.Head.Position.Y))
                            {
                                GameStop();
                            }
                            snake.MoveLeft();
                            UpdatePositions((int)snake.Head.Position.X, (int)snake.Head.Position.Y);

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
                            if (world.Food.Eat((int)(snake.Head.Position.X + snake.Speed) / 30, (int)(snake.Head.Position.Y / 30)))
                            {
                                world.Food.ChangePosition(map.Available, snake.Positions);
                                snake.Grow();
                                Score.UpdateScore(world.Food.Points);
                                AddPosition((int)snake.Head.Position.X, (int)snake.Head.Position.Y);

                            }
                            if (snake.Canibalism(snake.Head.Position.X + snake.Speed, snake.Head.Position.Y))
                            {
                                GameStop();
                            }
                            snake.MoveRight();
                            UpdatePositions((int)snake.Head.Position.X, (int)snake.Head.Position.Y);
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
                            if (world.Food.Eat((int)(snake.Head.Position.X / 30), (int)((snake.Head.Position.Y - snake.Speed) / 30)))
                            {
                                world.Food.ChangePosition(map.Available, snake.Positions);
                                snake.Grow();
                                Score.UpdateScore(world.Food.Points);
                                AddPosition((int)snake.Head.Position.X, (int)snake.Head.Position.Y);
                            }
                            if (snake.Canibalism(snake.Head.Position.X, snake.Head.Position.Y - snake.Speed))
                            {
                                GameStop();
                            }
                            snake.MoveUp();
                            UpdatePositions((int)snake.Head.Position.X, (int)snake.Head.Position.Y);
                        }
                        break;

                    }
                case 3:
                    {
                        if (map.IsBrick((int)(snake.Head.Position.X) / 30, (int)((snake.Head.Position.Y + distance) / 30)))
                            GameStop();
                        else
                        {

                            if (world.Food.Eat((int)(snake.Head.Position.X) / 30, (int)((snake.Head.Position.Y + snake.Speed) / 30)))
                            {
                                world.Food.ChangePosition(map.Available, snake.Positions);
                                snake.Grow();
                                Score.UpdateScore(world.Food.Points);
                                AddPosition((int)snake.Head.Position.X, (int)snake.Head.Position.Y);
                            }
                            if (snake.Canibalism(snake.Head.Position.X, snake.Head.Position.Y + snake.Speed))
                            {
                                GameStop();

                            }
                            snake.MoveDown();
                            UpdatePositions((int)snake.Head.Position.X, (int)snake.Head.Position.Y);
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        public void GameStop()
        {
            DeactivateEvents();
            isRunning = false;
            snake.ResetSnake();
            direction = 1;
            
            
        }
        public void Render(RenderWindow window)
        {
            snake.Draw(window, RenderStates.Default);
            Score.Draw(window, RenderStates.Default);
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
                if(e.Code.Equals(Keyboard.Key.W) && direction != 3)
            {
                direction = 2;
                snake.HeadUp();
            }
            else
                if (e.Code.Equals(Keyboard.Key.S) && direction != 2)
            {
                direction = 3;
                snake.HeadDown();
            }
        }
    }
}
