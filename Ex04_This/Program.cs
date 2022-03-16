using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04_This
{
    // 객체 자신을 가리키는 this(앞으로 생성될 객체의 주소를 가진다는 가정하에 움직이는 keyword)
    // 사용처 : 주로 member field와 parameter를 구분하기 위해서 
    // 관용적으로 [함수 parameter 이름]과 [member field 이름]을 동일하게 쓴다. <- 그럼 충돌 아니냐? 

    class ThisSelf
    {
        private string name;
        private int age;

        /*
         * 할당이라는 측면에서 바라보면 ....
        public ThisSelf() 
        {
            this.name = "홍길동";      1개
            this.age = 0;
        }
        public ThisSelf(string name)        // 충돌이 아니고 이렇게 name이라고 사용하면 member field name에 할당 될거라도 유추할 수 있다.
        {   // this를 써서 member field라고 나타내서 구분한다 !
            this.name = name;           2개
            this.age = 0;
        }
        public ThisSelf(string name, int age)
        {
            this.name = name;           3개
            this.age = age;
        }
        */                              // 이렇게 3개씩이나 할당을 가지고 있다.

        // 아래처럼 보자 !
        public ThisSelf() : this("홍길동")     // 이렇게 쓴다면 생성자마다 하지 않고 아래로 점점 내려가면서 채워진다 !
        {
            Console.WriteLine("매개변수가 없긔");
        }
        public ThisSelf(string name) : this(name, 0)       // 위에서 내려오면 여길 보고 
        {   // name 사용하면 ..  member field name 할당될거다 !
            Console.WriteLine("매개변수가 하나 있네?");
        }
        public ThisSelf(string name, int age)       // : this() 가 없는 마지막으로 내려와서 최종적으로 할당됨.
        {
            // 여기서 멤버필드에 대한 할당을 한번만 한다 ! 반복적인 코드를 줄인다.
            this.name = name;
            this.age = age;
            Console.WriteLine($"매개변수가 두개 : {this.name},{this.age}");
        }
    }
    class Shape
    { //공통속성 , 공통함수
        public string color = "gold";
        public virtual void draw()
        {
            Console.WriteLine("도형을 그리다");
        }
    }
    class Point
    {
        public int x; //public 은 아니지만 출력해볼려고 잠시 .... 원칙 : private
        public int y;

        public Point() : this(1, 1)
        { //기본점  //안 좋아 보여요 (할당 2번) 추후에  this() 생성자 호출 할당 1개 줄인다

        }
        public Point(int x, int y)
        {  //원하는 점
            this.x = x;
            this.y = y;
        }
    }
    class Circle : Shape
    { //상속
        private Point point; //포함 (다른 클래스 타입을 member field 로 가지는 것) ******
        private int r; //특수화

        //문제점 : 각각의 생성자에 member field 에 할당 작업을 반복적으로 하고 있다 .... 고민.....
        //답안지 : this 

        public Circle() : this(10, new Point(10, 15))
        {

        }

        public Circle(int r, Point point)
        {
            this.r = r;
            this.point = point;
        }

        public void circlePrint()
        {
            Console.WriteLine("반지름 : {0} , 좌표값 : {1},{2}", r, point.x, point.y);
        }
        public override void draw()
        {
            Console.WriteLine("원을 그리다");
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            // ThisSelf ThisSelf = new ThisSelf();
            // 원칙적으로 생성자 함수는 객체 생성시 1개만 호출
            // 예외적으로 내부적으로 this() 구현한다면 여러개의 생성자 호출 가능
            // ThisSelf ThisSelf = new ThisSelf("이맹기");
            ThisSelf ThisSelf = new ThisSelf("이맹기",33);

            Circle c = new Circle();
            c.draw();
        }
    }
}
