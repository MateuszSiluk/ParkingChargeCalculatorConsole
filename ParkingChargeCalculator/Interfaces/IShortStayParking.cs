namespace ParkingChargeCalculator.Interfaces
{
    public interface IShortStayParking
    {
        decimal Calculate(DateTime start, DateTime end);
    }
}
