using Entities.Controllers;
using Entities.Handlers;
using Entities.Models;
using Entities.Serialization;
using Entities.SQLLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace PruebaUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {   
      
          // var GuestController = new GuestController();
          var Reservations = new ReservationHandler();  
          var ReservationController = new ReservationController( Reservations);  

            var reservation = await ReservationController.GetAllReservationsconI();

            foreach (var item in reservation)
            {
                Console.WriteLine(item);
            }


            /*var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<CommandDataBase, CommandDataBase>();
                    services.AddScoped<IManagementDataBase<Guest>, GuestHandler>();
                    services.AddScoped<GuestController, GuestController>();
                })
                .Build();

            using var serviceScope = host.Services.CreateScope();
            var services = serviceScope.ServiceProvider;

            var controller = services.GetRequiredService<GuestController>();*/



           /* var RoomController = new RoomController();
            var ReservationController = new ReservationController();
            //var JSONManager = new JSONManagment();
            List<Billing> billings = new();


            Guest guest = new();

            Room room = new();

            Reservation reservation = new();

            guest = await GuestController.GetGuestByDni(43437966);
*/

            // room = await RoomController.GetRoomByNumber(103);

            //reservation = await ReservationController.GetReservationByDni(43437966);

            //Console.WriteLine(guest);






            //Reservation reservation = new(guest.Dni, new DateTime(2022, 4, 10), new DateTime(2022, 4, 15), 103);

            //var ReservationController = new ReservationController();

            // await ReservationController.Add(reservation);

            //room = await RoomController.GetRoomByNumber(reservation.RoomNumber);


            /*  Billing billing = new(guest, room, reservation);

              billings.Add(billing);

              foreach (var item in billings)
              {
                  JSONSerialization.SerializeBillings(item.ToString());
              }


              Console.WriteLine(billing);
  */




            /* if (!await GuestController.GuestExists(guest.Dni))
             {
                 // El huésped no existe, puedes agregarlo
                 await GuestController.Add(guest);
                 Console.WriteLine("Huésped agregado exitosamente.");
             }
             else
             {
                 Console.WriteLine("El huésped ya existe en la base de datos. No puede volver a ser agregado");
             }
 */

            /* utility.Guests = GuestController.GetAllGuests().Result;

             foreach (var item in utility.Guests)
             {
                 Console.WriteLine(item);
             }*/

            /*   var RoomController = new RoomController();

               utility.Rooms = await RoomController.GetAllRooms();

               foreach (var item in utility.Rooms)
               {
                   Console.WriteLine(item);
               }

               var ReservationController = new ReservationController();

               utility.Reservations = await ReservationController.GetAllReservations();

               foreach (var item in utility.Reservations)
               {
                   Console.WriteLine(item);
               }*/


        }
    }
}