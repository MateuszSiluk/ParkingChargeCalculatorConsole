using ParkingChargeCalculator.Data;
using ParkingChargeCalculator.Interfaces;

namespace ParkingChargeCalculator
{
    public class LongStayParking : ILongStayParking
    {
        public decimal Calculate(DateTime startDateTime, DateTime endDateTime)
        {
            if (startDateTime > endDateTime)
            {
                throw new ArgumentException(String.Format($"Start date can't be earlier than end date!"));
            }

            var totalDays = ((int)(endDateTime.Date.AddDays(1) - startDateTime.Date).Days);
            var totalPrice = (decimal)totalDays * PriceList.LongStayPerDay;

            return totalPrice;
        }
    }
}
