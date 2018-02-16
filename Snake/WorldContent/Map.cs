using SFML.Graphics;
using SFML.System;
using Snake.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.WorldContent
{
    class Map : Drawable
    {
        
        Sprite[,] Area;
        const int X = 30, Y = 20;
        Texture brickTexture, grassTexture;
        public Position Available { get; set; }
        public Map()
        {
            Available = new Position();
            brickTexture = new Texture("Resources\\brick.png");
            grassTexture = new Texture("Resources\\grass.png");
            Area = new Sprite[30,30];
        }
        public void GenerateLevel()
        {
            int increment = 30;
            Vector2f pos = new Vector2f(0, 0);
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                    if (i == 0 || i == Y-1 || j == 0 || j == X-1)
                    {
                        Sprite brick = new Sprite(brickTexture, new IntRect(0, 0, 30, 30));
                        brick.Position = pos;
                        pos = new Vector2f(pos.X + increment, pos.Y);
                        
                        //Console.WriteLine(pos + "\n");
                        Area[i, j] = brick;
                    }
                    else
                    {
                        Sprite grass = new Sprite(grassTexture ,new IntRect(0, 0, 30, 30));
                        grass.Position = pos;
                        pos = new Vector2f(pos.X + increment, pos.Y);
                        Available.Add((int)pos.X, (int)pos.Y);
                        Area[i, j] = grass;

                    }
                pos = new Vector2f(0, pos.Y + increment);
                //Console.WriteLine(pos);
                
            }
            Available.content.ForEach(x=>Console.WriteLine(x));
            
        }
        public bool IsBrick(int i, int j)
        {
            return Area[j, i].Texture.Equals(brickTexture);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < Y; i++)
                for (int j = 0; j < X; j++)
                    target.Draw(Area[i, j], RenderStates.Default);
        }

    }
}
