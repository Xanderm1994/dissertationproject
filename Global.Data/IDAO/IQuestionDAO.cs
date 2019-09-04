using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;

namespace Global.Data.IDAO
{
    public interface IQuestionDAO
    {
        IList<Question> GetAllQuestions();
    }
}
