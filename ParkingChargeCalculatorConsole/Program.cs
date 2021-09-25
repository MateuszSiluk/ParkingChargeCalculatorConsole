using Microsoft.Extensions.DependencyInjection;
using ParkingChargeCalculator;
using ParkingChargeCalculator.Interfaces;
using ParkingChargeCalculatorConsole;

var serviceProvider = new ServiceCollection()
                        .AddScoped<App>()
                        .AddTransient<ILongStayParking, LongStayParking>()
                        .BuildServiceProvider();

serviceProvider.GetService<App>()?.Run();
