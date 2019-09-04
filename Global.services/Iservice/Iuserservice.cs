using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;
namespace Global.services.Iservice
{
   public  interface Iuserservice 
    {
        IList<User> Getusers();
    }
}
