﻿using Entities.Handlers.ReservationExceptions;
using Entities.Models;
using Entities.SQLLogic;
using System.Data;
using System.Data.SqlClient;

namespace Entities.Handlers
{
    public class ReservationHandler : CommandDataBase, IManagementDataBase<Reservation>
    {

        /// <summary>
        /// Agrerga una reservacion a la base de datos
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public async Task Add(Reservation reservation)
        {
            try
            {
                string query = "INSERT INTO Reservaciones (DniHuesped, CheckIn, CheckOut, NumeroHabitacion)" +
                "values (@dniGuest, @checkIn, @checkOut, @roomNumber)";
                using (var command = await CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@dniGuest", reservation.DniGuest);
                    command.Parameters.AddWithValue("@checkIn", reservation.ChekIn);
                    command.Parameters.AddWithValue("@checkOut", reservation.CheckOut);
                    command.Parameters.AddWithValue("@roomNumber", reservation.RoomNumber);
                    await ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                throw new ReservationNotAddedException(ex);
            }

        }

        /// <summary>
        /// Borra una reservacion de la base de datos
        /// </summary>
        /// <param name="dniGuest"></param>
        /// <returns></returns>
        public async Task Delete(int dniGuest)
        {
            try
            {
                string query = "DELETE FROM Reservaciones WHERE DniHuesped = @dniGuest";
                using (var command = await CreateCommand(query))
                {
                    command.Parameters.AddWithValue("dniGuest", dniGuest);
                    await ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                throw new ReservationNotDeletedException(ex);
            }

        }


        /// <summary>
        /// Obtiene todas las reservaciones de la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<List<Reservation>> GetAll()
        {
            try
            {
                var reservations = new List<Reservation>();
                string query = "SELECT * FROM Reservaciones";
                using (var command = await CreateCommand(query))
                {
                    using (var table = await ExecuteReader(command))
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            reservations.Add((Reservation)row);
                        }
                    }
                }
                return reservations;
            }
            catch (SqlException ex)
            {
                throw new ReservationNotObtainedException(ex);
            }

        }

        /// <summary>
        /// Obtiene una reservacion de la base de datos por su dni
        /// </summary>
        /// <param name="dniGuest"></param>
        /// <returns></returns>
        public async Task<Reservation> GetById(int dniGuest)
        {
            try
            {
                string query = "SELECT * FROM Reservaciones WHERE DniHuesped = @dniGuest";
                using (var command = await CreateCommand(query))
                {
                    command.Parameters.AddWithValue("@dniGuest", dniGuest);
                    using (var table = await ExecuteReader(command))
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            return (Reservation)row;
                        }
                    }
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new ReservationNotObtainedException(ex);
            }

        }
        /// <summary>
        /// Actualiza una reservacion de la base de datos
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public async Task Update(Reservation reservation)
        {
            try
            {
                string query = "UPDATE Reservaciones SET DniHuesped = @dniGuest, CheckIn = @checkIn, CheckOut = @checkOut, " +
                "NumeroHabitacion = @RoomNumber WHERE DniHuesped = @dniGuest";
                using (var command = await CreateCommand(query))
                {
                    command.Parameters.AddWithValue("dniGuest", reservation.DniGuest);
                    command.Parameters.AddWithValue("checkIn", reservation.ChekIn);
                    command.Parameters.AddWithValue("checkOut", reservation.CheckOut);
                    command.Parameters.AddWithValue("roomNumber", reservation.RoomNumber);
                    await ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                throw new ReservationNotUpdatedException(ex);
            }

        }
    }
}
