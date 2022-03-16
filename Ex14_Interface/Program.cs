using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14_Interface
{
    /*
     * Interface : 표준, 약속, 규칙, 규약을 만드는 행위
     * 1. 소프트웨어 설계의 최상위 단계 --> 과장급 레벨에서 만듦
     * 2. ex) 게임을 만든다 >> run() 달린다, move(int x, int y) 이동 ... -> 표준
     * 
     * 그럼 초급 개발자는 뭘 하는가>??
     * 1. 인터페이스를 [다형성] 입장에서 접근하고 사용함(Interface를 부모타입으로 놓고 씀)
     * 2. 서로 연관성이 없는 클래스를 하나로 묶어주는 기능(같은 부모를 가지게)
     * 3. C#이 제공하는 수많은 API(특히 Collection) >> 인터페이스 활용 >> 사용방법에 집중 !! >> 다형성 !
     * 4. 첫글자 I + ~able로 만듦('~할 수 있는'의 의미로 접근)
     * 5. 객체간 연결 고리(객체간 소통의 통로) >> 다형성
     * 
     * 문법)
     * 1. 인터페이스는 모든 member가 구현부를 가지지 않는다.
     * 2. 인터페이스는 상속을 통한 강제 구현을 목적으로 한다.
     * 3. 모든 접근자는 public(protected).... 코드에서 사용할 필요가 없다.(생략됨)
     * 4. member field를 가지지 않는다.
     * 5. 유일하게 다중상속을 지원함.(여러개의 약속, 규약을 강제 구현.... >> 인터페이스는 작은 단위로 설계)
     */

    interface Ia        // 관용적으로 첫글자 I, 마지막에 able을 붙여만든다 ex) Irunable, Icloneable...)
    {
        //default public
        void m();   // 이렇게 만들면 자동으로 public이고 virtual 이다.
        int Count       // 자동 public virtual, 강제로 property get을 구현하도록
        {
            get;
        }
    }
    interface Ib
    {
        void m2();
    }
    abstract class abClass  // 완성된 자원 + 미완성된 자원
    {
        public void run()   // 완성된 자원
        {

        }
        public abstract void Move();    // 미완성된 자원
    }
    // java에서는 ... -> class extemds AbClass implements, Ia, Ib
    // C# >> :
    class Child : abClass, Ia, Ib
    {
        public override void Move()     // 추상 클래스의 추상 함수 구현
        {
            Console.WriteLine("abClass.move()");
        }
        public int Count // 인터페이스 Ia의 추상 property를 구현
        {
            get { return 100; }
        }
        public void m()     // 어차피 구현이기 때문에 override 키워드를 빼고 구현함.
        {
            Console.WriteLine("Ia.m()");
        }
        public void m2()     // 어차피 구현이기 때문에 override 키워드를 빼고 구현함.
        {
            Console.WriteLine("Ib.m()");
        }
    }

    #region
    // 인터페이스
    // 4. 첫글자 I + ~able로 만듦('~할 수 있는'의 의미로 접근)
    // 5. 객체간 연결 고리(객체간 소통의 통로) >> 다형성
    
    interface Irepairable       // 수리할 수 있는 이라는 하나의 의미로 묶어줌 !!!!
    {

    }
    class Unit
    {
        public int hitpoint;    // 기본 에너지
        public readonly int MAX_HP;   // 최대 에너지 

        public Unit(int hp)
        {
            this.MAX_HP = hp;
        }
    }

    // 지상유닛
    class GroundUnit : Unit
    {
        public GroundUnit(int hp)  : base(hp)       // Unit 생성자 호출(부모)
        {

        }
    }
    class Tank : GroundUnit,Irepairable         // Irepairable이 부모타입이 된다 !
    {
        public Tank() : base(150)
        {

        }
        public override string ToString()
        {
            return "Tank";
        }
    }
    class Marine : GroundUnit
    {
        public Marine() : base(40)
        {

        }
        public override string ToString()
        {
            return "Marine";
        }
    }
    class SCV : GroundUnit, Irepairable
    {
        public SCV() : base(60)
        {

        }
        public override string ToString()
        {
            return "SCV";
        }

        // 수리하다
        // SCV만의 구체화되고 특수화된 기능
        // Repair
        // Repair의 대상 : SCV, Tank, CommendCenter
        // 그렇다고 개별로 아래처럼 함수 다 생성하면 또 중복코드가 미친듯이 발생하는 문제.
        //public void Repair(Tank t)
        //{
        //    if (t.hitpoint != t.MAX_HP)
        //    {
        //        t.hitpoint += 5;
        //    }
        //}
        //public void Repair(SCV s)
        //{
        //
        //
        //}
        //public void Repair(CommendCenter c)
        //{
        //
        //}
        /* 문제점
         * 1. Unit 개수가 증가하면 repair 함수의 개수도 같이 증가한다
         * 2. 한개의 repair 모든 수리를 하고 싶다.
         * ex) public void Repair(Unit u){} 로 하면 되지 않느냐? //SCV 가능, Tank 가능, 근데 CommendCenter는 유닛이 아닌데??? Marine은 리페어 대상도 아닌데??
         * Marine의 경우를 고려하면 ... public void Repair(GroundUnit u){}할려고 보니 마린은 GroundUnit....
         * 
         * Marine, SCV, Tank, CommendCenter -> 서로 연관성이 없다.
         * 서로 연관성이 없는 자원들을 묶어주기? --> 연관성을 수리가능 여부를 가지고 인터페이스로 가자 
         * ㄴ> 수리 가능한, 수리할 수 있는 (~able) --> Irepairable !
         * class Tank : GroundUnit, Irepairable  class SCV : GroundUnit, Irepairable  class CommendCenter : Irepairable
         * 
         */
        public void Repair(Irepairable repairunit)  // Irepairable 부모타입 : SCV, Tank, CommendCenter의 부모 !
        {
            // 수리하는 방법(Hp)...
            // CommendCenter는 Unit이 아니라 HP가 다름 !.. 수리하는 방법이 혼자 다르다 ㅠㅠ
            // repairunit이 뭔지 판단해서 로직을 다르게 가져가야된다.
            //Unit unit = (Unit)repairunit;       // 다운캐스팅, 그러나 이 코드에 CommendCenter가 들어오는 순간 뻗는다. 그렇다면 어떻게 해결?
            //if (unit.hitpoint != unit.MAX_HP)
            //{
            //    unit.hitpoint += 5;
            //}
            // hint) 타입비교
            if (repairunit.GetType().ToString() == "Unit")
            {            
                Unit unit = (Unit)repairunit;
                if (unit.hitpoint != unit.MAX_HP)
                {
                    unit.hitpoint += 5;
                }
            }
            else
            {
                CommendCenter center = (CommendCenter)repairunit;
                if (center.hitpoint != center.MAX_HP)
                {
                    center.hitpoint += 20;
                }
            }
        }
    }
    // 공중유닛
    class AirUnit : Unit
    {
        public AirUnit(int hp) : base(hp)           // Unit 생성자 호출(부모)
        {

        }
    }

    // 건물
    class CommendCenter : Irepairable
    {
        public int hitpoint;    // 기본 에너지
        public readonly int MAX_HP;   // 최대 에너지
        public CommendCenter(int hp)
        {
            this.MAX_HP = hp;
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            child.m();
            child.m2();
            child.Move();
            Console.WriteLine(child.Count);
        }
    }
}
