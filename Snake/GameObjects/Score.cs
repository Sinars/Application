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
        public Score()
        {
            font = new Font("Resources\\Fonts\\InriaSerif-Bold.ttf");
            points = new Text("0", font);
        }
        
        public void UpdateScore(int i)
        {
            points.DisplayedString = (int.Parse(points.DisplayedString) + i).ToString();
        }
        public void ResetScore()
        {
            points.DisplayedString = "0";
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
