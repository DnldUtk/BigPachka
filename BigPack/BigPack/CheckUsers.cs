using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigPack
{
    public class CheckUsers
    {
        public string login { get; set; }
        public bool isUser { get; set; } 
        public bool isAdmin { get; set; }
        public bool isMaster { get; set; }

        public CheckUsers(string Login, bool IsUser, bool IsAdmin, bool IsMaster)
        {
            login = Login.Trim();
            isUser = IsUser;
            isAdmin = IsAdmin;
            isMaster = IsMaster;
        }
    }
}
