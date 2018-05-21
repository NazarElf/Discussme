using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Discussme.BLL.DbObjects
{
    //Data that is needed to login user
    class LoginData
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
