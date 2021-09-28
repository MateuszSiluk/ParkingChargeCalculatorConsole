using ParkingChargeCalculator.Data;
using ParkingChargeCalculator.Interfaces;

namespace ParkingChargeCalculator
{
    public class ShortStayParking : IShortStayParking
    {
        private readonly IFreeParkingCheck _freeParkingCheck;


        public ShortStayParking(IFreeParkingCheck freeParkingCheck)
        {
            _freeParkingCheck = freeParkingCheck;
        }
        public decimal Calculate(DateTime start, DateTime end)
        {
            if (start>end)
            {
                throw new ArgumentException(String.Format($"Start date can't be earlier than end date!"));
            }

            decimal totalMinutes = 0;

            for (DateTime date = start; date < end; date = date.AddMinutes(1))
            {
                if (_freeParkingCheck.IsNotFreeParking(date))
                {
                    totalMinutes++;
                }
            }
            return totalMinutes / 60 * PriceList.ShortStayPerHour;
        }
    }
}
