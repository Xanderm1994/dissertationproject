using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data.IDAO;

namespace Global.Data.DAO
{
    public class ScoreDAO : IScoreDAO
    {
        private GwEntities _Database;
        public ScoreDAO()
        {
            _Database = new GwEntities();
        }

        public void createscore(Score newscore)
        {
            newscore.ScoreID = getnextid();
            _Database.Scores.Add(newscore);
            _Database.SaveChanges();
        }
        public int getnextid()
        {
            IQueryable<int> id;
            id = from score in _Database.Scores orderby score.ScoreID descending select score.ScoreID;

            if (id.ToList().Count == 0)
            {
                return 0;
            }
            else
            {
                return id.First() + 1;
            }

        }
    }
}
