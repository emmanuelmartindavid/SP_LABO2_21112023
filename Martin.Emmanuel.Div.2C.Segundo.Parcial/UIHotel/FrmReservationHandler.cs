using Entities.Controllers;
using Entities.Models;
using Entities.Utilities;
using Entities.Validators;

namespace UIHotel
{

    public partial class FrmReservationHandler : BaseFormTrack
    {
        private readonly GuestController _guestController;
        private readonly ReservationController _reservationController;
        private readonly RoomController _roomController;
        private readonly DataEntryValidator _dataEntryValidator;

        public FrmReservationHandler()
        {
            InitializeComponent();
        }
        public FrmReservationHandler(GuestController guestController, RoomController roomController, ReservationController reservationController)
        {
            this.InitializeComponent();
            this._guestController = guestController;
            this._roomController = roomController;
            this._reservationController = reservationController;
            this._dataEntryValidator = new();
            this.OnUserTracker += OnUserAction;
        }

        /// <summary>
        /// Evento Click para btnAddReservation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmReservationHandler_Load(object sender, EventArgs e)
        {
            await this.UpdateReservationsGrid();
        }

        /// <summary>
        /// Evento Click para btnAddReservation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvReservationHandler.CurrentRow != null)
            {
                try
                {
                    var reservation = (Reservation)this.dgvReservationHandler.CurrentRow.DataBoundItem;
                    if (reservation is not null)
                    {
                        var room = await this._roomController.GetRoomByNumber(reservation.RoomNumber);
                        room.Available = true;
                        await this._roomController.UpdateRoom(room);
                        await this._reservationController.Delete(reservation);
                        MessageBox.Show("Reserva eliminada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await this.UpdateReservationsGrid();
                        this.TriggerUserTracker($"Usuario elimina Reserva: {DateTime.Now} - DNI: {reservation.DniGuest}");
                    }
                }
                catch (Exception ex)
                {
                    this.ShowError($"Error al eliminar la reserva: {ex.Message}");
                }
            }
            else
            {
                this.ShowError("No hay reservas para eliminar");
            }
        }

        /// <summary>
        /// Evento Click para btnAddReservation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvReservationHandler.CurrentRow == null)
                {
                    this.ShowError("No hay reservas para actualizar");
                    return;
                }
                var reservation = (Reservation)this.dgvReservationHandler.CurrentRow.DataBoundItem;
                if (reservation is not null)
                {
                    var roomNumber = _dataEntryValidator.ValidateRoomNumber(this.txtRoomNumber.Text);
                    await _dataEntryValidator.ValidateRoomExistence(roomNumber);
                    _dataEntryValidator.ValidateReservationData(this.dtpCheckIn.Text, this.dtpCheckOut.Text);
                    if (roomNumber != reservation.RoomNumber)
                    {
                        var room = await this._roomController.GetRoomByNumber(reservation.RoomNumber);
                        room.Available = true;
                        await this._roomController.UpdateRoom(room);
                        var newRoom = await this._roomController.GetRoomByNumber(roomNumber);
                        newRoom.Available = false;
                        await this._roomController.UpdateRoom(newRoom);
                    }
                    var newReservation = new Reservation
                    {
                        DniGuest = reservation.DniGuest,
                        ChekIn = this.dtpCheckIn.Value,
                        CheckOut = this.dtpCheckOut.Value,
                        RoomNumber = roomNumber
                    };
                    await this._reservationController.UpdateReservation(newReservation);
                    await this.UpdateReservationsGrid();
                    MessageBox.Show("Reserva actualizada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.TriggerUserTracker($"Usuario modifica Reserva: {DateTime.Now} - DNI: {reservation.DniGuest}");
                }
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al actualizar la reserva: {ex.Message}");
            }
        }

        /// <summary>
        /// Evento Click para btnAddReservation.
        /// </summary>
        private void FrmReservationHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmPrincipal frmPrincipal = new(_guestController, _roomController, _reservationController);
            frmPrincipal.Show();
            this.Hide();

        }
        /// <summary>
        /// Actualiza los campos de texto con los datos de la reserva seleccionada en el DataGridView.
        /// </summary>
        private void UpdateTxtView()
        {
            var reservation = (Reservation)this.dgvReservationHandler.CurrentRow.DataBoundItem;
            if (reservation is not null)
            {
                 this.dtpCheckIn.MinDate = new DateTime(2023, 11, 23, 0, 0, 0, 0);
                  this.dtpCheckIn.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
                  this.dtpCheckOut.MinDate = new DateTime(2023, 11, 24, 0, 0, 0, 0);
                  this.dtpCheckOut.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
                this.dtpCheckIn.Value = reservation.ChekIn;
                this.dtpCheckOut.Value = reservation.CheckOut;
                this.txtRoomNumber.Text = reservation.RoomNumber.ToString();
                /*  this.dtpCheckIn.Text = reservation.ChekIn.ToString();
                  this.dtpCheckOut.Text = reservation.CheckOut.ToString();
                  this.txtRoomNumber.Text = reservation.RoomNumber.ToString();
                  this.dtpCheckIn.MinDate = new DateTime(2023, 11, 23, 0, 0, 0, 0);
                  this.dtpCheckIn.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
                  this.dtpCheckOut.MinDate = new DateTime(2023, 11, 24, 0, 0, 0, 0);
                  this.dtpCheckOut.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);*/
            }
        }
        /// <summary>
        /// Actualiza los encabezados de las columnas del DataGridView.
        /// </summary>
        private void UpdateDatGrid()
        {
            this.dgvReservationHandler.Columns[0].HeaderText = "DNI";
            this.dgvReservationHandler.Columns[1].HeaderText = "CheckIn";
            this.dgvReservationHandler.Columns[2].HeaderText = "CheckOut";
            this.dgvReservationHandler.Columns[3].HeaderText = "Nro Habitacion";
        }

        /// <summary>
        /// Actualiza el DataGridView con las reservas actuales.
        /// </summary>
        private async Task UpdateReservationsGrid()
        {
            try
            {
                this.dgvReservationHandler.DataSource = null;
                var reservations = await _reservationController.GetAllReservations();
                this.dgvReservationHandler.DataSource = reservations;
                this.UpdateDatGrid();
                if (reservations.Count > 0)
                {
                    this.lblReservationsDgv.Text = "Reservas";
                    this.UpdateTxtView();
                }
                else
                {
                    this.DeleteData();
                }
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al actualizar las reservas: {ex.Message}");
            }

        }

        /// <summary>
        /// Borra los datos de los campos de texto y el DataGridView.
        /// </summary>
        public void DeleteData()
        {
            this.dtpCheckIn.Text = string.Empty;
            this.dtpCheckOut.Text = string.Empty;
            this.txtRoomNumber.Text = string.Empty;
            this.lblReservationsDgv.Text = "No hay reservas";
            this.dgvReservationHandler.DataSource = null;
        }


        /// <summary>
        /// Muestra un mensaje de error.
        /// </summary>
        /// <param name="message">El mensaje de error a mostrar.</param>
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Agrega accion de usuario a la lista de acciones.
        /// </summary>
        /// <param name="action"></param>
        private void OnUserAction(string action)
        {
            UtilityClass.ActionLog.Add(action);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvReservationHandler_DoubleClick(object sender, EventArgs e)
        {
            this.UpdateTxtView();
        }
    }
}

