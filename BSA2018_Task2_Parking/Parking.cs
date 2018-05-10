using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Task2_Parking
{
    class Parking
    {
        private int timeOut;
        private int parkingSpace;
        private double fine;
        Dictionary<int, string> allCars = new Dictionary<int, string>();        
        //private int _countCras
        //{
        //    get { return countCras; }
        //    set
        //    {
        //        if (value > Settings.GetSettingsInstance()._parkingSpace)
        //            countCras = Settings.GetSettingsInstance()._parkingSpace;
        //        else
        //            countCras = value;
        //    }
        //}
        public Parking()
        {
            timeOut = Settings.GetSettingsInstance()._timeOut;
            parkingSpace = Settings.GetSettingsInstance()._parkingSpace;
            fine = Settings.GetSettingsInstance()._fine;
        }
    }
}
