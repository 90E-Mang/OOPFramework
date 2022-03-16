using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12_Abstract_Class
{
    /*
     * 1. 추상 클래스 (미완성 클래스)
     * 1-1 미완성 (완성 + 미완성) >> 함수를 구현(중괄호 블럭을 가지고 있다) 했는가 하지 않았는가(중괄호 블럭이 없다 = 실행블럭이 없다)?
     * 
     * 2. 추상 클래스의 목적 : 상속관계에서 자식 클래스가 강제적으로 함수를 구현하게 하는 것이 목적이다.
     * 3. 특징 :  (1) 스스로 객체 생성불가 
     *           (2) 상속관계에서 구현 
     *           (3) abstract method를 반드시 구현해야 한다.
     *           (4) abstract method는 적든 안적든 무조건 virtual 이다(자동 virtual) -> 반드시 override로 구현 !(재정의)
     *           (5) C#은 abstract property{get; set;}도 가지고 있다. 구현은 추상함수와 동일(그런데 추상 property는 잘 안쓴다)
     * 
     */
    abstract class AbstractClass
    {
        public void print()
        {
            Console.WriteLine("완성된 코드....");
        }
        public abstract void abMethod();  // 실행 블럭이 없음 !! >> 상속관계에서 강제적 구현을 목적 !
    }
    class Dummy : AbstractClass
    {
        public override void abMethod()     // 강제 구현 >> 실행블럭 만들기
        {
            Console.WriteLine("추상 메서드 구현");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dummy dummy = new Dummy();
            dummy.abMethod();
            dummy.print();
        }
    }
}
