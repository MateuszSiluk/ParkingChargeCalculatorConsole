using System;
using Xunit;

namespace ParkingChargeCalculator.Tests
{
    public class LongStayCalculatorUnitTest
    {
        public static readonly object[][] CorrectData =
        {

            //Long_Stay_Should_Cost_7_50_Per_Each_24Hours
            new object[] {  new DateTime(2021, 09, 25, 00, 00, 00), new DateTime(2021, 09, 25, 00, 00, 00), 7.5m },

            //Long_Stay_Should_Cost_7_50_Per_2_hours
            new object[] {  new DateTime(2021, 09, 25, 00, 00, 00), new DateTime(2021, 09, 25, 02, 00, 00), 7.5m },

            //Long_Stay_Should_Cost_7_50_Per_7_hours
            new object[] {  new DateTime(2021, 09, 25, 00, 00, 00), new DateTime(2021, 09, 25, 07, 00, 00), 7.5m },

            //Long_Stay_Should_Cost_15_00_Per_25_hours
            new object[] {  new DateTime(2021, 09, 25, 00, 00, 00), new DateTime(2021, 09, 26, 01, 00, 00), 15.0m },

            };


        [Theory]
        [MemberData(nameof(CorrectData))]
        public void Long_Stay_Unit_Tests(DateTime value1, DateTime value2, decimal expected)
        {
            // Act
            var actual = ParkingService.LongStayCalculate(value1, value2);
            // Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(5, 2)]
        public void Calculate_should_throw_exception_when_start_date_is_before_end_date(int day1, int day2)
        {
            // Arrange
            var startDate = new DateTime(2021, 09, day1, 00, 00, 0);
            var endDate = new DateTime(2021, 09, day2, 00, 00, 00);

            // Act
            Action actual = () => ParkingService.LongStayCalculate(startDate, endDate);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(actual);
            Assert.Equal("Start date can't be earlier than end date!", exception.Message);

        }
    }
}
