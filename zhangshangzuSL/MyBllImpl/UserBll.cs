using MyIBll;
using System;

namespace MyBllImpl
{
    public class UserBll : IUserBll
    {
       public  void AddNew(string username, string pwd)
        {
            Console.WriteLine("新增用户.username="+username);
        }

        public bool Check(string username, string pwd)
        {
            Console.WriteLine("检查登陆.username=" + username);
            return true;
        }
    }
}
