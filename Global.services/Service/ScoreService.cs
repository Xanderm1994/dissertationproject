using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;
using Global.Data.IDAO;
using Global.Data.DAO;
using Global.Services.IService;

namespace Global.Services.Service
{
   public class ScoreService : IScoreService
    {
        private IScoreDAO _scoredao;

        public ScoreService()
        {
            _scoredao = new ScoreDAO();
        }

        public void createscore(Score newscore)
        {
            _scoredao.createscore(newscore);
        }

    }
}
