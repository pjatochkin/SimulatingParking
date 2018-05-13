
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BSA2018_Task2_Parking
{
    class Menu
    {
        static public void UserCommands()
        {
            Console.WriteLine("Attention! Parking rates:");
            foreach (KeyValuePair<string, decimal> kvp in Settings.GetSettingsInstance().ReturnAllPrice())
            {
                Console.WriteLine("Car's type = {0}, price => {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("======================================================================");
            Console.WriteLine("Select command, please:");
            Console.WriteLine("1 => Add your car.");
            Console.WriteLine("2 => Remove your car.");
            Console.WriteLine("3 => Refill car account.");
            Console.WriteLine("4 => Show the number of vacant spaces in the parking lot.");
            Console.WriteLine("5 => Show the last minute operation.");
            Console.WriteLine("6 => Show all the profit of parking");
            Console.WriteLine("7 => Output Transactions.log");
            Console.WriteLine("8 => Exit.");
            switch (Int32.Parse(Console.ReadLine()))
            {
                case 1:
                    AddCar();
                    break;
                case 2:
                    RemoveCar();
                    break;
                case 3:
                    AddMoney();
                    break;
                case 4:
                    ReturnParkingSpaces();
                    break;
                case 5:
                    ShowLastMinuteOperation();
                    break;
                case 6:
                    ReturnAllMoney();
                    break;
                case 7:
                    ShowTransactionLogFile();
                    break;
                case 8:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Please choose the correct menu item");
                    break;
            }
        }
        private static void AddCar()
        {
            Console.WriteLine("Enter the car's id:");
            int currIdCar = Int32.Parse(Console.ReadLine());  
            Console.WriteLine("Choose the car's type:");
            for (int i = 1; i <= 4 ; i++)            
                Console.WriteLine(i.ToString() + ") " + Settings.GetSettingsInstance().ReturnTypeCar(i));
            Settings.carsType currTypeCar;
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    currTypeCar = Settings.carsType.passenger;
                    break;
                case 2:
                    currTypeCar = Settings.carsType.truck;
                    break;
                case 3:
                    currTypeCar = Settings.carsType.bus; 
                    break;
                case 4:
                    currTypeCar = Settings.carsType.motorcycle;
                    break;               
                default:
                    Console.WriteLine("Please choose the correct car's type!");
                    currTypeCar = Settings.carsType.passenger;
                    break;
            }
            Console.WriteLine("Enter car's balance:");
            decimal currBillCar = decimal.Parse(Console.ReadLine());
            Car c = new Car(currIdCar, currTypeCar, currBillCar);
            Parking.GetParkingInstance().AddCar(c);
        }
        public static void RemoveCar()
        {
            Console.WriteLine("Enter the car's id:");
            int id = int.Parse(Console.ReadLine());
            if (Parking.GetParkingInstance().ReturnCarBalance(id) < 0)            
                Console.WriteLine("You do not have enough money on the account!");            
            Parking.GetParkingInstance().RemoveCar(id);
            Console.WriteLine("Your car removed!");
        }
        public static void AddMoney()
        {
            Console.WriteLine("Enter the car's id:");
            int id = int.Parse(Console.ReadLine());            
            Console.WriteLine("Enter sum: ");
            decimal sum = decimal.Parse(Console.ReadLine());
            Parking.GetParkingInstance().AddCarMoney(id, sum);
            Console.WriteLine("Money added!");
        }       
        public static void ReturnAllMoney()
        {
           Console.WriteLine(Parking.GetParkingInstance()._allMoney.ToString());
        }
        public static void ReturnParkingSpaces()
        {
            Console.WriteLine("Free plases:" + (Settings.GetSettingsInstance()._parkingSpace - Parking.GetParkingInstance().ReturnCarsCount()).ToString() + "");
        }
        public static void Exit()
        {
            System.Environment.Exit(0);
        }

        private static void ShowLastMinuteOperation()
        {
            var lastMinuteTrans = Parking.GetParkingInstance().GetLastMinuteTransactions();
            foreach (var trn in lastMinuteTrans)            
                Console.WriteLine(trn);            
        }

        private static void ShowTransactionLogFile()
        {
           string str =  System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Transaction.log");
            Console.WriteLine(str);
        }
    }
}
