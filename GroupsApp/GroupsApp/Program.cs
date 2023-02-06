using System;

namespace GroupsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];
            int input;
            do
            {
                Console.WriteLine("\n========== Menu ==========");
                Console.WriteLine("\n1. Qrup elave et.");
                Console.WriteLine("2. Qruplara bax.");
                Console.WriteLine("3. Type deyerine gore qruplara bax.");
                Console.WriteLine("4. Bugunedek baslamıs qruplara bax.");
                Console.WriteLine("5. Son 2 ayda baslamıs qruplara bax.");
                Console.WriteLine("6. Bu ayın sonunadek yeni baslayacaq olan qruplara bax.");
                Console.WriteLine("7. Verilmis 2 tarix aralıginda baslamıs olan qruplara bax.");
                Console.WriteLine("0. Menu-dan cix.");

                Console.Write("\nSecim edin --> ");
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 0:
                        input = -1;
                        Console.WriteLine("\nEminsiniz mi? Yes/No");
                        if (Console.ReadLine() == "Yes")
                        {
                            input = 0;
                        }
                        break;
                    case 1:
                        Console.WriteLine("\nGroupNo daxil edin:");
                        string groupNo = Console.ReadLine();

                        Console.WriteLine("Type daxil edin:");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                        {
                            Console.WriteLine($"{(byte)item} - {item}");
                        }
                        Console.Write("\nSecim edin --> ");
                        byte typeByt = Convert.ToByte(Console.ReadLine());
                        GroupType type = (GroupType)typeByt;

                        Console.WriteLine("\nStartDate daxil edin:");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                        Group group = new Group()
                        {
                            GroupNo = groupNo,
                            Type = type,
                            StartDate = startDate,
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;
                        break;
                    case 2:
                        foreach (var item in groups)
                        {
                            item.ShowInfo();
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nType deyeri daxil edin:");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                        {
                            Console.WriteLine($"{(byte)item} - {item}");
                        }
                        Console.Write("\nSecim edin --> ");
                        typeByt = Convert.ToByte(Console.ReadLine());
                        type = (GroupType)typeByt;

                        foreach (var item in groups)
                        {
                            if (item.Type == type)
                            {
                                item.ShowInfo();
                            }
                        }
                        break;
                    case 4:
                        foreach (var item in groups)
                        {
                            if (item.StartDate <= DateTime.Now)
                            {
                                item.ShowInfo();
                            }
                        }
                        break;
                    case 5:
                        foreach (var item in groups)
                        {
                            if (item.StartDate.AddMonths(-2) <= DateTime.Now)
                            {
                                item.ShowInfo();
                            }
                        }
                        break;
                    case 6:
                        DateTime now = DateTime.Now;
                        var start = new DateTime(now.Year, now.Month, 1);
                        var end = start.AddMonths(1).AddDays(-1);
                        foreach (var item in groups)
                        {
                            if (item.StartDate >= DateTime.Now && item.StartDate <= end)
                            {
                                item.ShowInfo();
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("\nBirinci tarixi daxil edin:");
                        DateTime dateTime1 = Convert.ToDateTime(Console.ReadLine());

                        Console.WriteLine("Ikinci tarixi daxil edin:");
                        DateTime dateTime2 = Convert.ToDateTime(Console.ReadLine());

                        foreach (var item in groups)
                        {
                            if (item.StartDate > dateTime1 && item.StartDate <=dateTime2 )
                            {
                                item.ShowInfo();
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("\nYanlis secim etdiniz, yeniden secim edin.");
                        break;
                }

            } while (input != 0);
            
        }
    }
}
