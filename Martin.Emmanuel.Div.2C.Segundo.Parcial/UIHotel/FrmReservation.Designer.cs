namespace UIHotel
{
    partial class FrmReservation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grbRoomData = new GroupBox();
            cmbRoomNumber = new ComboBox();
            lblRooms = new Label();
            grbReservationData = new GroupBox();
            lblCheckOut = new Label();
            dtpCheckOut = new DateTimePicker();
            dtpCheckIn = new DateTimePicker();
            lblCheckIn = new Label();
            btnGenerateReservation = new Button();
            grbGuests = new GroupBox();
            cmbGuests = new ComboBox();
            btnJsonData = new Button();
            cmbJsonBillingData = new ComboBox();
            grbRoomData.SuspendLayout();
            grbReservationData.SuspendLayout();
            grbGuests.SuspendLayout();
            SuspendLayout();
            // 
            // grbRoomData
            // 
            grbRoomData.Controls.Add(cmbRoomNumber);
            grbRoomData.Controls.Add(lblRooms);
            grbRoomData.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            grbRoomData.Location = new Point(444, 41);
            grbRoomData.Name = "grbRoomData";
            grbRoomData.Size = new Size(319, 153);
            grbRoomData.TabIndex = 8;
            grbRoomData.TabStop = false;
            grbRoomData.Text = "Datos Habitacion";
            // 
            // cmbRoomNumber
            // 
            cmbRoomNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomNumber.FormattingEnabled = true;
            cmbRoomNumber.Location = new Point(64, 104);
            cmbRoomNumber.Name = "cmbRoomNumber";
            cmbRoomNumber.Size = new Size(192, 27);
            cmbRoomNumber.TabIndex = 8;
            // 
            // lblRooms
            // 
            lblRooms.AutoSize = true;
            lblRooms.Location = new Point(55, 56);
            lblRooms.Name = "lblRooms";
            lblRooms.Size = new Size(212, 21);
            lblRooms.TabIndex = 0;
            lblRooms.Text = "Habitaciones Disponibles";
            // 
            // grbReservationData
            // 
            grbReservationData.Controls.Add(lblCheckOut);
            grbReservationData.Controls.Add(dtpCheckOut);
            grbReservationData.Controls.Add(dtpCheckIn);
            grbReservationData.Controls.Add(lblCheckIn);
            grbReservationData.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            grbReservationData.Location = new Point(870, 41);
            grbReservationData.Name = "grbReservationData";
            grbReservationData.Size = new Size(319, 153);
            grbReservationData.TabIndex = 9;
            grbReservationData.TabStop = false;
            grbReservationData.Text = "Datos Reservacion";
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Location = new Point(6, 110);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(75, 21);
            lblCheckOut.TabIndex = 10;
            lblCheckOut.Text = "CheckIn";
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Location = new Point(87, 104);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(226, 27);
            dtpCheckOut.TabIndex = 9;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Location = new Point(87, 56);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(226, 27);
            dtpCheckIn.TabIndex = 8;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Location = new Point(6, 62);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(75, 21);
            lblCheckIn.TabIndex = 0;
            lblCheckIn.Text = "CheckIn";
            // 
            // btnGenerateReservation
            // 
            btnGenerateReservation.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerateReservation.Location = new Point(506, 226);
            btnGenerateReservation.Name = "btnGenerateReservation";
            btnGenerateReservation.Size = new Size(194, 47);
            btnGenerateReservation.TabIndex = 10;
            btnGenerateReservation.Text = "GENERAR RESERVA";
            btnGenerateReservation.UseVisualStyleBackColor = true;
            btnGenerateReservation.Click += btnGenerateReservation_Click;
            // 
            // grbGuests
            // 
            grbGuests.Controls.Add(cmbGuests);
            grbGuests.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
            grbGuests.Location = new Point(37, 41);
            grbGuests.Name = "grbGuests";
            grbGuests.Size = new Size(359, 131);
            grbGuests.TabIndex = 11;
            grbGuests.TabStop = false;
            grbGuests.Text = "Huespedes en Sistema";
            // 
            // cmbGuests
            // 
            cmbGuests.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGuests.FormattingEnabled = true;
            cmbGuests.Location = new Point(6, 50);
            cmbGuests.Name = "cmbGuests";
            cmbGuests.Size = new Size(347, 30);
            cmbGuests.TabIndex = 0;
            // 
            // btnJsonData
            // 
            btnJsonData.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnJsonData.Location = new Point(43, 369);
            btnJsonData.Name = "btnJsonData";
            btnJsonData.Size = new Size(215, 64);
            btnJsonData.TabIndex = 13;
            btnJsonData.Text = "VER INFORME DE CUENTA DESDE JSON";
            btnJsonData.UseVisualStyleBackColor = true;
            btnJsonData.Click += btnJsonData_Click;
            // 
            // cmbJsonBillingData
            // 
            cmbJsonBillingData.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJsonBillingData.Font = new Font("Arial Black", 13F, FontStyle.Regular, GraphicsUnit.Point);
            cmbJsonBillingData.FormattingEnabled = true;
            cmbJsonBillingData.Location = new Point(280, 369);
            cmbJsonBillingData.Name = "cmbJsonBillingData";
            cmbJsonBillingData.Size = new Size(909, 32);
            cmbJsonBillingData.TabIndex = 14;
            // 
            // FrmReservation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 703);
            Controls.Add(cmbJsonBillingData);
            Controls.Add(btnJsonData);
            Controls.Add(grbGuests);
            Controls.Add(btnGenerateReservation);
            Controls.Add(grbReservationData);
            Controls.Add(grbRoomData);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FrmReservation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reservas";
            FormClosing += FrmReservation_FormClosing;
            Load += FrmReservation_Load;
            grbRoomData.ResumeLayout(false);
            grbRoomData.PerformLayout();
            grbReservationData.ResumeLayout(false);
            grbReservationData.PerformLayout();
            grbGuests.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox grbRoomData;
        private Label lblRooms;
        private ComboBox cmbRoomNumber;
        private GroupBox grbReservationData;
        private TextBox textBox5;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblCheckIn;
        private DateTimePicker dtpCheckIn;
        private DateTimePicker dtpCheckOut;
        private Button btnGenerateReservation;
        private Label lblCheckOut;
        private GroupBox grbGuests;
        private ComboBox cmbGuests;
        private Button btnJsonData;
        private ComboBox cmbJsonBillingData;
    }
}