using System.ComponentModel;

namespace TxtRPG
{
    internal class Inventory
    {
        

        int select = 0;
        string set = "";
        
        public void inventory_view()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("< 인벤토리 >");
                Console.ResetColor();

                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기\n");

                Console.Write("원하시는 행동을 입력해 주세요.\n>>");

                set = Console.ReadLine();
                if (int.TryParse(set, out select))
                {
                    select = int.Parse(set);
                }

                if (select == 0) break;

                switch (select)
                {
                    case 1:
                        equ();
                        Console.Clear();
                        break;
                    default:
                        OutRangeError.check();
                        continue;
                }
            }

            


        }

        private void equ()
        {
            while (true)
            {
                Console.Clear();
                int count = 1;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("< 인벤토리 - 장착 관리 >");
                Console.ResetColor();
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[ 아이템 목록 ]");

                foreach (Item item in Item_List.inventory)
                {
                    if (item.def != 0)
                    {
                        if (item.equip)
                        {
                            Console.Write($"{count}. {item.name} | 방어력 +{item.def} | {item.ex} | ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" [ E ]");
                            Console.ResetColor();
                        }

                        else
                            Console.WriteLine($"{count}. {item.name} | 방어력 +{item.def} | {item.ex} ");
                    }
                    else if (item.att != 0)
                    {
                        if (item.equip)
                        {
                            Console.Write($"{count}. {item.name} | 공격력 +{item.att} | {item.ex} | ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" [ E ]");
                            Console.ResetColor();
                        }
                        else
                            Console.WriteLine($"{count}. {item.name} | 공격력 +{item.att} | {item.ex} ");
                    }
                    ++count;
                }

              
                Console.WriteLine("\n0. 나가기\n");

                Console.Write("원하시는 행동을 입력해 주세요.\n>>");

                set = Console.ReadLine();

                select = OutRangeError.num_return(set, select);

                if (select == 0) break;

                switch (select)
                {
                    case 1: equip_set(0); break;
                    case 2: equip_set(1); break;
                    case 3: equip_set(2); break;
                    default:
                        OutRangeError.check();
                        continue;
                }
            }
        }

        private void equip_set(int a)
        {
            if (Item_List.inventory.Count > a && Item_List.inventory[a] != null)
            {
                if (!Item_List.inventory[a].equip)
                {
                    Item_List.inventory[a].equip = true;

                    if (Item_List.inventory[a].att != 0)
                    {
                        Player.Instance.att += Item_List.inventory[a].att;
                        Player.Instance.add_att += Item_List.inventory[a].att;
                    }
                    else if (Item_List.inventory[a].def != 0)
                    {
                        Player.Instance.def += Item_List.inventory[a].def;
                        Player.Instance.add_def += Item_List.inventory[a].def;
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("장착이 완료되었습니다");
                }
                else if (Item_List.inventory[a].equip)
                {
                    Item_List.inventory[a].equip = false;

                    if (Item_List.inventory[a].att != 0)
                    {
                        Player.Instance.att -= Item_List.inventory[a].att;
                        Player.Instance.add_att -= Item_List.inventory[a].att;
                    }
                    else if (Item_List.inventory[a].def != 0)
                    {
                        Player.Instance.def -= Item_List.inventory[a].def;
                        Player.Instance.add_def -= Item_List.inventory[a].def;
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("장착이 해제되었습니다");
                }
 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("인벤토리에 아무것도 없습니다");
            }
            Console.ResetColor();
            Thread.Sleep(750);

        }
    }
}
