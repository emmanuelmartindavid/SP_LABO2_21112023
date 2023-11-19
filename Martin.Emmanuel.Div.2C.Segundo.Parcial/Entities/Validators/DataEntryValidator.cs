using Entities.Controllers;
using Entities.Exceptions;
using Entities.Models;

namespace Entities.Validators
{
    public class DataEntryValidator
    {
        private static ReservationController? _reservationController;
        private static RoomController? _roomController;
        private static GuestController? _guestController;
        public DataEntryValidator()
        {
            _reservationController = new();
            _roomController = new();
            _guestController = new();
        }

        /// <summary>
        /// Valida el DNI del huésped.
        /// </summary>
        /// <param name="dni">El DNI del huésped a validar.</param>
        /// <exception cref="WrongGuestDniException">Se lanza cuando el DNI ingresado no es válido.</exception>
        public void ValidateDniGuest(string dni)
        {
            if (!(int.TryParse(dni, out int number) && number > 10000000 && number < 45000000))
            {
                throw new WrongGuestDniException("El DNI ingresado no es valido");
            }
        }

        /// <summary>
        /// Valida el número de teléfono del huésped.
        /// </summary>
        /// <param name="phoneNumber">El número de teléfono del huésped a validar.</param>
        /// <exception cref="WrongPhoneNumberGuestException">Se lanza cuando el número de teléfono ingresado no es válido.</exception>
        public void ValidatePhoneNumberGuest(string phoneNumber)
        {
            if (!(long.TryParse(phoneNumber, out long number) && number > 1000000000 && number < 9999999999))
            {
                throw new WrongPhoneNumberGuestException("El numero de telefono ingresado no es valido");
            }
        }

        /// <summary>
        /// Valida el nombre y apellido del huésped.
        /// </summary>
        /// <param name="name">El nombre del huésped a validar.</param>
        /// <param name="lastname">El apellido del huésped a validar.</param>
        /// <exception cref="WrongGuestNameException">Se lanza cuando el nombre o apellido ingresado no es válido.</exception>
        public void ValidateNameGuest(string name, string lastname)
        {
            if (name.Length < 3 || name.Length > 20)
            {
                throw new WrongGuestNameException("El nombre ingresado no es valido");
            }
            if (lastname.Length < 3 || lastname.Length > 20)
            {
                throw new WrongGuestNameException("El apellido ingresado no es valido");
            }
        }
        /// <summary>
        /// Valida la existencia del huésped.
        /// </summary>
        /// <param name="dni">El DNI del huésped a validar.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="GuestExistsException">Se lanza cuando el DNI del huésped ingresado ya existe en el sistema.</exception>
        public async Task ValidateGuestExistence(int dni)
        {
            var guest = await _guestController.GuestExists(dni);
            if (guest)
            {
                throw new GuestExistsException("El DNI del huesped ingresado ya existe en sistema.");
            }
        }

        /// <summary>
        /// Valida la existencia del huésped.
        /// </summary>
        /// <param name="newDni"></param>
        /// <param name="originalDni"></param>
        /// <returns></returns>
        /// <exception cref="GuestExistsException"></exception>
        public async Task ValidateGuestExistence(int newDni, int originalDni)
        {
            if (newDni == originalDni)
            {
                return;
            }
            var guest = await _guestController.GuestExists(newDni);
            if (guest)
            {
                throw new GuestExistsException("El DNI del huesped ingresado ya existe en sistema.");
            }

        }
        /// <summary>
        /// Valida los datos de la reserva.
        /// </summary>
        /// <param name="checkIn">La fecha de entrada a validar.</param>
        /// <param name="checkOut">La fecha de salida a validar.</param>
        /// <exception cref="WrongReservationDateException">Se lanza cuando los datos ingresados no son válidos o la fecha de entrada es mayor a la fecha de salida.</exception>
        public void ValidateReservationData(string checkIn, string checkOut)
        {
            if (DateTime.TryParse(checkIn, out DateTime dateCheckIn) && DateTime.TryParse(checkOut, out DateTime dateCheckOut))
            {
                if (dateCheckIn > dateCheckOut)
                {
                    throw new WrongReservationDateException("La fecha de entrada no puede ser mayor a la fecha de salida");
                }
            }
            throw new WrongReservationDateException("Los datos ingresados no son validos");
        }

        /// <summary>
        /// Valida la existencia de la reserva.
        /// </summary>
        /// <param name="reservation">La reserva a validar.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="ReservationExistsException">Se lanza cuando ya existe una reserva para el huésped.</exception>
        public async Task ValidateReservationExistence(Reservation reservation)
        {
            var reservations = await _reservationController.GetAllReservations();
            foreach (var item in reservations)
            {
                if (item.DniGuest == reservation.DniGuest)
                {
                    throw new ReservationExistsException("Ya existe una reserva para este huesped");
                }
            }
        }
        /// <summary>
        /// Valida la existencia de la reserva.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public async Task<bool> ValidateReservationExistence(int dni)
        {
            var reservations = await _reservationController.GetAllReservations();
            foreach (var item in reservations)
            {
                if (item.DniGuest == dni)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Valida la existencia de la habitación.
        /// </summary>
        /// <param name="roomNumber">El número de la habitación a validar.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
        /// <exception cref="RoomExistsException">Se lanza cuando la habitación ingresada no existe en el sistema.</exception>
        public async Task ValidateRoomExistence(int roomNumber)
        {
            var rooms = await _roomController.GetAllRooms();
            foreach (var item in rooms)
            {
                if (item.Number == roomNumber)
                {
                    return;
                }
            }
            throw new RoomExistsException("La habitacion ingresada no existe en sistema."); ;
        }
        /// <summary>
        /// Valida la existencia de la habitación.
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        /// <exception cref="RoomExistsException"></exception>
        public async Task ValidateRoomExistenceForNewRoom(int roomNumber)
        {
            var rooms = await _roomController.GetAllRooms();
            foreach (var item in rooms)
            {
                if (item.Number == roomNumber)
                {
                    throw new RoomExistsException("La habitacion ingresada ya existe en sistema.");
                }
            }

        }
        /// <summary>
        /// Valida el número de la habitación.
        /// </summary>
        /// <param name="roomNumber">El número de la habitación a validar.</param>
        /// <returns>El número de la habitación si es válido.</returns>
        /// <exception cref="WrongRoomNumberException">Se lanza cuando el número de la habitación ingresado no es válido.</exception>
        public int ValidateRoomNumber(string roomNumber)
        {
            if (int.TryParse(roomNumber, out int number))
            {
                return number;
            }
            throw new WrongRoomNumberException("Ingrese solo numeros.");
        }
    }
}
