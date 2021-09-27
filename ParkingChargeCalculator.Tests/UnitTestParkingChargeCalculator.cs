using Moq;
using ParkingChargeCalculator.Interfaces;
using System;
using Xunit;

namespace ParkingChargeCalculator.Tests
{
    public class UnitTestParkingChargeCalculator
    {
        [Fact]
        public void Short_Stay_Cost_Return_1_10()
        {
            var mock = new Mock<IShortStayParking>();
            mock.Setup(x =>
            x.Calculate(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(1.10m);

            var actual = mock.Object.Calculate(It.IsAny<DateTime>(), It.IsAny<DateTime>());

            Assert.Equal(1.10m, actual);
        }

        [Fact]
        public void Long_Stay_Cost_Return_7_50_Per_Day()
        {
            var mock = new Mock<ILongStayParking>();
            mock.Setup(x =>
            x.Calculate(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(7.50m);

            var actual = mock.Object.Calculate(It.IsAny<DateTime>(), It.IsAny<DateTime>());

            Assert.Equal(7.50m, actual);
        }

        [Fact]
        public void Is_Not_Free_Parking_In_Mon_At_12_30()
        {
            DateTime date = new DateTime(2021, 09, 27, 12, 30, 00);
            var parking = new FreeParkingCheck();
            

            Assert.True(parking.IsNotFreeParking(date));
        }
        [Fact]
        public void Is_Free_Parking_In_Mon_At_18_30()
        {
            DateTime date = new DateTime(2021, 09, 27, 18, 30, 00);
            var parking = new FreeParkingCheck(); 
            

            Assert.False(parking.IsNotFreeParking(date));
        }

        [Fact]
        public void Is_Free_Parking_In_the_Weekend()
        {
            DateTime date = new DateTime(2021, 09, 25, 12, 30, 00);
            var parking = new FreeParkingCheck();


            Assert.False(parking.IsNotFreeParking(date));

        }
    }
}