using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace TxtRPG
{
    internal class Stroe
    {
        int select = 0;
        string set="";  

        public void store_view()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("< 상점 >");
                Console.ResetColor();

                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($" {Player.Instance.gold} G\n");
                Console.WriteLine("[ 아이템 목록 ]\n");

                foreach (Item item in Item_List.item_list)
                {
                    if (!item.sell && item.def > 0)
                        Console.WriteLine($"- {item.name} | 방어력 +{item.def} | {item.ex} | {item.gold} G");
                    else if (!item.sell && item.att > 0)
                        Console.WriteLine($"- {item.name} | 공격력 +{item.att} | {item.ex} | {item.gold} G");
                    else if (item.sell && item.def > 0)
                    {
                        Console.Write($"- {item.name} | 방어력 +{item.def} | {item.ex} | ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("구매완료");
                    }
                    else if (item.sell && item.att > 0)
                    {
                        Console.Write($"- {item.name} | 공격력 +{item.att} | {item.ex} | ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("구매완료");
                    }
                    Console.ResetColor();
                }

                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("0. 나가기\n");

                Console.Write("원하시는 행동을 입력해 주세요.\n>>");

                set = Console.ReadLine();

                select = OutRangeError.num_return(set, select);

                if (select == 0) break;

                switch (select)
                {
                    case 1:
                        Console.Clear();
                        store_sell();
                        break;
                    default:
                        OutRangeError.check();
                        continue;
                }
            }

            


        }
        private void store_sell()
        {
            
            while (true)
            {
                Console.Clear();

                int counts = 1;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("< 상점 - 아이템 구매 >");
                Console.ResetColor();

                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($" {Player.Instance.gold} G\n");
                Console.WriteLine("[ 아이템 목록 ]\n");

                foreach (Item item in Item_List.item_list)
                {
                    if (!item.sell && item.def > 0)
                        Console.WriteLine($"({counts}) {item.name} | 방어력 +{item.def} | {item.ex} | {item.gold} G");
                    else if (!item.sell && item.att > 0)
                        Console.WriteLine($"({counts}) {item.name} | 공격력 +{item.att} | {item.ex} | {item.gold} G");
                    else if (item.sell && item.def > 0)
                    {
                        Console.Write($"({counts}) {item.name} | 방어력 +{item.def} | {item.ex} | ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("구매완료");
                    }
                    else if (item.sell && item.att > 0)
                    {
                        Console.Write($"({counts}) {item.name} | 공격력 +{item.att} | {item.ex} | ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("구매완료");
                    }
                    Console.ResetColor();
                    counts++;
                }

                Console.WriteLine("\n0. 나가기\n");

                Console.Write("원하시는 행동을 입력해 주세요.\n>>");

                set = Console.ReadLine();

                if (int.TryParse(set, out select))
                {
                    select = int.Parse(set);
                }

                if (select == 0) break;
             

                switch (select)
                {
                    case 1: Buyitem(0); break;
                    case 2: Buyitem(1); break;
                    case 3: Buyitem(2); break;
                    case 4: Buyitem(3); break;
                    case 5: Buyitem(4); break;
                    case 6: Buyitem(5); break;
                    default:
                        OutRangeError.check();
                        continue;
                }
                
            }
        }

        private void Buyitem(int a)
        {
            
            if ((Player.Instance.gold > Item_List.item_list[a].gold) && !Item_List.item_list[a].sell)
            {
                Player.Instance.gold -= Item_List.item_list[a].gold;
                Item_List.item_list[a].sell = true;

                Item_List.inventory.Add(Item_List.item_list[a]);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("구매를 완료했습니다");
            }
            else if (Item_List.item_list[a].sell)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("이미 구매된 아이템입니다");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Gold가 부족합니다");
            }

            Console.ResetColor();
            Thread.Sleep(750);
        }
    }
}
