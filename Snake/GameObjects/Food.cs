using SFML.Graphics;
using SFML.System;
using Snake.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects
{
    class Food:Drawable
    {
        protected Random random;
        virtual protected Texture texture { get; set; }
        virtual protected Sprite sprite { get; set; }
        virtual public int Points { get; set; }
        
        virtual protected Vector2f Position { get { return sprite.Position; }  set { sprite.Position = value; } }
        public Food()
        {
            random = new Random();
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite, RenderStates.Default);
        }

        public void ChangePosition(Position total, Position taken)
        {
            int x = ((random.Next() % 28) + 1);
            int y = (random.Next() % 18 + 1);
            var selection = total.content.Except(taken.content).ToList();
            int i = random.Next(0, selection.Count);
            Console.WriteLine(i);
            //Console.WriteLine(x + " " + y);
            Position = new Vector2f(selection[i].X * 30, selection[i].Y * 30);
            
        }
        public bool Eat(int i, int j)
        {
            if ((int)(Position.X / 30) == i && (int)(Position.Y / 30) == j)
            {
                return true;
            }
            return false;
        }
    }
}
