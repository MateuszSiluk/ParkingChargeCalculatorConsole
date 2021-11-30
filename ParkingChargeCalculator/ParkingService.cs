﻿using ParkingChargeCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingChargeCalculator
{
    public static class ParkingService
    {
        public static decimal ShortStayCalculate(DateTime start, DateTime end)
        {
            if (start >= end)
            {
                throw new ArgumentException(String.Format($"Start date can't be earlier or the same as end date!"));
            }

            decimal totalMinutes = 0;

            for (DateTime date = start; date < end; date = date.AddMinutes(1))
            {
                if (FreeParkingCheck.IsNotFreeParking(date))
                {
                    totalMinutes++;
                }
            }
            return totalMinutes / 60 * PriceList.SHORT_STAY_PER_HOUR;
        }

        public static decimal LongStayCalculate(DateTime startDateTime, DateTime endDateTime)
        {
            if (startDateTime >= endDateTime)
            {
                throw new ArgumentException(String.Format($"Start date can't be earlier or the same as end date!"));
            }

            var totalDays = ((int)(endDateTime.AddDays(1) - startDateTime).Days);
            var totalPrice = (decimal)totalDays * PriceList.LONG_STAY_PER_DAY;

            return totalPrice;
        }
    }
}
