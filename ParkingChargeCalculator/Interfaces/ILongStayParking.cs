namespace ParkingChargeCalculator.Interfaces
{
    public interface ILongStayParking
    {
        decimal Calculate(DateTime start, DateTime end);
    }
}
