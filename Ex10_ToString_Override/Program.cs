using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10_ToString_Override
{
    // 1. 사용자가 만드는 모든 클래스는 기본적으로 Object를 상속받는다
    // 2. FrameWork가 제공하는 수많은 클래스도 Object를 기본적으로 상속받고 필요에 따라 재정의를 구현하고 있다.

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return $"Person : {Name}  - {Age}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person() { Name = "Smith", Age = 12 };
            // ToString()을 재정의 안했을 때        -- > Object의 ToString()을 그대로 사용한 경우
            //Console.WriteLine(person.ToString()); // Ex10_ToString_Override.Person 
            //Console.WriteLine(person);            // Ex10_ToString_Override.Person --> ToString()을 안해줘도 이렇게할 때 기본적으로 붙어있음.

            // ToString()을 재정의 했을 때         -- > Object의 ToString()을 Override 한 경우
            Console.WriteLine(person.ToString());   // Person : Smith-12    // 개발자가 목적에 따른 출력(재정의) -> 개발자가 별도의 print 함수를 안만들고 오버로딩해서 가장 많이 사용함.
            Console.WriteLine(person);              // Person : Smith-12
        }
    }
}
