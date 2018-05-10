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
        private double fine = 1.1;
        Dictionary<string, int> price = new Dictionary<string, int>();

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
        public double _fine
        {
            get { return fine; }
        }

        public Dictionary<string, int> returnAllPrice()
        {
            return price;
        }

        public string returnTypeCar(int c)
        {
            switch (c)
            {
                case 0:
                    return carsType.passenger.ToString();
                    break;
                case 1:
                    return carsType.truck.ToString();
                    break;
                case 2:
                    return carsType.bus.ToString();
                    break;
                case 3:
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
