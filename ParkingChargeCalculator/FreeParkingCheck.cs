using ParkingChargeCalculator.Data;
using ParkingChargeCalculator.Interfaces;

namespace ParkingChargeCalculator
{
    public class FreeParkingCheck : IFreeParkingCheck
    {
        public bool IsNotFreeParking(DateTime dateTime)
        {
            if (FreeParkingDaysTime.days.Contains(dateTime.DayOfWeek.ToString()))
            {
                return false;
            }
            else if (dateTime.TimeOfDay < FreeParkingDaysTime.startTime.ToTimeSpan() &&
                    dateTime.TimeOfDay > FreeParkingDaysTime.stopTime.ToTimeSpan())
            {
                return true;
            }
            return false;
        }
    }
}
