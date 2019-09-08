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

        void CreateQuestion(Question _question);

        Question GetQuestionById(int id);

        IList<int> GetQuestionByQuizId(int id);

        int GetNextID();

        void UpdateQuestion(Question question);

        void DeleteQuestion(int id);

    }
}
