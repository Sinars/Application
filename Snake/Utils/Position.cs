using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Utils
{
    class Position
    {
        public List<Vector2f> content { get; set; }

        public List<float> XList { get; }
        public List<float> YList { get; }
        public Position()
        {
            XList = new List<float>();
            YList = new List<float>();
            content = new List<Vector2f>();
        }

        public void Clear()
        {
            XList.Clear();
            YList.Clear();
            content.Clear();
        }
        public void Add(float x, float y)
        {
           content.Add(new Vector2f((int)x/30, (int)y/30));
            XList.Add((int)x/30);
            YList.Add((int)y/30);
        }
        public void RemoveFirst()
        {
            content.RemoveAt(0);
            XList.RemoveAt(0);
            YList.RemoveAt(0);
        }
    }
}
