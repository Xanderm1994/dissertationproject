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

    }
}