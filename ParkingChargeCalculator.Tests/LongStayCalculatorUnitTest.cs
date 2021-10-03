using System;
using Xunit;

namespace ParkingChargeCalculator.Tests
{
    public class LongStayCalculatorUnitTest
    {
        private readonly LongStayParking _longStayParking;

        public LongStayCalculatorUnitTest()
        {
            _longStayParking = new LongStayParking();
        }

        [Theory]
        [InlineData(1,7.50)]
        [InlineData(2, 15)]
        [InlineData(20, 150)]
        public void Long_Stay_Should_Cost_7_50_Per_Each_24Hours(int day, decimal exp)
        {
            //Arrange
            var startDate = new DateTime(2021, 09, 1, 00, 00, 0);
            var endDate = new DateTime(2021, 09, 1 * day , 23, 59, 59);
            var expected = exp;
            //Act
            var actual = _longStayParking.Calculate(startDate, endDate);

            //Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(9,40, 7.50)]
        [InlineData(22,45, 7.50)]
        [InlineData(23, 59, 7.50)]
        public void Long_Stay_Should_Cost_7_50_No_Matter_For_How_Long_During_24H(int hours, int minutes, decimal expected)
        {
            //Arrange
            var startDate = new DateTime(2021, 09, 1, 8, 20, 0);
            var endDate = new DateTime(2021, 09, 1 , hours, minutes ,0 );
            //Act
            var actual = _longStayParking.Calculate(startDate, endDate);

            //Assert
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
            Action actual = () => _longStayParking.Calculate(startDate, endDate);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(actual);
            Assert.Equal("Start date can't be earlier than end date!", exception.Message);

        }
    }
}
