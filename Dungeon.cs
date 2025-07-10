using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace TxtRPG
{
    internal class Dungeon
    {
        int select = 0;
        string set="";

        public void dungeon_view()
        {
            
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("< 던 전 >");
                Console.ResetColor();

                Console.WriteLine();

                Console.WriteLine("[보유 골드]");

                Console.WriteLine("\n1. 숙박하기 ( -300 gold | HP 100 회복)");
                Console.WriteLine("0. 나가기\n");

                Console.Write("원하시는 행동을 입력해 주세요.\n>>");

                set = Console.ReadLine();

                select = OutRangeError.num_return(set, select);

                if (select == 0) break;

                switch (select)
                {
                    case 1:

                        Thread.Sleep(750);
                        break;
                    default:
                        OutRangeError.check();
                        continue;
                }
            }

            


        }

        void SlowWriteLine()
        {
            Console.SetCursorPosition(85, 1);
            string text = "";
            int delay = 40;
            
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            
            Console.SetCursorPosition(0, 1);
        }

    }
}
