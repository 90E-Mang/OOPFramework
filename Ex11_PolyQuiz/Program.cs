using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11_PolyQuiz
{
    /*
    시나리오(요구사항)   
    저희는 가전제품 매장 솔루션을 개발하는 사업팀입니다    
    A라는 전자제품 매장이 오픈되면 
    
    [클라이언트 요구사항]    
    가전제품은 제품의 가격 , 제품의 포인트 정보를 공통적으로 가지고 있습니다   
    각각의 가전제품은 제품별 고유한 이름을 가지고 있다
    
    ex)   
    각각의 전자제품은 이름을 가지고 있다(ex: Tv , Audio , Computer)   
    각각의 전자제품은 다른 가격을 가지고 있다(Tv:5000, Audio:6000 ....)   
    제품의 포인트는 가격의 10% 적용한다
        ​    
    시뮬레이션 시나리오
    
    구매자 : 제품을 구매하기 위한 금액정보 , 포인트 정보를 가지고 있다 
    예를 들면 : 10만원 , 포인트 0   
    구매자는 제품을 구매할 수 있다 , 구매행위를 하게되면 가지고 있는 돈은 감소하고 포인트는 올라간다    
    구매자는 처음 초기 금액을 가질 수 있다
    */
    class Product
    {
        public int price;
        public int bonuspoint;
        public Product() { }
        public Product(int price)
        {
            this.price = price;
            this.bonuspoint = (int)(this.price / 10.0);
        }
    }
    class KtTv : Product
    {
        public KtTv() : base(500)       // 상위 생성자를 호출하는 base !
        {

        }

        public override string ToString()   // Object class가 가지는 public virtual 자원
        {
            return "KtTv";
        }

    }
    class Audio : Product
    {
        public Audio() : base(100)
        {

        }

        public override string ToString()
        {
            return "Audio";
        }
    }
    class NoteBook : Product
    {
        public NoteBook() : base(150)
        {

        }

        public override string ToString()
        {
            return "NoteBook";
        }
    }
    //구매자
    class Buyer
    {
        private int money = 1000;
        private int bonuspoint;

        //구매자 구매행위 (기능)
        //구매행위 (잔액 - 제품의 가격 , 포인트 정보 갱신)
        //*************구매자는 매장에 있는 모든 물건을 구매할 수 있다 ***************

        // 각각의 제품을 구매할 수 있는 함수 제공 

        // 모든 전자제품의 부모는 Product (다형성)
        // Product product = new Audio();
        // Product product = new KtTv();
        // Product product = new NoteBook();
        // 단, 이렇게 쓸 수 있더라도 객체참조변수 product는 자식 클래스의 내용은 볼 수 없다. Product class 내용만 볼 수 있다(재정의 된 함수나 자원은 자식으로 감 !!!).

        public void Buy(Product p)
        {
            //함수가 제품 객체의 주소를  parameter  받아서 가격 ,포인트
            if (this.money < p.price)
            {
                Console.WriteLine("고객님 잔액이 부족합니다 ^^! " + this.money);
                return; //함수 종료  (구매행위 종료)
            }
            //실 구매 행위
            this.money -= p.price; //잔액
            this.bonuspoint += p.bonuspoint; //누적
            Console.WriteLine("구매한 물건은 :" + p.ToString());
        }
        //public void KttvBuy(KtTv n) // Tv 객체의 주소를 받음.
        //{  //함수가 제품 객체의 주소를  parameter  받아서 가격 ,포인트
        //    if (this.money < n.price)
        //    {
        //        Console.WriteLine("고객님 잔액이 부족합니다 ^^! " + this.money);
        //        return; //함수 종료  (구매행위 종료)
        //    }
        //    //실 구매 행위
        //    this.money -= n.price; //잔액
        //    this.bonuspoint += n.bonuspoint; //누적
        //    Console.WriteLine("구매한 물건은 :" + n.ToString());
        //}
        //
        //public void AudioBuy(Audio n)
        //{  //함수가 제품 객체의 주소를  parameter  받아서 가격 ,포인트
        //    if (this.money < n.price)
        //    {
        //        Console.WriteLine("고객님 잔액이 부족합니다 ^^! " + this.money);
        //        return; //함수 종료  (구매행위 종료)
        //    }
        //    //실 구매 행위
        //    this.money -= n.price; //잔액
        //    this.bonuspoint += n.bonuspoint; //누적
        //    Console.WriteLine("구매한 물건은 :" + n.ToString());
        //}
        //
        //public void NoteBookBuy(NoteBook n)
        //{  //함수가 제품 객체의 주소를  parameter  받아서 가격 ,포인트
        //    if (this.money < n.price)
        //    {
        //        Console.WriteLine("고객님 잔액이 부족합니다 ^^! " + this.money);
        //        return; //함수 종료  (구매행위 종료)
        //    }
        //    //실 구매 행위
        //    this.money -= n.price; //잔액
        //    this.bonuspoint += n.bonuspoint; //누적
        //    Console.WriteLine("구매한 물건은 :" + n.ToString());
        //}

        // 팀장 : 휴가.... 하와이....
        // .......
        // 물건(전자제품) 1000개 추가 >> POS >> 매장 -- 여기까진 문제가 없는데
        // 사장님 >> 행사 >> 문제터짐
        // >> 이 시스템은 처음부터 3개만 구매하게 만들어놓음.... 나머지 997개는 처리가 안됨 --> 처리하는 함수가 없음....
        // 아주 안좋은 해결 방안 --> 나머지 함수 997개를 다 만듦... --> 이게 가능하냐? 또 2000개 추가되면 어쩔?
        
        // 해결하려면?
        // 어떠한 제품이 들어와도 구매가 가능하도록 해야됨. 단) 모든 제품은 Product를 상속한다는 조건에서 함수의 logic은 동일해야됨.
        // 이걸 기반으로 Buyer class 를 수정하기 

        // hint)
        // Overloading 의 개념을 이해
        // 다형성 개념
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 매장 제품 3개 배치
            KtTv tv = new KtTv();
            Audio audio = new Audio();
            NoteBook notebook = new NoteBook();

            // 고객생성
            Buyer buyer = new Buyer();

            buyer.Buy(tv);
            buyer.Buy(audio);
            buyer.Buy(notebook);
            buyer.Buy(tv);
            // 구매행위
            //buyer.AudioBuy(audio);
            //buyer.NoteBookBuy(notebook);
            //buyer.KttvBuy(tv);
            //buyer.KttvBuy(tv);
            //buyer.KttvBuy(tv);
            //buyer.KttvBuy(tv);
        }
    }
}
