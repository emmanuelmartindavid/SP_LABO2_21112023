using Entities.Controllers;
using Entities.Models;
using Entities.Utilities;
using Entities.Validators;
using Entities.Exceptions;
using Entities.Handlers.RoomExceptions;
using Entities.Handlers.ReservationExceptions;

namespace UIHotel
{

    public partial class FrmReservationHandler : Form
    {
        private readonly ReservationController _reservationController;
        private readonly RoomController _roomController;
        private readonly DataEntryValidator _dataEntryValidator;

        public FrmReservationHandler()
        {
            InitializeComponent();
            this._reservationController = new();
            this._roomController = new();
            this._dataEntryValidator = new();
        }

        /// <summary>
        /// Evento Click para btnAddReservation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmReservationHandler_Load(object sender, EventArgs e)
        {
            this.UpdateReservationsGrid();
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
                        await this._roomController.UpdateRoomAvailability(reservation.RoomNumber, true);
                        await this._reservationController.Delete(reservation);
                        MessageBox.Show("Reserva eliminada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.UpdateReservationsGrid();
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
                        await this._roomController.UpdateRoomAvailability(reservation.RoomNumber, true);
                        await this._roomController.UpdateRoomAvailability(roomNumber, false);
                    }
                    var newReservation = new Reservation
                    {
                        DniGuest = reservation.DniGuest,
                        ChekIn = this.dtpCheckIn.Value,
                        CheckOut = this.dtpCheckOut.Value,
                        RoomNumber = roomNumber
                    };
                    await this._reservationController.UpdateReservation(newReservation);
                    this.UpdateReservationsGrid();
                    MessageBox.Show("Reserva actualizada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FrmPrincipal frmPrincipal = new();
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
                this.dtpCheckIn.Text = reservation.ChekIn.ToString();
                this.dtpCheckOut.Text = reservation.CheckOut.ToString();
                this.txtRoomNumber.Text = reservation.RoomNumber.ToString();
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
        private async void UpdateReservationsGrid()
        {
            try
            {
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

    }
}

