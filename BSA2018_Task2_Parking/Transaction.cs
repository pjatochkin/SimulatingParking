using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Task2_Parking
{
    class Transaction
    {
        private DateTime date = DateTime.MaxValue;
        private int idCar;
        private decimal debit;
        public DateTime _date
        {
            get { return date; }
            set
            {
                if (value != null)
                    date = value;
            } 
        }
        public int _idCar
        {
            get
            {
                Car c = new Car();
                idCar = c._id;
                return idCar;
            }
        }

        public decimal _debit
        {
            get; set;
        }
    }
}
