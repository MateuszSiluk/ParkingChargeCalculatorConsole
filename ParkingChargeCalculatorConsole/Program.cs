using ParkingChargeCalculator;

class Program
{
    public static void Main(string[] args)
    {
        /*
         * Short Stay hard Code
         */
        DateTime shortStayStart1 = new(2021, 09, 28, 20, 00, 0); ;
        DateTime shortStayStop1 = new(2021, 09, 28, 23, 00, 0); ;

        var shortStayTotalValue1 = ParkingService.ShortStayCalculate(shortStayStart1, shortStayStop1);

        Console.WriteLine($"A short stay from {shortStayStart1:G} to " +
                          $"{shortStayStop1:G} would cost £{shortStayTotalValue1:N2} ");



        /*
         * Short Stay hard Code
         */
        DateTime shortStayStart = new(2017, 09, 07, 16, 50, 00);
        DateTime shortStayStop = new(2017, 09, 09, 19, 15, 00);

        var shortStayTotalValue = ParkingService.ShortStayCalculate(shortStayStart, shortStayStop);

        Console.WriteLine($"A short stay from {shortStayStart:G} to " +
                          $"{shortStayStop:G} would cost £{shortStayTotalValue:N2} ");


        /*
         * Long Stay hard Code
         */
        DateTime longStayStart = new(2017, 09, 07, 07, 50, 00);
        DateTime longStayStop = new(2017, 09, 09, 05, 20, 00);

        var longStayTotalValue = ParkingService.LongStayCalculate(longStayStart, longStayStop);

        Console.WriteLine($"A long stay from {longStayStart:G} to " +
                          $"{longStayStop:G} would cost £{longStayTotalValue:N2} ");

        Console.ReadLine();

    }
}




