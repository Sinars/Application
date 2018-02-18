using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects
{
    class Score : Drawable
    {
        Font font;
        Text points;
        public int Points { get; private set; }
        public string Name { get; set; }
        public Score()
        {
            font = new Font("Resources\\Fonts\\InriaSerif-Bold.ttf");
            points = new Text("0", font);
            Points = 0;
        }
        public Score(int points)
        {
            font = new Font("Resources\\Fonts\\InriaSerif-Bold.ttf");
            this.points = new Text("0", font);

            Points = points;
        }
        
        public void UpdateScore(int i)
        {
            points.DisplayedString = (int.Parse(points.DisplayedString) + i).ToString();
            Points += i;
        }

        public void UploadScore()
        {
            //System.IO.File.AppendAllText()
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(points);
        }
    }
}
