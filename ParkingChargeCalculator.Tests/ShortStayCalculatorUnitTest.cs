using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ParkingChargeCalculator.Tests
{

    public class ShortStayCalculatorUnitTest
    {
        public static readonly object[][] CorrectData =
        {

            //Calculate Should Charge 1.10
            new object[] {  new DateTime(2019, 09, 09, 16, 50, 00), new DateTime(2019, 09, 09, 17, 50, 00), 1.10m },

            //Short_Stay_Should_Cost_0_On_Return_Outside_Charge_Hours
            new object[] {  new DateTime(2021, 09, 28, 18, 11, 00), new DateTime(2021, 09, 28, 20, 11, 00), 0 },

            //Short_Stay_Should_Charge_0_275_For_15_Minutes_In_Chargabe_Hours
            new object[] {  new DateTime(2021, 09, 28, 09, 00, 00), new DateTime(2021, 09, 28, 09, 15, 00), 0.275m },

            //Short_Stay_Should_Charge_Only_From_8PM_To_6PM
            new object[] {  new DateTime(2021, 09, 28, 17, 00, 0), new DateTime(2021, 09, 28, 20, 30, 0), 1.10m },

            //Short_Stay_Charge_Calculate_For_10_Days
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

        [Theory]
        [InlineData(5,2)]
        public void Calculate_should_throw_exception_when_start_date_is_before_end_date(int day1, int day2)
        {
            // Arrange
            var startDate = new DateTime(2021, 09, day1, 00, 00, 0);
            var endDate = new DateTime(2021, 09, day2, 00, 00, 00);

            // Act
            Action actual= () => ParkingService.ShortStayCalculate(startDate, endDate);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(actual);
            Assert.Equal("Start date can't be earlier than end date!", exception.Message);

        }

        
    }
}