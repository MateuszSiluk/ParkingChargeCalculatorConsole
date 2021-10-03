using ParkingChargeCalculator.Data;

namespace ParkingChargeCalculator
{
    public static class FreeParkingCheck
    {
        public static bool IsNotFreeParking(DateTime dateTime)
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
