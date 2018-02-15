using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects
{
    class Apple:Food    
    {
        public Apple():base()
        {
            
            texture = new SFML.Graphics.Texture("Resources\\apple.png");
            sprite = new SFML.Graphics.Sprite(texture, new SFML.Graphics.IntRect(0, 0, 30, 30));
            Points = 1;
            //Console.WriteLine((random.Next() % 30) * 29);
            Position = new Vector2f(((random.Next() % 28) + 1) * 30, ((random.Next() % 18) + 1) * 30);
            

        }
    }
}
