using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_Indexer
{
    class MyClass
    {
        private const int MAX = 10;
        private string name;

        // 내부의 정수 배열 데이타
        private int[] data = new int[MAX];

        // 인덱서 정의. int 파라미터 사용
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= MAX)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    // 정수배열로부터 값 리턴
                    return data[index];
                }
            }
            set
            {
                if (!(index < 0 || index >= MAX))
                {
                    // 정수배열에 값 저장
                    data[index] = value;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myclass = new MyClass();

            myclass[0] = 1111; // indexer set 처리
            int result = myclass[0]; // indexter get 처리
            Console.WriteLine($"result : {result}");
        }
    }
}
