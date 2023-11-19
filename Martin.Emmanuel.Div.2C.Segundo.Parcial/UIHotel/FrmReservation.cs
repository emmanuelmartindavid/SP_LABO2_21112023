using Entities.Controllers;
using Entities.Models;
using Entities.Serialization;
using Entities.Utilities;
using Entities.Validators;

namespace UIHotel
{

    public partial class FrmReservation : Form
    {
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        private readonly DataEntryValidator _dataEntryValidator;


        public FrmReservation()
        {
            this.InitializeComponent();
            this._guestController = new();
            this._roomController = new();
            this._reservationController = new();
            this._dataEntryValidator = new();
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
                await this._roomController.UpdateRoomAvailability(room.Number, false);
                room.Available = false;
                var bill = new Billing(guest, room, reservation);
                UtilityClass.billings.Add(bill);
                JSONSerialization.SerializeBillings(UtilityClass.billings);
                await this.UpdateDataComboBox();
                this.UpdateBillingCombobox();
                MessageBox.Show("Reserva generada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FrmPrincipal frmPrincipal = new();
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
                var rooms = await this._roomController.GetAvailableRooms();
                this.cmbRoomNumber.DataSource = rooms;
                this.cmbRoomNumber.DisplayMember = "DisplayProperty";
                var guests = await _guestController.GetAllGuests();
                this.cmbGuests.DataSource = guests;
                this.cmbGuests.DisplayMember = "DisplayProperty";
                this.dtpCheckIn.MinDate = new DateTime(2023, 11, 17, 0, 0, 0, 0);
                this.dtpCheckIn.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
                this.dtpCheckOut.MinDate = new DateTime(2023, 11, 18, 0, 0, 0, 0);
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

            //METODO PARA ACTUALIZAR EL COMBOBOX CON LOS DATOS DEL JSON TO DO.
        }
        /// <summary>
        /// Actualiza el comboBox con los datos del JSON.
        /// </summary>
        private void UpdateBillingCombobox()
        {
            try
            {
                UtilityClass.billings = JSONSerialization.DeserializeBillings();
                this.cmbJsonBillingData.DataSource = UtilityClass.billings;
                this.cmbJsonBillingData.DisplayMember = "DisplayProperty";
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al actualizar los datos{ex.Message}");
            }
        }
    }
}
