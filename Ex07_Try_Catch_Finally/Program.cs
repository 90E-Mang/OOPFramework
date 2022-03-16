using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07_Try_Catch_Finally
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 예외를 강제로
                throw new IndexOutOfRangeException("배열이 문제가 있습니다.");
            }
            catch (Exception e)
            {
                // throw에서 던져준 예외를 확인
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine("***" + e.StackTrace);
                Console.WriteLine("---" + e.ToString());
            }
            finally // 강제로 실행하는 블럭
            {
                Console.WriteLine("Power off");
            }
        }
    }
}
