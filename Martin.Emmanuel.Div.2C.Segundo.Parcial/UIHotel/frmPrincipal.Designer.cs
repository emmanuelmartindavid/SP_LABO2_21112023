namespace UIHotel
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWelcome = new Label();
            btnFrmReservation = new Button();
            btnReservationsHistory = new Button();
            btnRegisteredGuests = new Button();
            btnReservationHandler = new Button();
            btnRegisterGuest = new Button();
            dgvMainData = new DataGridView();
            btnHandlerGuest = new Button();
            btnRegisterRoom = new Button();
            btnRoomHanlder = new Button();
            cmbJsonBillingData = new ComboBox();
            btnJsonData = new Button();
            cmbTrackUserMovement = new ComboBox();
            btnTrackUserMovement = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMainData).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Arial Black", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblWelcome.Location = new Point(187, 25);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(858, 38);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "BIENVENIDO A SISTEMA DE RESERVA HOTEL DON JOSE";
            // 
            // btnFrmReservation
            // 
            btnFrmReservation.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnFrmReservation.Location = new Point(12, 104);
            btnFrmReservation.Name = "btnFrmReservation";
            btnFrmReservation.Size = new Size(153, 64);
            btnFrmReservation.TabIndex = 1;
            btnFrmReservation.Text = "Generar Reservacion";
            btnFrmReservation.UseVisualStyleBackColor = true;
            btnFrmReservation.Click += btnFrmReservation_Click;
            // 
            // btnReservationsHistory
            // 
            btnReservationsHistory.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnReservationsHistory.Location = new Point(714, 104);
            btnReservationsHistory.Name = "btnReservationsHistory";
            btnReservationsHistory.Size = new Size(137, 64);
            btnReservationsHistory.TabIndex = 2;
            btnReservationsHistory.Text = "Ver Reservaciones";
            btnReservationsHistory.UseVisualStyleBackColor = true;
            btnReservationsHistory.Click += btnReservationsHistory_Click;
            // 
            // btnRegisteredGuests
            // 
            btnRegisteredGuests.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegisteredGuests.Location = new Point(551, 104);
            btnRegisteredGuests.Name = "btnRegisteredGuests";
            btnRegisteredGuests.Size = new Size(157, 64);
            btnRegisteredGuests.TabIndex = 3;
            btnRegisteredGuests.Text = "Ver Huespedes Registrados";
            btnRegisteredGuests.UseVisualStyleBackColor = true;
            btnRegisteredGuests.Click += btnRegisteredGuests_Click;
            // 
            // btnReservationHandler
            // 
            btnReservationHandler.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnReservationHandler.Location = new Point(857, 104);
            btnReservationHandler.Name = "btnReservationHandler";
            btnReservationHandler.Size = new Size(164, 64);
            btnReservationHandler.TabIndex = 4;
            btnReservationHandler.Text = "Modificar Elimnar Reservaciones";
            btnReservationHandler.UseVisualStyleBackColor = true;
            btnReservationHandler.Click += btnReservationHandler_Click;
            // 
            // btnRegisterGuest
            // 
            btnRegisterGuest.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegisterGuest.Location = new Point(171, 104);
            btnRegisterGuest.Name = "btnRegisterGuest";
            btnRegisterGuest.Size = new Size(176, 64);
            btnRegisterGuest.TabIndex = 6;
            btnRegisterGuest.Text = "Registrar Nuevo Huesped al sistema";
            btnRegisterGuest.UseVisualStyleBackColor = true;
            btnRegisterGuest.Click += btnRegisterGuest_Click;
            // 
            // dgvMainData
            // 
            dgvMainData.BackgroundColor = SystemColors.ButtonFace;
            dgvMainData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainData.Location = new Point(1027, 174);
            dgvMainData.Name = "dgvMainData";
            dgvMainData.RowTemplate.Height = 25;
            dgvMainData.Size = new Size(781, 555);
            dgvMainData.TabIndex = 7;
            // 
            // btnHandlerGuest
            // 
            btnHandlerGuest.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnHandlerGuest.Location = new Point(1027, 104);
            btnHandlerGuest.Name = "btnHandlerGuest";
            btnHandlerGuest.Size = new Size(164, 64);
            btnHandlerGuest.TabIndex = 8;
            btnHandlerGuest.Text = "Modificar Elimnar Huespedes";
            btnHandlerGuest.UseVisualStyleBackColor = true;
            btnHandlerGuest.Click += btnHandlerGuest_Click;
            // 
            // btnRegisterRoom
            // 
            btnRegisterRoom.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegisterRoom.Location = new Point(353, 104);
            btnRegisterRoom.Name = "btnRegisterRoom";
            btnRegisterRoom.Size = new Size(192, 64);
            btnRegisterRoom.TabIndex = 9;
            btnRegisterRoom.Text = "Registrar Nueva habitacion al sistema";
            btnRegisterRoom.UseVisualStyleBackColor = true;
            btnRegisterRoom.Click += btnRegisterRoom_Click;
            // 
            // btnRoomHanlder
            // 
            btnRoomHanlder.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnRoomHanlder.Location = new Point(1197, 104);
            btnRoomHanlder.Name = "btnRoomHanlder";
            btnRoomHanlder.Size = new Size(164, 64);
            btnRoomHanlder.TabIndex = 10;
            btnRoomHanlder.Text = "Modificar Elimnar Habitaciones";
            btnRoomHanlder.UseVisualStyleBackColor = true;
            btnRoomHanlder.Click += btnRoomHanlder_Click;
            // 
            // cmbJsonBillingData
            // 
            cmbJsonBillingData.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJsonBillingData.Font = new Font("Arial Black", 13F, FontStyle.Regular, GraphicsUnit.Point);
            cmbJsonBillingData.FormattingEnabled = true;
            cmbJsonBillingData.Location = new Point(12, 286);
            cmbJsonBillingData.Name = "cmbJsonBillingData";
            cmbJsonBillingData.Size = new Size(1009, 32);
            cmbJsonBillingData.TabIndex = 16;
            // 
            // btnJsonData
            // 
            btnJsonData.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnJsonData.Location = new Point(416, 198);
            btnJsonData.Name = "btnJsonData";
            btnJsonData.Size = new Size(215, 64);
            btnJsonData.TabIndex = 15;
            btnJsonData.Text = "VER INFORME DE CUENTA DESDE JSON";
            btnJsonData.UseVisualStyleBackColor = true;
            btnJsonData.Click += btnJsonData_Click;
            // 
            // cmbTrackUserMovement
            // 
            cmbTrackUserMovement.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrackUserMovement.Font = new Font("Arial Black", 13F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTrackUserMovement.FormattingEnabled = true;
            cmbTrackUserMovement.Location = new Point(12, 548);
            cmbTrackUserMovement.Name = "cmbTrackUserMovement";
            cmbTrackUserMovement.Size = new Size(1009, 32);
            cmbTrackUserMovement.TabIndex = 18;
            // 
            // btnTrackUserMovement
            // 
            btnTrackUserMovement.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnTrackUserMovement.Location = new Point(416, 465);
            btnTrackUserMovement.Name = "btnTrackUserMovement";
            btnTrackUserMovement.Size = new Size(215, 64);
            btnTrackUserMovement.TabIndex = 17;
            btnTrackUserMovement.Text = "VER TRACKING DE USUARIO ";
            btnTrackUserMovement.UseVisualStyleBackColor = true;
            btnTrackUserMovement.Click += btnTrackUserMovement_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1810, 735);
            Controls.Add(cmbTrackUserMovement);
            Controls.Add(btnTrackUserMovement);
            Controls.Add(cmbJsonBillingData);
            Controls.Add(btnJsonData);
            Controls.Add(btnRoomHanlder);
            Controls.Add(btnRegisterRoom);
            Controls.Add(btnHandlerGuest);
            Controls.Add(dgvMainData);
            Controls.Add(btnRegisterGuest);
            Controls.Add(btnReservationHandler);
            Controls.Add(btnRegisteredGuests);
            Controls.Add(btnReservationsHistory);
            Controls.Add(btnFrmReservation);
            Controls.Add(lblWelcome);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Don Jose";
            Load += FrmPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMainData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnFrmReservation;
        private Button btnReservationsHistory;
        private Button btnRegisteredGuests;
        private Button btnReservationHandler;
        private Button btnRegisterGuest;
        private DataGridView dgvMainData;
        private Button btnHandlerGuest;
        private Button btnRegisterRoom;
        private Button btnRoomHanlder;
        private ComboBox cmbJsonBillingData;
        private Button btnJsonData;
        private ComboBox cmbTrackUserMovement;
        private Button btnTrackUserMovement;
    }
}