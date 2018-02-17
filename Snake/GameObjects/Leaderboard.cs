using System;
using System.Collections.Generic;
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
        public void Add(string name, Score score)
        {
            if (Data.Values.Count == 5 && score.Points > Data.Min().Value.Points)
            {
                Data.Remove(Data.Min().Key);
                Data.Add(name, score);
            }
            Data.Add(name, score);

        }
        private void Uplaod()
        {
           
        }
    }
}
