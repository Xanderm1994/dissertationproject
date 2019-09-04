using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;
using Global.Data.IDAO;
using Global.Data.DAO;
using Global.services.Iservice;
namespace Global.services.Service
{
    public class contentservice : IContentService
    {
        private IContentDAO _contentdao;

        public contentservice()
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

    }
}
