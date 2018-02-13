using SFML.Graphics;
using SFML.System;
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
        int posX, posY;
        Texture brickTexture, grassTexture;
        public Map()
        {
            brickTexture = new Texture("Resources\\brick.png");
            grassTexture = new Texture("Resources\\grass.png");
            posX = 0;
            posY = 0;
            Area = new Sprite[30,30];
        }
        public void GenerateLevel()
        {
            int increment = 30;
            Vector2f pos = new Vector2f(0, 0);
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                    if (i == 0 || i == 29 || j == 0 || j == 29)
                    {
                        Sprite brick = new Sprite(brickTexture, new IntRect(0, 0, 30, 30));
                        brick.Position = pos;
                        pos = new Vector2f(pos.X + increment, pos.Y);
                        Console.WriteLine(pos + "\n");
                        Area[i, j] = brick;
                    }
                    else
                    {
                        Sprite grass = new Sprite(grassTexture ,new IntRect(0, 0, 30, 30));
                        grass.Position = pos;
                        pos = new Vector2f(pos.X + increment, pos.Y);
                        Console.WriteLine(pos + "\n");
                        Area[i, j] = grass;

                    }
                pos = new Vector2f(0, pos.Y + increment);
                
            }
        }
        public bool IsBrick(int i, int j)
        {
            return Area[i, j].Texture.Equals(brickTexture);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < 30; i++)
                for (int j = 0; j < 30; j++)
                    target.Draw(Area[i, j], RenderStates.Default);
        }

    }
}
