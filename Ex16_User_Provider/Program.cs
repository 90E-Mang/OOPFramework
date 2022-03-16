using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex16_User_Provider
{
    /*
      객체간의 관계
      상속 & 포함
      
      포함 Part
      
      User : 사용자 (제공 받은 걸 사용하는 class)
      Provider : 제공자(어떤 클래스에 자신을 제공하는 class)
      
      class A{}
      calss B{}
      관계 :  A는 B를 사용합니다.
      
      1. 상속 => A : B{}
      2. 포함 => A라는 클래스 안에서 Member field로 B를 사용 --> class A{ B b;}
      2.1 포함 관계 안에서 부분과 전체로 나뉜다.(생성과 소멸을 같이 하는가 ? or 따로 할거냐?)
      
      class B{}
      
      class A{
           B b;    <- 포함( A는 B를 사용합니다)
           A() {
             b = new B();       
           }
      }
      >>> 1. B는 독자적으로 생성된 것이 아니고 A 객체가 생성될 때 B가 같이 생성됨.
      ex) A a = new A(); --> 이렇게 되면 A와 life Cycle이 같다. A와 B는 운명 공동체가 됨. 이게 전체(Composition)
      
      -----------------------------------------------------
      
      class B{}
      
      class A{
       B b; // 포함 (A는 B를 사용합니다)
       A(){}
       A(B b){
        this.b = b;
      }
       void method(B b){
         this.b = b;
       }
     }
      >> Main(){B b = new B();  A a = new A(b); }
      >> 서로 다른 운명   이게 부분(LifeCycle이 다르다.)
      ------------------------------------------------------------
      의존관계(dependency) : 함수를 기반으로(함수 안에서 생성, 전달, ... ) 작업.
      class B{}
      class A{
        **member field로 B 타입 변수를 가지지 않는 것. **
        ** 함수를 기반으로 움직임**
        void print(){
          B b = new B();
          return b;
        }
      }
      
      활용사례
      
      interface Icall{ void m();}
      
      class C : Icall{
         // 반드시 재정의
         public void m(){}
      }
      class D : Icall{
         // 반드시 재정의
         public void m(){}
      }
      
      ** 현대적인 프로그램 방식은 유연한 방식(비교적 대충)을 추구함
      
      class E{
         void method(Icall ic){        // 이러한 방식을 짠게 좋은 코드 ! why? Icall을 구현한 C도 가능 D도 가능하니까 !
             
         }
         
         void method2(C c){        // 여긴 C객체 주소만 올 수 있음.
         }
         
         void method3(D d){        // 여긴 D객체 주소만 올 수 있음.
         }
      }
      
     */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
