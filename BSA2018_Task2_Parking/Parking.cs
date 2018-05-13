using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace BSA2018_Task2_Parking
{
    class Parking
    {
        private int timeOut;
        private int parkingSpace;
        private decimal fine;
        private decimal allMoney;

        public decimal _allMoney
        { get { return allMoney; } }

        private Timer timerSum;
        private Timer timerTrans;
        List<Car> allCars = new List<Car>();
        List<Transaction> allTransaction = new List<Transaction>();

        //singleton pattern
        private static Parking ParkingInstance = new Parking();
        public static Parking GetParkingInstance()
        { return ParkingInstance; }

        public Parking()
        {
            timeOut = Settings.GetSettingsInstance()._timeOut;
            parkingSpace = Settings.GetSettingsInstance()._parkingSpace;
            fine = Settings.GetSettingsInstance()._fine;
            // set the callback method
            TimerCallback tcm = new TimerCallback(CalcMoneyTimer);
            TimerCallback tctrn = new TimerCallback(WriteTransactionTimer);
            // create timer
            timerSum = new Timer(tcm, null, 0, 60000);
            timerTrans = new Timer(tctrn, null, 0, Settings.GetSettingsInstance()._timeOut * 1000);
        }

        public int ReturnCarsCount()
        { return allCars.Count; }

        public void AddCar(Car _c)
        {
            try
            {
                if (ReturnCarsCount() < Settings.GetSettingsInstance()._parkingSpace)
                    allCars.Add(_c);
                else
                    Console.WriteLine("There are no free places in the parking lot!");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }

        public void RemoveCar(int _id)
        {
            try
            {
                Car currCar = allCars.First<Car>(c => c._id == _id);
                allCars.Remove(currCar);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }

        public void AddCarMoney(int _id, decimal _money)
        {
            try
            {
                Car currCar = allCars.First<Car>(c => c._id == _id);
                currCar.AddMoney(_money);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }

        public decimal ReturnCarBalance(int _id)
        {
            Car currCar = allCars.First<Car>(c => c._id == _id);
            return currCar._bill;
        }

        public void CalcAllMoney(decimal sum)
        {
            allMoney += sum;
        }

        public void AddTransaction(Transaction trn)
        {
            allTransaction.Add(trn);
        }

        public IEnumerable<Transaction> GetLastMinuteTransactions()
        {
            var lastMinuteTrans = Parking.GetParkingInstance().allTransaction.Where<Transaction>(t => DateTime.Now == DateTime.Now.AddMinutes(-1));
            return lastMinuteTrans;
        }

        public void CalcMoneyTimer(object obj)
        {
            foreach (Car c in allCars)
            {
                decimal price = Settings.GetSettingsInstance().ReturnPriceByType(c._type);
                decimal sum = c._bill - price;
                if (sum < 0)
                    price *= fine;
                c.TakeMoney(price);
                CalcAllMoney(price);
                Transaction trn = new Transaction(c._id, price);
                AddTransaction(trn);
            }
        }

        public void WriteTransactionTimer(object obj)
        {
            var lastMinuteTrans = Parking.GetParkingInstance().GetLastMinuteTransactions();
            FileInfo fi = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Transaction.log");
            if (!fi.Exists)
                fi.Create();
            decimal sum = 0;
            foreach (var trn in lastMinuteTrans)
                sum += trn._debit;
            string msg = "Datetime: " + DateTime.Now.ToShortDateString() + " => SUM: " + sum.ToString() + "";
            System.IO.File.AppendAllText(fi.FullName, msg + "\r\n");            
        }
    }
}
