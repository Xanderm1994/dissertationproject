using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;

namespace Global.Services.IService
{
    public interface IContentService
    {
        IList<Content> GetContents();
        void CreateContent(Content content);
        IList<Content> GetContentAz();
        Content GetContentById(int id);
        void UpdateContent(Content content);
        void makelink(QuizContentLink link);
        IList<Quiz> GetQuizzesByContentId(int id);
    }
}
