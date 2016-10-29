using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数字:");
            string str = Console.ReadLine();
            if (!string.IsNullOrEmpty(str))
            {
               List<int> backlist= getInts(Convert.ToInt32(str.Trim()));
                if (backlist.Count>0)
                {
                    Console.WriteLine(str+"的质因数为:"+string.Join("*",backlist));
                }
                Console.WriteLine("输出完成,请输入:");
                Console.ReadLine();
            }
        }

        private static List<int> getInts(int aa)
        {
            List<int> ints = new List<int>();
            for (int i = 2; i < aa; i++)
            {
                while (aa != i)
                {
                    if (aa%i != 0) //不能被整除的都不是 质数
                    {
                        break;
                    }
                    ints.Add(i);
                    aa = aa/i;
                }
            }
            ints.Add(aa);
            return ints;
        }

        public void testfunction()
        {

        }
    }
}
