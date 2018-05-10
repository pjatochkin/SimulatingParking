using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Task2_Parking
{
    class Car
    {
        private int id;
        private decimal bill;
        private int type;        

        Random rnd = new Random();

        public int _id
        {
            get { return id; }
            set
            {
                //if (value > 0)
                //    id = value;
                //else
                    id = rnd.Next(1, 1000);
            }
        }

        public decimal _bill
        {
            get { return bill; }
            set { bill = value; }
        }

        public int _type
        {
            get { return type; }
            set
            {
                if (value < 0 || value > 3)
                    type = 0;
                else
                    type = value;
            }
        }
    }
}
