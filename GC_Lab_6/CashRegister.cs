using System;
using System.Collections.Generic;
using System.Text;

namespace GC_Lab_6
{
    public class CashRegister
    {
        public double Till { get; private set; }

        public CashRegister(double startingTill)
        {
            Till = startingTill;
        }


        /// <summary>
        /// Will lower the amount in the t
        /// </summary>
        /// <param name="requestAmount"></param>
        /// <returns></returns>
        public bool TryMakeChange(double requestAmount)
        {
            if (requestAmount > Till)
            {
                return false;
            }

            Till -= requestAmount;
            
            return true;
        }
    }
}
