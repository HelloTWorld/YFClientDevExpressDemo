using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YFClientDevExpressDemo.User
{
    class User
    {
        private static string id;

        public static string Id
        {
            get { return User.id; }
            set { User.id = value; }
        }

        private static string password;

        public static string Password
        {
            get { return User.password; }
            set { User.password = value; }
        }
        private static string userName;

        public static string UserName
        {
            get { return User.userName; }
            set { User.userName = value; }
        }
    }
}
