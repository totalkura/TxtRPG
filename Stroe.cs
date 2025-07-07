using System.ComponentModel;

namespace TxtRPG
{
    internal class Stroe
    {
        public List<string> Stroe_Item = new List<string>
        {
            "수련자 갑옷",
            "무쇠 갑옷",
            "스파르타의 갑옷",
            "낡은 검",
            "청동 도끼",
            "스파르타의 창"
        };

        public List<string> Stroe_Item_op = new List<string>
        {
            "0,5,500",
            "0,9,1000",
            "0,15,1700",
            "2,0,500",
            "5,0,1500",
            "7,0,2300"
        };

        public List<string> Stroe_Item_ex = new List<string>
        {
            "수련에 도움을 주는 갑옷입니다.",
            "무쇠로 만들어져 튼튼한 갑옷입니다.",
            "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
            "쉽게 볼 수 있는 낡은 검 입니다.",
            "어디선가 사용했던거 같은 도끼입니다.",
            "스파르타의 전사들이 사용했다는 전설의 창입니다."
        };

        int select = 0;
        string set="";  

        public void store_view()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("< 상점 >");
                Console.ResetColor();

                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($" {Player.Instance.gold} G\n");
                Console.WriteLine("[ 아이템 목록 ]\n");

                Console.WriteLine("1. 장착 관리");
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

                switch (select)
                {
                    case 1:
                        Console.Clear();

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("잘못된 입력입니다");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        Console.Clear();
                        continue;
                }
            }

            


        }
    }
}
