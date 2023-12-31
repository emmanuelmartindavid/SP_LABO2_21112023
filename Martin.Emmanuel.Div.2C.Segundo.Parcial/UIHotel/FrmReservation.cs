﻿using Entities.Controllers;
using Entities.Models;
using Entities.Serialization;
using Entities.Utilities;
using Entities.Validators;

namespace UIHotel
{

    public partial class FrmReservation : BaseFormTrack
    {
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        private readonly DataEntryValidator _dataEntryValidator;

        public FrmReservation()
        {
            this.InitializeComponent();
        }

        public FrmReservation(GuestController guestController, RoomController roomController, ReservationController reservationController)
        {
            this.InitializeComponent();
            this._guestController = guestController;
            this._roomController = roomController;
            this._reservationController = reservationController;
            this._dataEntryValidator = new();
            this.OnUserTracker += OnUserAction;
        }
        /// <summary>
        /// Manejador del evento Load de FrmReservation.
        /// Evento de carga del formulario de reservas, actualiza los comboBOx. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmReservation_Load(object sender, EventArgs e)
        {
            await this.UpdateDataComboBox();

        }
        /// <summary>
        /// Evento de clic en el botón de generar reservacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnGenerateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                var guest = (Guest)this.cmbGuests.SelectedItem;
                var room = (Room)this.cmbRoomNumber.SelectedItem;
                var checkIn = DateTime.Parse(dtpCheckIn.Text);
                var checkOut = DateTime.Parse(dtpCheckOut.Text);
                if (guest == null || room == null)
                {
                    this.ShowError($"Error al generar la reserva:");
                    return;
                }
                var reservation = new Reservation
                {
                    DniGuest = guest.Dni,
                    ChekIn = checkIn,
                    CheckOut = checkOut,
                    RoomNumber = room.Number
                };
                await this._dataEntryValidator.ValidateReservationExistence(reservation);
                await this._reservationController.Add(reservation);

                var newRoom = await this._roomController.GetRoomByNumber(room.Number);
                newRoom.Available = false;
                await this._roomController.UpdateRoom(newRoom);

                room.Available = false;
                var bill = new Billing(guest, room, reservation);
                UtilityClass.Billings.Add(bill);
                JSONSerialization.SerializeBillings(UtilityClass.Billings);
                await this.UpdateDataComboBox();
                this.UpdateBillingCombobox();
                MessageBox.Show("Reserva generada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TriggerUserTracker($"Usuario genera una reservacion en sistema. {DateTime.Now} a nombre de {guest.Name}, {guest.LastName}");
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al generar la reserva:{ex.Message}");
            }
        }

        /// <summary>
        /// Evento de cierre del formulario de reservaciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmReservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmPrincipal frmPrincipal = new(_guestController, _roomController, _reservationController);
            frmPrincipal.Show();
        }
        /// <summary>
        /// Actualiza los datos en los comboBox.
        /// </summary>
        /// <returns></returns>
        private async Task UpdateDataComboBox()
        {
            try
            {
                this.cmbRoomNumber.DataSource = null;
                this.cmbGuests.DataSource = null;
                var rooms = await this._roomController.GetAllRooms();
                var availableRooms = rooms.Where(room => room.Available).ToList();
                this.cmbRoomNumber.DataSource = availableRooms;
                this.cmbRoomNumber.DisplayMember = "DisplayProperty";
                var guests = await _guestController.GetAllGuests();
                this.cmbGuests.DataSource = guests;
                this.cmbGuests.DisplayMember = "DisplayProperty";
                this.dtpCheckIn.MinDate = new DateTime(2023, 11, 23, 0, 0, 0, 0);
                this.dtpCheckIn.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
                this.dtpCheckOut.MinDate = new DateTime(2023, 11, 24, 0, 0, 0, 0);
                this.dtpCheckOut.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al actualizar los datos{ex.Message}");
            }

        }
        /// <summary>
        /// Muestra un mensaje de error.
        /// </summary>
        /// <param name="message"></param>
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Evento de clic en el botón de actualizar datos del JSON.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJsonData_Click(object sender, EventArgs e)
        {
            this.UpdateBillingCombobox();
        }
        /// <summary>
        /// Actualiza el comboBox con los datos del JSON.
        /// </summary>
        private void UpdateBillingCombobox()
        {
            try
            {
                this.cmbJsonBillingData.DataSource = null;
                UtilityClass.Billings = JSONSerialization.DeserializeBillings();
                this.cmbJsonBillingData.DataSource = UtilityClass.Billings;
                this.cmbJsonBillingData.DisplayMember = "DisplayProperty";
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al actualizar los datos{ex.Message}");
            }
        }
        /// <summary>
        /// Agrega accion de usuario a la lista de acciones.
        /// </summary>
        /// <param name="action"></param>
        private void OnUserAction(string action)
        {
            UtilityClass.ActionLog.Add(action);
        }
    }
}
