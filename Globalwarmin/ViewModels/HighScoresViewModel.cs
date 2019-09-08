using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Globalwarmin.ViewModels
{
    public class HighScoresViewModel
    {
        public string UserName { get; set; }

        public string QuizName { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }
    }
}