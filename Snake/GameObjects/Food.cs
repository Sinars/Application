using SFML.Graphics;
using SFML.System;
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
            random = new Random(Time.Zero.AsMilliseconds());
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite, RenderStates.Default);
        }

        public bool ChangePosition(int i, int j)
        {
            if ((int)(Position.X / 30) == i && (int)(Position.Y / 30) == j)
            {
                //int x = ((random.Next() % 28) + 1) * 30, y = ((random.Next() % 28) + 1) * 30;
                Position = new Vector2f(((random.Next() % 28) + 1) * 30, ((random.Next() % 18) + 1) * 30);
                return true;
            }
            return false;
        }
    }
}
