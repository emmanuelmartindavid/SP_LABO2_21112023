using Entities.Controllers;
using Entities.Handlers;
using Entities.Models;
using Entities.SQLLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace UIHotel
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var host = Host.CreateDefaultBuilder()
                  .ConfigureServices((context, services) =>
                     {
                         services.AddScoped<ContextDb, ContextDb>();
                         services.AddScoped<IDataBaseGenericRepository<Guest>, GuestRepository>();
                         services.AddScoped<IDataBaseGenericRepository<Reservation>, ReservationRepository>();
                         services.AddScoped<IDataBaseGenericRepository<Room>, RoomRepository>();
                         services.AddScoped<GuestController, GuestController>();
                         services.AddScoped<RoomController, RoomController>();
                         services.AddScoped<ReservationController, ReservationController>();
                     })
                  .Build();
            using var serviceScope = host.Services.CreateScope();
            var services = serviceScope.ServiceProvider;
            try
            {
                var guestController = services.GetRequiredService<GuestController>();
                var roomController = services.GetRequiredService<RoomController>();
                var reservationController = services.GetRequiredService<ReservationController>();


                Application.Run(new FrmPrincipal(guestController, roomController, reservationController));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
