using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            int totalcoin = 0;
            int change = 0;
            int coininserted = 0;
            bool chose = false;
            string choice = "";
            //VendingMachine Items
            List<KeyValuePair<string, int>> items = new List<KeyValuePair<string, int>>();
            List<KeyValuePair<string, int>> available= new List<KeyValuePair<string, int>>();
            items.Add(new KeyValuePair<string,int>("Fanta",5));
            items.Add(new KeyValuePair<string, int>("Coke",5 ));
            items.Add(new KeyValuePair<string, int>("Diet Code",5));
            items.Add(new KeyValuePair<string, int>("Tropicana",6));
            items.Add(new KeyValuePair<string, int>("Starbucks",10));
            
            while(!chose)
            {
                while(available.Count==0)
                {                    
                    Console.WriteLine("Please Insert Coins");
                    coininserted = int.TryParse(Console.ReadLine(), out coininserted) ? coininserted : 0;
                    totalcoin += coininserted;
                    available = AvailableItems(items, totalcoin);
                    Console.WriteLine("Total Credit:" + totalcoin.ToString());
                }
                Console.WriteLine("Available Selections:");
                Console.WriteLine("Total Credit:" + totalcoin.ToString());
                for (int i=0;i<available.Count;i++)
                {
                    Console.WriteLine(available[i].Key + ", " + available[i].Value.ToString());
                }
                Console.WriteLine("Please Enter Your Choice");
                choice = Console.ReadLine();
                if (choice.Length != 0)
                {
                    for (int i = 0; i < available.Count; i++)
                    {
                        if (available[i].Key.ToUpper().Trim() == choice.ToUpper().Trim())
                        {
                            chose = true;
                            change = totalcoin - available[i].Value;
                        }
                    }
                    if (!chose)
                    {
                        Console.WriteLine("Do you want to get a refund? (Y / N)");
                        string response = Console.ReadLine().ToUpper();
                        if (response == "Y")
                        {
                            chose = true;
                            change = coininserted;
                        }
                        else
                        {
                            Console.WriteLine("Please Insert Coins");
                            coininserted = int.TryParse(Console.ReadLine(), out coininserted) ? coininserted : 0;
                            totalcoin += coininserted;
                            available = AvailableItems(items, totalcoin);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please Insert Coins");
                    coininserted = int.TryParse(Console.ReadLine(), out coininserted) ? coininserted : 0;
                    totalcoin += coininserted;
                    available = AvailableItems(items, totalcoin);
                }
                
            }
            Console.WriteLine("Your Choice:" + choice);
            Console.WriteLine("Your Change:" + change);
            Console.ReadKey();

            
        }
        static List<KeyValuePair<string, int>> AvailableItems(List<KeyValuePair<string, int>>AllItems,int CoinInserted)
        {
            List<KeyValuePair<string, int>> returnList = new List<KeyValuePair<string, int>>();
            for(int i=0;i<AllItems.Count;i++)
            {
                if(AllItems[i].Value<=CoinInserted)
                {
                    returnList.Add(AllItems[i]);
                }
            }


            return returnList;
        }
    }
}
