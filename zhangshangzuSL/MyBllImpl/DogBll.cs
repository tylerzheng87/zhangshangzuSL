
using MyIBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBllImpl
{
    public class DogBll : IDogBll
    {
        void IDogBll.Bark()
        {
            Console.WriteLine("wangwangwang");
        }
    }
}
