using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data.IDAO;
namespace Global.Data.DAO
{
    public class ContentDAO : IContentDAO
    {
        private GwEntities _Database;

        public ContentDAO()
        {
            _Database = new GwEntities();

        }

        public IList<Content> GetContents()
        {
            IQueryable<Content> _content;
            _content = from content in _Database.Contents select content;
            return _content.ToList<Content>();
        }
        public void CreateContent(Content _content)
        {
            _Database.Contents.Add(_content);
            _Database.SaveChanges();
        }
        public IList<Content> GetContentAz()
        {
            IQueryable<Content> _content;
            _content = from content in _Database.Contents orderby content.Title ascending select content;
            return _content.ToList<Content>();
        }

        public Content GetContentById(int id)
        {
            IQueryable<Content> _content;
            _content = from content in _Database.Contents where content.ContentId == id select content;
            return _content.First();
        }

        public void UpdateContent(Content content)
        {
            _Database.Entry(content).State = System.Data.Entity.EntityState.Modified;
            _Database.SaveChanges();

        }

        public void makelink(QuizContentLink link)
        {
            link.LinkId = GetNextLinkID();
            _Database.QuizContentLinks.Add(link);
            _Database.SaveChanges();
        }
        public int GetNextLinkID()
        {
            IQueryable<int> id;

            id = from dblink
                 in _Database.QuizContentLinks
                 orderby dblink.LinkId descending
                 select dblink.LinkId;

            return (id.First()) + 1;
        }
        public IList<Quiz> GetQuizzesByContentId(int id)
        {
            IQueryable<int> quizids;

            quizids = from dblink
                 in _Database.QuizContentLinks
                 where dblink.ContentId == id
                 select dblink.QuizId;

            IList<Quiz> quizzes = new List<Quiz>();
            foreach(int ID in quizids)
            {
                quizzes.Add(getQuiz(ID));
            }

            return quizzes;
        }

        public Quiz getQuiz(int id)
        {
            IQueryable<Quiz> quizzes = from quz in _Database.Quizs where quz.QuizID == id select quz;

            return quizzes.First();
        }

    }



}
