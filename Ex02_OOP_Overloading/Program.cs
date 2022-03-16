using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_OOP_Overloading
{
    // 함수 : (생성자 함수, 일반함수)
    // 생성자 overloading도 쌉가능

    class Test
    {
        private string name;
        private int age;
        public Test() { }   // default constructor(기본 생성자)
        public Test(string name) { }    // 오버로딩 생성자
        public Test(string name, int age) { }   // 역시 오버로딩 생성자

        // 클래스에 생성사 오버로딩이 많다는 것의 의미??
        // ㄴ> 옵션이 많다는 의미.
        // ex. 자동차 영업소 방문....]
        // 기본형, 옵션 1, 옵션 2, 옵션 3..... 변수의 초기화를 통해서 설정...

        // 편하게
        // 개발자 종류별 함수를 모두 외워야댐(intPrint, stringPrint... 이런식으로 개별로 이름 다 다르게 하면)
        // 그래서 아래쪽처럼 기능이 비슷하고 parameter가 다른 함수들은 메서드 오버로딩으로 함.
        public void Print()     // method overloading
        {

        }
        public void Print(int i)
        {

        }
        public void Print(string s)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Test test2 = new Test("기본값");
            Test test3 = new Test("기보온",100);

            test.Print(10);
            test.Print("다댐");
            test.Print();
        }
    }
}
