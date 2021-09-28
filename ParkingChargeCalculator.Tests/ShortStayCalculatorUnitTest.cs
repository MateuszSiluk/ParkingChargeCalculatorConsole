using Moq;
using ParkingChargeCalculator.Interfaces;
using System;
using Xunit;

namespace ParkingChargeCalculator.Tests
{

    public class ShortStayCalculatorUnitTest
    {

        public static readonly object[][] CorrectData =
        {
            new object[] {  new DateTime(2019, 09, 09, 16, 50, 00), new DateTime(2019, 09, 09, 17, 50, 00), 1.10m },
            new object[] {  new DateTime(2021, 09, 28, 10, 11, 00), new DateTime(2021, 09, 28, 11, 11, 00), 1.10m },
            new object[] {  new DateTime(2021, 09, 28, 09, 22, 20), new DateTime(2021, 09, 28, 10, 22, 20), 1.10m },
        };




        [Theory, MemberData(nameof(CorrectData))]
        public void Short_Stay_Should_Cost_1_10_On_Return_For_Hour(DateTime value1, DateTime value2, decimal expected)
        {
            var mock = new Mock<IFreeParkingCheck>();
            mock.Setup(x => x.IsNotFreeParking(It.IsAny<DateTime>())).Returns(true);
            ShortStayParking shortStayParking = new ShortStayParking(mock.Object);
            var actual = shortStayParking.Calculate(value1, value2);   

            
            Assert.Equal(expected, actual);
        }

        [Theory] 
        [InlineData(11, 11, 0)]
        [InlineData(12, 12, 0)]
        [InlineData(17, 17, 0)]
        public void Short_Stay_Should_Cost_0_On_Return_(int hour1, int hour2, decimal expected)
        {
            var mock = new Mock<IFreeParkingCheck>();
            mock.Setup(x => x.IsNotFreeParking(It.IsAny<DateTime>())).Returns(true);
            ShortStayParking shortStayParking = new ShortStayParking(mock.Object);
            var actual = shortStayParking.Calculate(new DateTime(2021, 09, 28, hour1, 22, 00), new DateTime(2021, 09, 28, hour2, 22, 00));


            Assert.Equal(expected, actual);
        }


    }
}