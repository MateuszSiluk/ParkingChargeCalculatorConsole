namespace ParkingChargeCalculator.Interfaces
{
    public interface IFreeParkingCheck
    {
        bool IsNotFreeParking(DateTime dateTime);
    }
}
