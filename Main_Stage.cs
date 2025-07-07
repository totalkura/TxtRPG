namespace TxtRPG

{
    internal class Main_Stage
    {
        static void Main()
        {
            int select = 0;
            string set = "";

            Inventory inventory = new Inventory();
            Status status = new Status();
            Stroe store = new Stroe();

            status.Player_Status();



            while (true)
            {
                select = 0;
                set = "";
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점\n");
                Console.Write("원하시는 행동을 입력해주세요\n>> ");

                set = Console.ReadLine();

                if (int.TryParse(set, out select))
                {
                    select = int.Parse(set);
                }

                switch(select)
                {
                    case 1:
                        Console.Clear();
                        status.status_view();
                        break;

                    case 2:
                        Console.Clear();
                        inventory.inventory_view();
                        break;

                    case 3:
                        Console.Clear();
                        store.store_view();
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
            /*
            Status status = new Status();
            status.status_view();
            */
        }
    }
}
