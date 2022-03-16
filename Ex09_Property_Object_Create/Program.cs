using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09_Property_Object_Create
{
    // 아래 클래스는 생성자가 없다.
    // 대신 Property를 통해서 객체 생성시 초기화 작업이 가능하다.
    /*
     * 
     * 객체를 생성할 때 각 필드를 초기화하는 다른 방법입니다.
     * 클래스이름 인스턴스 = new 클래스이름(){프로퍼티1 = 값, 프로퍼티2 = 값, 프로퍼티3 = 값};
     */
    class BirthdayInfo
    {
        public string Name
        {
            get;
            set;
        }
        public DateTime Birthday
        {
            get;
            set;
        }
        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BirthdayInfo birthinfo = new BirthdayInfo()
            {
                Name = "이맹기",
                Birthday = new DateTime(1990, 9, 9)
            };
            // 위의 property를 이용한 방식으로 객체의 field를 초기화 하는 방법을 반드시 알아두자(WEB에서 존나게 쓰임)  

            Console.WriteLine($"Name : {birthinfo.Name}");
            Console.WriteLine($"Birthday : {birthinfo.Birthday}");
            Console.WriteLine($"Age : {birthinfo.Age}");
        }
    }    
}
