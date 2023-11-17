using Entities;
using Entities.Controllers;
using Entities.Models;
using Entities.Serialization;
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
           /* List<Billing> bills = new();

     
            bills = JSONSerialization.DeserializeBillings();

            *//* var guest = new Guest(12345678, "Roque", "Perez", 1234567234);
             var reservation = new Reservation(12345678, new DateTime(2003, 4, 12), new DateTime(2003, 4, 15), 102);

             var bill = new Billing(guest, new Room(102, false, ERoomType.Simple), reservation);

             var guest2 = new Guest(12345678, "Juan", "PEdro", 1234567234);
             var reservation2 = new Reservation(12345678, new DateTime(2003, 4, 12), new DateTime(2003, 4, 15), 102);

             var bill2 = new Billing(guest, new Room(102, false, ERoomType.Simple), reservation);

             bills.Add(bill);
             bills.Add(bill2);*//*

            var guest2 = new Guest(12345678, "Jose", "PEdro", 1234567234);
            var reservation2 = new Reservation(12345678, new DateTime(2003, 4, 12), new DateTime(2003, 4, 15), 102);

            var bill2 = new Billing(guest2, new Room(102, false, ERoomType.Simple), reservation2);
            bills.Add(bill2);

            JSONSerialization.SerializeBillings(bills);
*/

            // JSONSerialization.SerializeBillings( reservation.ToInvoiceString(guest, new Room(102, false,ERoomType.Simple)));




            _guestController = new();
            _reservationController = new();


        }

        private void btnFrmReservation_Click(object sender, EventArgs e)
        {

            FrmReservation frmReservation = new();
            frmReservation.Show();
            this.Hide();
        }
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