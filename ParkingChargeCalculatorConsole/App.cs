using ParkingChargeCalculator.Interfaces;

namespace ParkingChargeCalculatorConsole
{
    public class App
    {
        private readonly ILongStayParking _longstayParking;


        public App(ILongStayParking longStayParking)
        {
            _longstayParking = longStayParking;
        }
        public void Run()
        {

            /*
             * Long Stay hard Code
             */
            DateTime longStayStart = new DateTime(2017, 09, 07, 07, 50, 00);
            DateTime longStayStop = new DateTime(2017, 09, 09, 05, 20, 00);

            var longStayTotalValue = _longstayParking.Calculate(longStayStart, longStayStop);

            Console.WriteLine($"A long stay from {longStayStart.ToUniversalTime()} to " +
                              $"{longStayStart.ToUniversalTime()} would cost £{longStayTotalValue} ") ;
        }
    }
}
