using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15_Abstract_Interface
{
    /* 추상클래스와 인터페이스의 공통점
     * 1. 강제적 구현을 목적으로 한다
     * 2. 상속을 목적으로 한다.
     * 3. 스스로 객체 생성을 할 수 없다.
     * 4. 다형성 (캐스팅)
     * 
     * 차이점
     * 
     * 추상클래스
     * 단일 상속
     * member field를 가질 수 있다.
     * 일반 함수를 가질 수 있다.
     * 
     * 인터페이스
     * 다중 상속
     * member field를 가질 수 없다.
     * 구현코드를 가질 수 없다.
     * 
     */

    /*
     * 게임(unit)
     * unit 의 공통기능 (이동좌표, 이동, 멈춘다) : 추상화, 일반화된 자원
     * unit은 이동 방법은 다르다.(이동 방법은 unit마다 별도로 강제구현)
     * 
     */
    abstract class Unit
    {
        protected int x, y;

        public void stop()
        {
            Console.WriteLine("Unit stop");
        }
        public abstract void move(int x, int y);
    }
    class Tank : Unit
    {
        public override void move(int x, int y)
        {
            Console.WriteLine($"Tank 이동 : {this.x},{this.y}");
        }

        // Tank 특수화, 구체화
        public void changeMode()
        {
            Console.WriteLine("Tank Siege Mode");
        }
    }
    class Marine : Unit
    {
        public override void move(int x, int y)
        {
            Console.WriteLine($"Marine 이동 : {this.x},{this.y}");
        }

        // Tank 특수화, 구체화
        public void stimPack()
        {
            Console.WriteLine("스팀팩기능");
        }
    }
    class DropShip : Unit
    {
        public override void move(int x, int y)
        {
            Console.WriteLine($"DropShip 이동 : {this.x},{this.y}");
        }

        // Tank 특수화, 구체화
        public void load()
        {
            Console.WriteLine("Unit load ....");
        }
        public void Unload()
        {
            Console.WriteLine("Unit Unload ....");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Tank tank = new Tank();
            //tank.move(1,2);
            //tank.changeMode();
            //
            //Marine marine = new Marine();
            //marine.move(200, 500);
            //marine.stop();
            //marine.stimPack();

            // 탱크 3대를 만들고 [같은좌표]로 이동시키세요. (객체 배열)

            // Tank[] tankList = {new Tank(), new Tank(), new Tank() };
            // foreach (Tank t in tankList)
            // {
            //     t.move(555, 444);
            // }

            // 여러개의 Unit(Tank 1, Marine 1, Dropship 1)을 만들고 같은 좌표로 이동시키세요
            // 다형성
            // 전자제품 매장 case(Buy 함수에 product 타입으로 받는 것 처럼)
            Unit[] unitlist = {new Tank(), new Marine(), new DropShip() };
            foreach (Unit temp in unitlist)
            {
                temp.move(888, 999);
            }
        }
    }
}
