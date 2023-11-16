using Entities.Controllers;
using Entities.Exceptions;
using Entities.Models;
using Entities.Validators;

namespace UIHotel
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmReservation : Form
    {
        private GuestController _guestController;
        private RoomController _roomController;
        private ReservationController _reservationController;
        private DataEntryValidator _dataEntryValidator;

        /// <summary>
        /// 
        /// </summary>
        public FrmReservation()
        {
            InitializeComponent();
            _guestController = new();
            _roomController = new();
            _reservationController = new();
            _dataEntryValidator = new();

        }
        /// <summary>
        /// Manejador del evento Load de FrmReservation.
        /// Evento de carga del formulario de reservas, actualiza los comboBOx. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmReservation_Load(object sender, EventArgs e)
        {
            await UpdateDataComboBox();

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

                var guest = (Guest)cmbGuests.SelectedItem;
                var room = (Room)cmbRoomNumber.SelectedItem;
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
                await _dataEntryValidator.ValidateReservationExistence(reservation);
                await _reservationController.Add(reservation);
                await _roomController.UpdateRoomAvailability(room.Number, false);
                await UpdateDataComboBox();
                MessageBox.Show("Reserva generada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidateDataReservationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error inesperado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Evento de clic en el botón de registrar nuevo huésped.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterNewGuest_Click(object sender, EventArgs e)
        {
            FrmGuest frmGuest = new(EFrmType.Register);
            frmGuest.Show();
            this.Hide();

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
            var rooms = await _roomController.GetAvailableRooms();
            cmbRoomNumber.DataSource = rooms;
            cmbRoomNumber.DisplayMember = "DisplayProperty";
            var guests = await _guestController.GetAllGuests();
            cmbGuests.DataSource = guests;
            cmbGuests.DisplayMember = "DisplayProperty";
            this.dtpCheckIn.MinDate = new DateTime(2023, 11, 17, 0, 0, 0, 0);
            this.dtpCheckIn.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.dtpCheckOut.MinDate = new DateTime(2023, 11, 18, 0, 0, 0, 0);
            this.dtpCheckOut.MaxDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
        }
    }
}
