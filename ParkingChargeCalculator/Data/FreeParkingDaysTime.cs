namespace ParkingChargeCalculator.Data
{
    public static class FreeParkingDaysTime
    {
        public static readonly TimeOnly startTime = TimeOnly.Parse("6:00 PM");
        public static readonly TimeOnly stopTime = TimeOnly.Parse("7:59 AM");
        public static readonly List<String> days = new List<String> {"Saturday", "Sunday"};
    }
}
