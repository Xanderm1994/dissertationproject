using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;
namespace Global.Services.IService
{
   public interface IQuizService
    {
        IList<Quiz> GetQuizs();
    }
}
