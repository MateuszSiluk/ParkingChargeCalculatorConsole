using Moq;
using ParkingChargeCalculator.Interfaces;
using System;
using Xunit;

namespace ParkingChargeCalculator.Tests
{

    public class ShortStayCalculatorUnitTest
    {
        private readonly FreeParkingCheck _freeParkingCheck;
        private readonly ShortStayParking _shortStayParking;

        public ShortStayCalculatorUnitTest()
        {
            _freeParkingCheck = new FreeParkingCheck();
            _shortStayParking = new ShortStayParking(_freeParkingCheck);
        }
        public static readonly object[][] CorrectData =
        {
            new object[] {  new DateTime(2019, 09, 09, 16, 50, 00), new DateTime(2019, 09, 09, 17, 50, 00), 1.10m },
            new object[] {  new DateTime(2021, 09, 28, 10, 11, 00), new DateTime(2021, 09, 28, 11, 11, 00), 1.10m },
            new object[] {  new DateTime(2021, 09, 28, 09, 22, 20), new DateTime(2021, 09, 28, 10, 22, 20), 1.10m },
        };




        [Theory, MemberData(nameof(CorrectData))]
        public void Short_Stay_Should_Cost_1_10_On_Return_For_Hour(DateTime value1, DateTime value2, decimal expected)
        {

            // Act
            var actual = _shortStayParking.Calculate(value1, value2);

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
            Action actual= () => _shortStayParking.Calculate(startDate, endDate);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(actual);
            Assert.Equal("Start date can't be earlier than end date!", exception.Message);

        }


        [Theory] 
        [InlineData(18, 20, 0)]
        [InlineData(21, 23, 0)]
        [InlineData(04, 06, 0)]
        public void Short_Stay_Should_Cost_0_On_Return_Outside_Charg_Hours(int hour1, int hour2, decimal expected)
        {
            // Arrange
            var startDate = new DateTime(2021, 09, 28, hour1, 00, 0);
            var endDate = new DateTime(2021, 09, 28, hour2, 00, 0);
            
            // Act
            var actual = _shortStayParking.Calculate(startDate, endDate);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 15, 0.275)]
        [InlineData (15, 30, 0.275)]
        [InlineData(30, 45, 0.275)]
        public void Short_Stay_Should_Charge_0_275_For_15_Minutes_In_Chargabe_Hours(int minutes1, int minutes2, decimal expected)
        {
            // Arrange
            var startDate = new DateTime(2021, 09, 28, 10 , minutes1, 0);
            var endDate = new DateTime(2021, 09, 28, 10, minutes2 , 0);

            // Act
            var actual = _shortStayParking.Calculate(startDate, endDate);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(17, 00, 20, 30, 1.10)]
        [InlineData(04, 00, 09, 00, 1.10)]
        public void Short_Stay_Should_Charge_Only_From_8PM_To_6PM(int hours1, int minutes1, int hours2, int minutes2, decimal expected)
        {
            // Arrange
            var startDate = new DateTime(2021, 09, 28, hours1, minutes1, 0);
            var endDate = new DateTime(2021, 09, 28, hours2, minutes2, 0);

            // Act
            var actual = _shortStayParking.Calculate(startDate, endDate);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 11.0)]
        [InlineData(2, 22.0)]
        [InlineData(3, 33.0)]
        [InlineData(4, 44.0)]
        [InlineData(5, 55.0)]
        [InlineData(6, 55)] // Weekeend no charge!
        [InlineData(7, 55)] // Weekeend no charge!
        [InlineData(8, 66.0)]
        [InlineData(9, 77.0)]
        [InlineData(10, 88.0)]
        public void Short_Stay_Charge_Calculate_For_10_Days(int days, decimal expected)
        {
            // Arrange
            var startDate = new DateTime(2021, 09, 06, 00, 00, 0);
            var endDate = new DateTime(2021, 09, 06+days, 00, 00, 00);

            // Act
            var actual = _shortStayParking.Calculate(startDate, endDate);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}