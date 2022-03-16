using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 객체 지향 
 * class == 설계도 == 데이터 타입
 * 
 * 문제점)
 * 설계도 1장이 아니라 여러장이 사용...
 * 
 * 초가집 아님... 방 99칸급 기와집(설계도 1장이상.... 많이 필요)
 * 설계도를 나누는 기준필요
 * 설계도간의 관계 !!!
 * 
 * -> 여러장의 설계도가 있을 때, 관계 (이걸 통해서 구분함)
 * is ~ a (~은 ~이다) : 상속
 * has ~ a (~은 ~를 가지고있다) : 포함
 * 
 * 상속 ....
 * 부모   자식간의 관계...
 * 1. 단일 상속(계층적 상속 - 할아버지 - 아버지 - 나) 
 * 2. 사용자가 만드는 모든 캘리스는 기본적으로 Object(root)를 상속하고 있다.
 * 
 */
namespace Ex01_OOP
{
    class GrandFather  // 굳이 : Object라고 적어서 구현하지 않아도 Object class를 기본적으로 상속한다. 단, 기본적으로 public(Protected) 자원만.
    {
        public int Gmoney = 1000;
        private int Pmoney = 1000000;               // 누구에게도 상속하지 않을 것. private
        protected int Tmoney = 2000;                // protected 접근자 : 상속관계에서만 존재...
        // protected는 양면성이 있음. 상속관계에서는 public, 그렇지 않을 때(참조변수에 .을찍어 볼때)는 private
    }
    class Father : GrandFather  // java에서는 Father extends GrandFather
    {
        public int Fmoney = 500;

        public void print()
        {   // Tmoney 사용 가능
            Console.WriteLine($"Tmoney : {Tmoney}");
        }
    }
    class Child : Father
    {
        public int Cmoney = 100;
        // 할아버지 돈도 내돈, 아버지 돈도 내돈, 내돈도 내돈 !
    }

    sealed class aaa        // 봉인된.... 상속할 수 없는 클래스...
    {

    }

    // 다형성 : overloading (하나의 이름으로 여러가지 기능) >> 함수에만 해당됨.(생성자 함수, 일반함수 다)
    // 함수의 parameter 개수와 타입을 다르게 하여 만드는 방법
    // 목적 : 개발자의 편의성. 즉 성능과는 관계가 없다.
    // 상속과 무관.... 상속이 없어도 잘만 사용됨.
    class Test
    {
        public void method()
        {
            Console.WriteLine("일반함수");
        }

        // 오버로딩
        public void method(int i)
        {
            Console.WriteLine($" i : {i}");
        }
        public void method(string i)
        {
            Console.WriteLine($" i : {i}");
        }
        public void method(int i, int j)
        {
            Console.WriteLine($"i + j = {i+j}");
        }
        
        // Overloading에서 parameter의 순서가 다름을 인정함 !!
        public void method(int i, string s)
        {

        }
        public void method(string s, int i)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            Console.WriteLine($"Gmoney : {child.Gmoney}");
            Console.WriteLine($"Gmoney : {child.Fmoney}");
            Console.WriteLine($"Gmoney : {child.Cmoney}");

            Test t = new Test();
            t.method("ㅋㅋㅋ");
        }
    }
}
