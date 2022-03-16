using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13_Abstract_Class
{
    abstract class EmptyCan
    {
        public int count;
        public abstract int Count // 강제 구현(property)
        {
            get;        // return 구현
            set;        // value parameter를 사용해서 구현
        }
        public void speak()
        {
            Console.WriteLine("Speak!!");
        }

        public abstract void sound();   // 강제 구현
        public abstract void who();     // 강제 구현
    }
    class BeerCan : EmptyCan
    {
        public override int Count 
        {
            get { return this.count; }
            set { this.count = value; } 
        }
        public override void sound()
        {
            Console.WriteLine("깡깡깡깡!!.....");
        }
        public override void who()
        {
            Console.WriteLine("이맹기");
        }
    }
    class CiderCan : EmptyCan
    {
        public override int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }
        public override void sound()
        {
            Console.WriteLine("통통통통!.....");
        }
        public override void who()
        {
            Console.WriteLine("개김치");
        }

        // 필요하다면 함수 더 구현 (개발자마음)
        public void where()
        {
            Console.WriteLine("공원에서 .... ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BeerCan beerCan = new BeerCan();
            beerCan.speak();
            beerCan.sound();
            beerCan.who();

            CiderCan ciderCan = new CiderCan();
            ciderCan.speak();
            ciderCan.sound();
            ciderCan.who();
            ciderCan.where();
        }
    }
}
