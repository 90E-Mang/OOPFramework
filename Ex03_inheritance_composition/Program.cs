using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_inheritance_composition
{
    /*
     * 실제 개발환경에서 업무가 복잡함(도메인 지식)
     * 쇼핑몰을 만든다고 한다면 ?
     * 
     * 회원관리, 주문관리, 상품관리, 배송관리 ..... 각각의 업무 독립적 것보다는 관계를 가지고 있다.
     * 
     * 여러개의 설계도는 관계를 가져야 한다.
     * 
     * 1. 상속(is ~ a) x은 ~ 이다 명제가 성립되면 90% 상속을 통해서 구현하면 됨(원은 도형이다, 이맹기는 동물이다 등)
     * 2. 포함(has ~ a) x은 ~을 가지고 있다. (자동차는 엔진을 가지고 있다, 경찰은 권총을 가지고 있다 등)
     * 
     * 원 - 도형간의 관계
     * 원은 도형이다.
     * 
     * 원과 점과의 관계 ???
     * 원은 점이다 ??? X
     * 원은 점을 가지고 있다 O
     * class 원 { 점 자원을 가지고 있다 }
     * 
     * 경찰 - 권총의 관계
     * 
     * 경찰은 권총을 가지고 있다 O
     * class police{ 권총 자원을 가지고 있다}
     * 
     * ex) 원, 삼각형, 사각형 설계도 제작
     * ex) 도형
     * 
     * 원은 도형이다
     * 삼각형은 도형이다
     * 사각형은 도형이다.
     * 
     * 도형 : 추상화, 일반화 : 그리다, 색상 >> 공통자원
     * (원, 삼각형, 사각형의 공통분모)
     * 원 : 구체화, 특수화 (반지름, 한점) >> 본인만이 가지능 특징 >> 한점은 x,y좌표로 나눠짐 >> 부품속성
     * class Shape {색상, 그리다} >> 부모 역할
     * class Point {죄표값} >> 부품 >> 포함
     * 
     * 
     * class Circle : Shape { Point, 나머지는 특수하고 구체화된 것만 구현 }
     * 
     */
    class Shape     // 공통속성, 공통함수
    {
        public string color = "gold";
        public void draw()
        {
            Console.WriteLine("도형을 그리다");
        }
    }
    class Point
    {
        public int x;
        public int y;

        public Point() // 기본점 // 사실 이런 형태는 안좋은 형태의 코드,(할당을 2번하기 때문에)
        {               // 추후에 this() 생성자 호출 할당 1개 줄인다.
            x = 1;
            y = 1;
        }
        public Point(int x, int y) // 원하는 점
        {
            this.x = x;
            this.y = y;
        }
    }

    // 문제
    // 원을 만드세요(원의 정의 : 원은 한 점과 반지름을 가지고 있다.
    // 1. 원은 도형이다
    // 2. 원은 점을 가지고 있다.
    // 3. 원은 반지름을 가지고 있다(특수성)
    // 3.1 원의 반지름은 초기값 10을 가지고 있다.
    // 3.2 점의 좌표는 초기값 (10, 15) 가지고 있다.
    // 기본 (초기값)을 설정하지 않으면 반지름과 점의 값을 입력받을 수 있다.(원이 만들어 질때)

    // shape, point 클래스 활용
    class Circle : Shape    // 상속
    {
        Point point; // 포함(중요!!!) ******* (다른 클래스 타입을 member field로 가지는 것) *******
        int radius;
        public Circle()
        {
            this.radius = 10;
            this.point = new Point(10, 15);
        }
        public Circle(int radius, Point point) // 여기서 Point의 주소값을 parameter로 안쓰고 걍 int 2개로 받으면 예측이 안된다. 코드는 예측할 수 있게 적자.
        {
            this.radius = radius;
            this.point = point;
        }

        public void CirclePrint()
        {
            Console.WriteLine($"반지름 : {radius}, 좌표값 : {point.x},{point.y}");
        }
    }

    // 문제2)
    // 삼각형 클래스를 만드세요
    // 삼각형의 정의는 [3개의 점]과 색상과 그리다는 기능을 가지고 있다.
    // Shape, Point 클래스는 제공을 받는다
    // default 값으로 삼각형을 그릴 수 있고, 3개의 좌표값 모두를 입력받아서 삼각형을 그릴 수 있다.

    class Triangle : Shape
    {
        //Point Point;    // 변형이 필요 이거는 점 1개
        Point[] point;      // 점 3개 배열로 해보자

        public Triangle()
        {
            this.point = new Point[3] {new Point(1,2),new Point(3,4), new Point(5,6)};
            //for (int i = 0; i < point.Length; i++)
            //{
            //    point[i] = new Point(i,i+1);
            //}
        }
        public Triangle(Point[] point)
        {
            this.point = point;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle();
            c.draw();
            c.CirclePrint();

            // 내가 반지름과 좌표값을 넣고 싶으면???
            //Point p = new Point(7,6);
            //Circle c2 = new Circle(5, p);  --> 이렇게 하면 길고 없어보임.. p가 안쓰이는 경우
            //c.draw();

            // 이렇게 해보자
            Circle c2 = new Circle(5, new Point(6,9));
            c2.draw();
            c2.CirclePrint();

            Triangle t1 = new Triangle();
            // t2의 경우는 한번만 쓸때 하는거 배열을 선언하지 않았기 때문에 재사용 x
            Triangle t2 = new Triangle(new Point[] {new Point(5,6),new Point(7,8),new Point(9,10)});

            // t3의 경우 배열을 선언해서 배열 값을 바꿔서 재사용할 수 있음.
            Point[] pointarray = new Point[] {new Point(11,12),new Point(13,14),new Point(15,16)};
            Triangle t3 = new Triangle(pointarray);

            // t2 와 t3은 상황에 따라서 맞게 쓰자
        }
    }
}
/*      상속의 진정한 의미 ??? -> 재사용성 (부모)
 *      상속은 좋은 것일까 ? -> 무조건 옳지 않음. 초기 설계 비용이 큼, 상속(부모 자식 관계) ... > 현대에 interface를 활용한 느슨한 관계를 선호
 *      
 * 
 */