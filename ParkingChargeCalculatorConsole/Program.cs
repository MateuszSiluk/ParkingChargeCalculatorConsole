using Microsoft.Extensions.DependencyInjection;
using ParkingChargeCalculator;
using ParkingChargeCalculator.Interfaces;
using ParkingChargeCalculatorConsole;

var serviceProvider = new ServiceCollection()
                        .AddScoped<App>()
                        .AddSingleton<ILongStayParking, LongStayParking>()
                        .AddSingleton<IShortStayParking, ShortStayParking>()
                        .AddSingleton<IFreeParkingCheck, FreeParkingCheck>()
                        .BuildServiceProvider();

serviceProvider.GetService<App>()?.Run();
