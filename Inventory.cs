using System.ComponentModel;

namespace TxtRPG
{
    internal class Inventory
    {
        //가방의 아이템 총 갯수는 9
        public List<string> inventory = new List<string>(9);

        int select = 0;
        string set = "";

        public void inventory_view()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("< 인벤토리 >");
                Console.ResetColor();

                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
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
