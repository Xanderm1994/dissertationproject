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
    public class ContentService : IContentService
    {
        private IContentDAO _contentdao;

        public ContentService()
        {
            _contentdao = new ContentDAO();
        }

        public IList<Content> GetContents()
        {
            return _contentdao.GetContents();
        }
        public void CreateContent(Content content)
        {
             _contentdao.CreateContent(content);
        }
        public IList<Content> GetContentAz()
        {
            return _contentdao.GetContentAz();
        }
        public Content GetContentById(int id)
        {
            return _contentdao.GetContentById(id);
        }
        public void UpdateContent(Content content)
        {
            _contentdao.UpdateContent(content);
        }
        public void makelink(QuizContentLink link)
        {
            _contentdao.makelink(link);
        }
    }
}
