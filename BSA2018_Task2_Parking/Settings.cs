using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BSA2018_Task2_Parking
{
    class Settings
    {
        public enum carsType { passenger, truck, bus, motorcycle };

        private int timeOut = 3;
        private int parkingSpace = 10;
        private decimal fine = 1.1m;
        Dictionary<string, decimal> price = new Dictionary<string, decimal>();

        public int _timeOut
        {
            get { return timeOut; }
        }
        public int _parkingSpace
        {
            get { return parkingSpace; }
            set
            {
                if (value > 0)
                    parkingSpace = value;   
            }
        }
        public decimal _fine
        {
            get { return fine; }
        }

        public Dictionary<string, decimal> ReturnAllPrice()
        {
            return price;
        }

        public int ReturnPriceByType(carsType ct)
        {
            switch (ct)
            {
                case carsType.bus:
                    return 4;
                    break;
                case carsType.motorcycle:
                    return 1;
                    break;
                case carsType.passenger:
                    return 2;
                    break;
                case carsType.truck:
                    return 4;
                    break;
                default:
                    return 2;
                    break;
            }
        }

        public string ReturnTypeCar(int c)
        {
            switch (c)
            {
                case 1:
                    return carsType.passenger.ToString();
                    break;
                case 2:
                    return carsType.truck.ToString();
                    break;
                case 3:
                    return carsType.bus.ToString();
                    break;
                case 4:
                    return carsType.motorcycle.ToString();
                    break;
                default:
                    return carsType.passenger.ToString();
                    break;
            }
        }

        //singleton pattern
        private Settings()
        {
            price.Add(carsType.passenger.ToString(), 2);
            price.Add(carsType.bus.ToString(), 4);
            price.Add(carsType.truck.ToString(), 4);
            price.Add(carsType.motorcycle.ToString(), 1);
        }
        private int TransactionCount = 0;
        private static Settings SettingsInstance = new Settings();

        public static Settings GetSettingsInstance()
        { return SettingsInstance; }
    }
}
