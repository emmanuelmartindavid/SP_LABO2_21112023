using Entities.Controllers;
using Entities.Models;
using Entities.Serialization;
using Entities.Utilities;
namespace UIHotel
{
    public partial class FrmPrincipal : Form
    {
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;

        public FrmPrincipal()
        {
            InitializeComponent();
        }
        public FrmPrincipal(GuestController guestController, RoomController roomController, ReservationController reservationController)
        {
            InitializeComponent();
            this._guestController = guestController;
            this._roomController = roomController;
            this._reservationController = reservationController;
        }
        /// <summary>
        /// Evento que se ejecuta al cargar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                UtilityClass.billings = JSONSerialization.DeserializeBillings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar el archivo JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);         
            }
        }
        /// <summary>
        /// Evento que se ejecuta al cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFrmReservation_Click(object sender, EventArgs e)
        {
            FrmReservation frmReservation = new(_guestController, _roomController, _reservationController);
            frmReservation.Show();
            this.Hide();
        }
        /// <summary>
        /// Evento que se ejecuta al hacer click en el boton de "Huespedes Registrados"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRegisteredGuests_Click(object sender, EventArgs e)
        {
            var guests = await _guestController.GetAllGuests();
            guests.OrderGuestByLastName();
            dgvMainData.DataSource = guests;

            dgvMainData.Columns[0].HeaderText = "DNI";
            dgvMainData.Columns[1].HeaderText = "Nombre";
            dgvMainData.Columns[2].HeaderText = "Apellido";
            dgvMainData.Columns[3].HeaderText = "Nro Telefono";
            dgvMainData.Columns[4].Visible = false;

        }
        /// <summary>
        /// Evento que se ejecuta al hacer click en el boton de "Historial de Reservas"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnReservationsHistory_Click(object sender, EventArgs e)
        {

            var reservations = await _reservationController.GetAllReservations();
            dgvMainData.DataSource = reservations;
            dgvMainData.Columns[0].HeaderText = "DNI";
            dgvMainData.Columns[1].HeaderText = "CheckIn";
            dgvMainData.Columns[2].HeaderText = "CheckOut";
            dgvMainData.Columns[3].HeaderText = "Nro Habitacion";
        }
        /// <summary>
        /// Evento que se ejecuta al hacer click en el boton de "Reservas Activas"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReservationHandler_Click(object sender, EventArgs e)
        {
            FrmReservationHandler frmReservationHandler = new(_guestController, _roomController, _reservationController);
            frmReservationHandler.Show();
            this.Hide();
        }
        /// <summary>
        /// Evento que se ejecuta al hacer click en el boton de "Registrar Huesped"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterGuest_Click(object sender, EventArgs e)
        {
            FrmGuest frmGuestRegister = new(EFrmType.Register, _guestController, _roomController, _reservationController);
            frmGuestRegister.Show();
            this.Hide();
        }
        /// <summary>
        /// Evento que se ejecuta al hacer click en el boton de "Editar Huesped"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHandlerGuest_Click(object sender, EventArgs e)
        {
            FrmGuest frmGuestRegister = new(EFrmType.Edit, _guestController, _roomController, _reservationController);
            frmGuestRegister.Show();
            this.Hide();
        }
        /// <summary>
        /// Evento que se ejecuta al hacer click en el boton de "Registrar Habitacion"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterRoom_Click(object sender, EventArgs e)
        {
            FrmRooms frmRoom = new(EFrmType.Register, _guestController, _roomController, _reservationController);
            frmRoom.Show();
            this.Hide();
        }
        /// <summary>
        /// Evento que se ejecuta al hacer click en el boton de "Editar Habitacion"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoomHanlder_Click(object sender, EventArgs e)
        {
            FrmRooms frmRoom = new(EFrmType.Edit, _guestController, _roomController, _reservationController);
            frmRoom.Show();
            this.Hide();
        }
        /// <summary>
        ///  Evento que se ejecuta al hacer click en el boton de "Data Json"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJsonData_Click(object sender, EventArgs e)
        {
            if (UtilityClass.billings.Count == 0)
            {
                this.cmbJsonBillingData.DataSource = new List<string> { "No hay nada para mostrar" };
            }
            else
            {
                this.cmbJsonBillingData.DataSource = UtilityClass.billings;
                this.cmbJsonBillingData.DisplayMember = "DisplayProperty";
            }
        }
    }
}