using System;
using Xunit;

namespace ParkingChargeCalculator.Tests
{

    public class ShortStayCalculatorUnitTest
    {
        public static readonly object[][] CorrectData =
        {

            //Short_Stay_Should_Cost 1.10
            //Thursday 16:50:00 to Saturday 17:50:00
            new object[] {  new DateTime(2019, 09, 09, 16, 50, 00), new DateTime(2019, 09, 09, 17, 50, 00), 1.10m },

            //Short_Stay_Should_Cost_0_On_Return_Outside_Charge_Hours
            //Tuesday 18:11:00 to Tuesday 20:11:00
            new object[] {  new DateTime(2021, 09, 28, 18, 11, 00), new DateTime(2021, 09, 28, 20, 11, 00), 0 },

            //Short_Stay_Should_Charge_0_275_For_15_Minutes_In_Chargabe_Hours
            //Tuesday 09:00:00 to Tuesday 09:15:00
            new object[] {  new DateTime(2021, 09, 28, 09, 00, 00), new DateTime(2021, 09, 28, 09, 15, 00), 0.275m },

            //Short_Stay_Should_Charge_Only_From_8PM_To_6PM_Charge_Only_1.10
            //Tuesday 17:00:00 to Tuesday 20:30:00
            new object[] {  new DateTime(2021, 09, 28, 17, 00, 0), new DateTime(2021, 09, 28, 20, 30, 0), 1.10m },

            //Short_Stay_Should_Charge_88_For_10_Days
            //(06-09-2021) Monday 00:00:00 to (16-09-2021) Thursday 00:00:00
            new object[] {  new DateTime(2021, 09, 06, 00, 00, 0), new DateTime(2021, 09, 16, 0, 0, 0), 88.0m }

            };




        [Theory]
        [MemberData(nameof(CorrectData))]
        public void Short_Stay_Unit_Tests(DateTime value1, DateTime value2, decimal expected)
        {

            // Act
            var actual = ParkingService.ShortStayCalculate(value1, value2);
            // Assert
            Assert.Equal(expected, actual);
        }







        public static readonly object[][] CorrectDataExpectedException =
        {
            //Short_Stay_Should_Throw_Exception_when_startDate_is_greater_than_endDate
            //Saturday 00:00:00 to Saturday 00:00:00
            new object[] {  new DateTime(2021, 09, 25, 00, 00, 00), new DateTime(2021, 09, 25, 00, 00, 00) },

            //(27-09-2021) Monday 00:00:00 to (25-09-2021) Saturday 00:00:00
            new object[] {  new DateTime(2021, 09, 27, 00, 00, 00), new DateTime(2021, 09, 25, 00, 00, 00) },
        };


        [Theory]
        [MemberData(nameof(CorrectDataExpectedException))]
        public void Calculate_should_throw_exception_when_start_date_is_before_end_date(DateTime startDate, DateTime endDate)
        {
            // Act
            Action actual = () => ParkingService.ShortStayCalculate(startDate, endDate);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(actual);
            Assert.Equal("Start date can't be earlier or the same as end date!", exception.Message);

        }


    }
}