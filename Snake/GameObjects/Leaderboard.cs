using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects
{
    class Leaderboard
    {
        public Dictionary<string, Score> Data { get; }
        public Leaderboard()
        {
            Data = new Dictionary<string, Score>();
            LoadData();
        }

        public IEnumerable<dynamic> GetHighScores()
        {
            
            var output = (from s in Data
                          orderby s.Value.Points descending
                          select
                          new
                          {
                              name = s.Key,
                              score = s.Value.Points
                          }).ToList();
            return output;
        }
        private string findFirst(string name, Score score)
        {
            foreach (String s in Data.Keys)
                if (Data[s].Points == Data.Values.Min().Points)
                {
                    return s;
                }
            return "";

        }
        public void Add(string name, Score score)
        {
            string temp=findFirst(name, score);
            
            if (Data.Values.Count == 6 && score.Points > Data[temp].Points)
            {
                Data.Remove(temp);
                Data.Add(name, score);
            }
            if (Data.ContainsKey(name) && score.Points >= Data[name].Points)
            {
                Data[name] = score;
                Upload();
            }
            else
                if (!Data.ContainsKey(name) && Data.Count < 6)
            {
                Data.Add(name, score);
                Upload();
            }
        }
        private void LoadData()
        {
            using (StreamReader sr = File.OpenText("Resources\\Data\\score.txt"))
            {
                string readData = sr.ReadLine();
                while (readData != null)
                {
                    string[] data = readData.Split(':');
                    Data.Add(data[0], new GameObjects.Score(int.Parse(data[1]), data[0]));
                    readData = sr.ReadLine();
                }
            }
        }
        private void Upload()
        {
            using (StreamWriter sw = File.CreateText("Resources\\Data\\score.txt"))
                Data.Values.ToList().ForEach(x => sw.WriteLine(x.Name + ":" + x.Points));
        }
    }
}
