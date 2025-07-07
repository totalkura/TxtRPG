using System.ComponentModel;

namespace TxtRPG
{
    public class Player
    {
        private static Player _instance;
        
        // 싱글톤 인스턴스 초기화
        public static Player Instance => _instance ??= new Player();
        public int level { get; set; }
        public int att { get; set; }
        public int def { get; set; }
        public int gold { get; set; }
        public float hp { get; set; }
        public string job { get; set; }

        private Player() { }
    }

    internal class Status
    {
        int select = 0;
        string set = "";

        public void status_view()
        {
            while (true)
            {
                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("상태 보기");
                Console.ResetColor();
                Console.WriteLine("캐릭터의 정보가 표시됩니다\n");
                if (Player.Instance.level < 10)
                {
                    Console.WriteLine($"Lv : 0{Player.Instance.level}");
                }
                else
                {
                    Console.WriteLine($"Lv : {Player.Instance.level}");
                }
                Console.WriteLine($"Chad( {Player.Instance.job} )");
                Console.WriteLine($"공격력 : {Player.Instance.att}");
                Console.WriteLine($"방어력 : {Player.Instance.def}");
                Console.WriteLine($"체  력 : {Player.Instance.hp}");
                Console.WriteLine($"Gold : {Player.Instance.gold}\n");

                Console.WriteLine("0. 나가기\n");

                Console.Write("원하시는 행동을 입력해 주세요.\n>>");
                set = Console.ReadLine();

                if (int.TryParse(set, out select))
                {
                    select = int.Parse(set);
                }

                if (select == 0)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("잘못된 입력입니다");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Console.Clear();
                    continue;
                }
            }

        }

        public void Player_Status()
        {
            Player.Instance.level = 1;
            Player.Instance.hp = 100;
            Player.Instance.att = 10;
            Player.Instance.def = 5;
            Player.Instance.gold = 1500;
            Player.Instance.job = "무직";
        }
    }

}
