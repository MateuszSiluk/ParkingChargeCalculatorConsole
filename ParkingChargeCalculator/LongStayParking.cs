using ParkingChargeCalculator.Interfaces;

namespace ParkingChargeCalculator
{
    public class LongStayParking : ILongStayParking
    {
        public decimal Calculate(DateTime startDateTime, DateTime endDateTime)
        {
            var totalDays = ((int)(endDateTime.Date.AddDays(1) - startDateTime.Date).Days);
            var totalPrice = (decimal)totalDays * PriceList.LongStayPerDay;

            return totalPrice;
        }
    }
}
