using Entities;
using Entities.Controllers;
using Entities.Models;
using Entities.Utilities;

namespace UIHotel
{
    public partial class FrmPrincipal : Form
    {

        private GuestController _guestController;
        private ReservationController _reservationController;


        public FrmPrincipal()
        {
            InitializeComponent();

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            _guestController = new();
            _reservationController = new();


        }

        private void btnFrmReservation_Click(object sender, EventArgs e)
        {

            FrmReservation frmReservation = new();
            frmReservation.Show();
            this.Hide();
        }

        /*    private async void btnRegisteredGuests_Click(object sender, EventArgs e)
            {
                var guests = await this._guestController.GetAllGuests();

                this.dgvMainData.AutoGenerateColumns = false;
                this.dgvMainData.Columns.Clear();

                this.dgvMainData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DNI", HeaderText = "DNI" });
                this.dgvMainData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Nombre" });
                this.dgvMainData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LastName", HeaderText = "Apellido" });
                this.dgvMainData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhoneNumber", HeaderText = "Nro Telefono" });

                this.dgvMainData.DataSource = guests;
            }*/
        private async void btnRegisteredGuests_Click(object sender, EventArgs e)
        {
            var guests = await _guestController.GetAllGuests();
            dgvMainData.DataSource = guests;

            dgvMainData.Columns[0].HeaderText = "DNI";
            dgvMainData.Columns[1].HeaderText = "Nombre";
            dgvMainData.Columns[2].HeaderText = "Apellido";
            dgvMainData.Columns[3].HeaderText = "Nro Telefono";
            dgvMainData.Columns[4].Visible = false;

        }

        private async void btnReservationsHistory_Click(object sender, EventArgs e)
        {

            var reservations = await _reservationController.GetAllReservations();
            dgvMainData.DataSource = reservations;
            dgvMainData.Columns[0].HeaderText = "DNI";
            dgvMainData.Columns[1].HeaderText = "CheckIn";
            dgvMainData.Columns[2].HeaderText = "CheckOut";
            dgvMainData.Columns[3].HeaderText = "Nro Habitacion";
        }

        private void btnReservationHandler_Click(object sender, EventArgs e)
        {

            FrmReservationHandler frmReservationHandler = new();
            frmReservationHandler.Show();
            this.Hide();
        }

        private void btnRegisterGuest_Click(object sender, EventArgs e)
        {
            FrmGuest frmGuestRegister = new(EFrmType.Register);
            frmGuestRegister.Show();
            this.Hide();

        }

        private void btnHandlerGuest_Click(object sender, EventArgs e)
        {
            FrmGuest frmGuestRegister = new(EFrmType.Edit);
            frmGuestRegister.Show();
            this.Hide();

        }

        private void btnRegisterRoom_Click(object sender, EventArgs e)
        {
            FrmRooms frmRoom = new(EFrmType.Register);
            frmRoom.Show();
            this.Hide();

        }

        private void btnRoomHanlder_Click(object sender, EventArgs e)
        {
             FrmRooms frmRoom = new(EFrmType.Edit);
            frmRoom.Show();
            this.Hide();

        }
    }
}