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
        private GlobalEntities _Database;

        public ContentDAO()
        {
            _Database = new GlobalEntities();

        }

        public IList<Content> GetContents()
        {
            IQueryable<Content> _content;

            _content = from content in _Database.Content select content;
            return _content.ToList<Content>();
        }
        public void CreateContent(Content _content)
        {
            _Database.Content.Add(_content);
            _Database.SaveChanges();
        }

    }
}