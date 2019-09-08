using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Global.Data;

namespace Globalwarmin.ViewModels
{
    public class ManageContentViewModel
    {
       public Content content { get; set; }
       public IList<Quiz> quizlist { get; set; }
        public QuizContentLink link { get; set; }
    }
}