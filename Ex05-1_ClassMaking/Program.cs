using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_1_ClassMaking
{
    class Sportgame
    {
        protected int rank; // 등수
        protected string players;
        protected string place;

        public virtual void moving()
        {

        }
        public virtual void checkRank(int rank)
        {

        }
    }
    class ItemGame : Sportgame
    {
        protected string ball;
        protected string[] otheritems;
    }
    class BaseBall : ItemGame
    {
        public BaseBall()
        {
            this.ball = "야구공";
            this.players = "9명";
            this.place = "야구장";
            this.otheritems = new string[] {"배트","글러브" };
            
        }
        public override void moving()
        {
            Console.WriteLine("야구를한다");
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine($"");
        }
    }
    class Soccer : ItemGame
    {
        public Soccer()
        {
            this.ball = "축구공";
            this.players = "11명";
            this.place = "축구장";
            this.otheritems = new string[] { "축구화", "골대" };

        }
        public override void moving()
        {
            Console.WriteLine("축구를한다");
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine($"");
        }
    }
    class PingPong : ItemGame
    {
        public PingPong()
        {
            this.ball = "탁구공";
            this.players = "2명";
            this.place = "탁구장";
            this.otheritems = new string[] { "탁구라켓", "탁구대" };

        }
        public override void moving()
        {
            Console.WriteLine("탁구를한다");
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine($"");
        }
    }
    class Weightlifting : ItemGame
    {
        public Weightlifting()
        {
            this.players = "1명";
            this.place = "체육관";
            this.otheritems = new string[] { "역기" };
        }
        public override void moving()
        {
            Console.WriteLine("역기를 한다");
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine($"");
        }
    }
    class archery : ItemGame
    {
        public archery()
        {
            this.players = "1명";
            this.place = "양궁장";
            this.otheritems = new string[] { "활", "화살","과녁" };
        }
        public override void moving()
        {
            Console.WriteLine("양궁을 한다");
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine($"");
        }
    }
    class Shooting : ItemGame
    {
        public Shooting()
        {
            this.players = "1명";
            this.place = "사격장";
            this.otheritems = new string[] { "총", "총일", "과녁" };
        }
        public override void moving()
        {
            Console.WriteLine("사격을 한다");
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine($"");
        }
    }
    class RecordGame : Sportgame
    {
        protected int[] record;
        public virtual int[] getRecord()
        {
            return record;
        }
    }
    class Jump : RecordGame
    {
        public Jump(int height)
        {
            this.record = new int[] { height };
        }
        public override int[] getRecord()
        {
            return record;
        }
        public int getRank(int[] record)
        {
            return rank;
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine();
        }
    }
    class Running : RecordGame
    {
        public Running(int bestTime)
        {
            this.record = new int[] { bestTime };
        }
        public int getRank(int[] record)
        {
            return rank;
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine();
        }
    }
    class ScoreGame : Sportgame
    {
        protected int[] score;
        public virtual int[] getScore()
        {
            return score;
        }
    }
    class Fighting : ScoreGame
    {
        public Fighting(int[] Totalscore)
        {
            this.score = Totalscore;
        }
        public int getRank(int[] score)
        {
            return rank;
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine();
        }
    }
    class gymnastics : ScoreGame
    {
        public gymnastics(int[] Totalscore)
        {
            this.score = Totalscore;
        }
        public int getRank(int[] score)
        {
            return rank;
        }
        public override void checkRank(int rank)
        {
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
