using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_Override
{
    /*
     * [상속관계] 에서 override : 상속관계에서 자식이 부모의 자원(member field or method)을 "재정의" 하는 것 ! 근데 member field는 앵간해서 잘 안함.
     * 상속관계에서 자식클래스가 부모클래스의 method의 내용만 바꾸는 것.
     * 재정의 : 틀의 변화는 없고, 내용만(중괄호 블럭 내) 수정. >> 함수의 이름, 타입을 바꾸는 것이 아님 !!!!!!
     * 1. 부모함수와 이름 동일
     * 2. 부모함수와 parameter 동일
     * 3. 부모함수 return type 형식 동일
     * 4. 실행블럭(중괄호 사이)안쪽 코드만 변경 !!!!!
     * 
     * new('상위 자원 무시하기' 정도로 생각하자), virtual(물려받았으면 재정의를 무조건 해라 : 강한 의지, 부모클래스에서 표시함), override(재정의할때 자식클래스에서 사용)
     * Tip) java는 @override를 함수 바로 윗줄에다 적어주면 댐
     * 
     */
    #region<new 사용>
    public class BaseC
    {
        public int x;
        public void Invoke()
        {
            Console.WriteLine("부모함수");
        }
    }
    public class DerivedC : BaseC
    {
        new public int x = 111;
        new public void Invoke() // new를 빼도 돌아가는데 헷갈리기도 하고 비주얼 스튜디오에서 경고를 줌. 걍 보기좋게 new 적자
        {
            Console.WriteLine("자식함수");
        }
    }
    #endregion
    class Father
    {
        public int Fmoney = 1000;
        public void FPrint()
        {
            Console.WriteLine($"Fmoney : {Fmoney}");
        }
        public virtual void Vprint()        // virtual이 이렇게 붙어 있으면 자식 클래스에서 해라 근데 안해도 되기는 함.... 그래도 앵간하면 해야된다 생각하자 !! 재정의 해야되는 함수 !
        {                                   // 함수명은 그대로 Vprint()인데 자식 클래스에서 재정의를 통해 내용을 달리 바꾼다 !
            Console.WriteLine("부모 함수 Vprint");
        }
    }
    class Child : Father
    {
        public override void Vprint()
        {
            //base.Vprint();
            Console.WriteLine("부모 클래스에서 받은걸 이렇게 재정의 했다 !");
        }
        // 상속관계에서 재정의한 부모 함수를 부르는 유일한 방법 !!
        // base 키워드 !! : 상속관계에서 부모를 가리키는 this 같은 것.
        // 상속관계에서 base를 사용해 부모의 생성자를 호출할 수 있다. -> base();
        // Tip) java에서 키워드는 super
        public void FatherMethod()
        {
            base.Vprint();      // 이렇게 base. 으로 상위자원으로 접근해서 호출 !
        }
    }

    // simple Question
    class Point2        // 한 점을 가지는 클래스
    {
        protected int x = 4;
        protected int y = 5;

        public virtual string getPosition()
        {
            return this.x + ":" + this.y;
        }
    }
    class Point3D : Point2
    {
        protected int z = 6;
        
        // 상속관계에서 안 좋은 방법
        public string getPosition3D()
        {
            return this.x + ":" + this.y;
        }
        // 권장하는 방법 ! 아래처럼 override 하즈아
        public override string getPosition()
        {
            return this.x + ":" + this.y + ":" + this.z;
            // 여기서 this.x + ":" + this.y 대신에 base.getPosition() 쓸 수도 있는데 권장하지 않는 방법임. 유지보수할때 디짐
        }
    }

    //Point3D p = new Point3D();
    //p.getPosition(); >> x,y
    class Program
    {
        static void Main(string[] args)
        {
            DerivedC derivedC = new DerivedC();
            derivedC.Invoke();
            Console.WriteLine(derivedC.x);

            Child child = new Child();
            child.FPrint();
            child.Vprint();             // 자식 클래스에서 재정의 하지 않아도 호출 가능하다. 다만, 부모클래스의 함수가 호출된다.

            // 문제
            // 부모가 정의한 Vprint는 그럼 호출이 안되냐???
            // ㄴ ㄴㄴ 됨. 근데 아무고또 안하고 냅두면 불가능
            // 상속관계에서 객체참조변수는 부모 및 자식 클래스 둘다 바라본다. 더 들어가면 복잡하니 이정도만 생각하자(단, 부모클래스는 private랑 protected만 !)
            // 내부적으로 부모의 함수를 먼저 봄. 근데 virtual 키워드가 박혀있으면 자식클래스로 집어던짐.

            // 상속관계에서는 부모가 먼저 heap에 올라가고 따라서 자식이 올라감
            // child 타입은 heap 메모리에 있는 father 객체와 child 객체 둘다 접근이 가능하다.(상속)
            // 부모가 가지는 함수를 자식이 재정의 했다면 .... child 입장에선 재정의 하기 전의 부모쪽 자원을 볼 수 없다.

            // ********다형성*********
            // 부모타입은 자식타입의 주소를 가질 수 있다.

            Father f = child; // 자식이 가지고 있는 주소를 부모 타입의 f라는 변수에 할당 ! ( 단, 상속관계일때 옆의 코드가 성립함)
                              // ㄴ 그런데 이경우에는 f에 자식의 주소값을 받아왔다고 하더라도 자식클래스를 볼 수 없다 !!!! 근데 virtual 키워드가 있는 부분은 자식으로 던진다 !!(중요함 잘 알아야됨)
                              // ****** 부모타입으로 접근 하더라도 재정의가 되어있다면 자식쪽으로 넘겨버린다 !!! ******(매우 중요 ! 헷갈린다 !!)
            f.Vprint();       // 그래서 f.Vprint()의 결과는 자식클래스의 재정의 된 내용으로 나온다.
            child.FatherMethod();       // 재정의된 부모함수를 부르는 유일한 방법(필기랑 위 클래스 내용을 살펴보자)
        }
    }
}
