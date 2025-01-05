namespace FluxoDeCaixa.WinForms.Forms
{
    partial class RegistrerForm
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
            btn_CreateUser = new Button();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            txt_User = new TextBox();
            groupBox2 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            dtp_FimVigencia = new DateTimePicker();
            dtp_IniciaoVigencia = new DateTimePicker();
            label2 = new Label();
            txt_CashFlowDescription = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btn_CreateUser
            // 
            btn_CreateUser.Font = new Font("Segoe UI", 12F);
            btn_CreateUser.Location = new Point(12, 399);
            btn_CreateUser.Name = "btn_CreateUser";
            btn_CreateUser.Size = new Size(360, 48);
            btn_CreateUser.TabIndex = 0;
            btn_CreateUser.Text = "Começar";
            btn_CreateUser.UseVisualStyleBackColor = true;
            btn_CreateUser.Click += btn_CreateUser_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(360, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txt_User);
            groupBox1.Location = new Point(12, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 100);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(177, 15);
            label1.TabIndex = 1;
            label1.Text = "Como gostaria de ser chamado?";
            // 
            // txt_User
            // 
            txt_User.BorderStyle = BorderStyle.FixedSingle;
            txt_User.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_User.Location = new Point(6, 46);
            txt_User.Name = "txt_User";
            txt_User.Size = new Size(348, 29);
            txt_User.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dtp_FimVigencia);
            groupBox2.Controls.Add(dtp_IniciaoVigencia);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txt_CashFlowDescription);
            groupBox2.Location = new Point(12, 184);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(360, 209);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Fluxo de caixa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(201, 98);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 7;
            label4.Text = "Fim de vigencia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 98);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 6;
            label3.Text = "Inicio de vigencia";
            // 
            // dtp_FimVigencia
            // 
            dtp_FimVigencia.CalendarFont = new Font("Segoe UI", 12F);
            dtp_FimVigencia.CustomFormat = "MMMM/yyyy";
            dtp_FimVigencia.Format = DateTimePickerFormat.Custom;
            dtp_FimVigencia.Location = new Point(201, 116);
            dtp_FimVigencia.Name = "dtp_FimVigencia";
            dtp_FimVigencia.Size = new Size(153, 23);
            dtp_FimVigencia.TabIndex = 5;
            dtp_FimVigencia.Value = new DateTime(2025, 1, 5, 13, 27, 8, 0);
            // 
            // dtp_IniciaoVigencia
            // 
            dtp_IniciaoVigencia.CalendarFont = new Font("Segoe UI", 12F);
            dtp_IniciaoVigencia.CustomFormat = "MMMM/yyyy";
            dtp_IniciaoVigencia.Format = DateTimePickerFormat.Custom;
            dtp_IniciaoVigencia.Location = new Point(6, 116);
            dtp_IniciaoVigencia.Name = "dtp_IniciaoVigencia";
            dtp_IniciaoVigencia.Size = new Size(153, 23);
            dtp_IniciaoVigencia.TabIndex = 4;
            dtp_IniciaoVigencia.Value = new DateTime(2025, 1, 5, 13, 27, 8, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 28);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "Descrição";
            // 
            // txt_CashFlowDescription
            // 
            txt_CashFlowDescription.BorderStyle = BorderStyle.FixedSingle;
            txt_CashFlowDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_CashFlowDescription.Location = new Point(6, 46);
            txt_CashFlowDescription.Name = "txt_CashFlowDescription";
            txt_CashFlowDescription.Size = new Size(348, 29);
            txt_CashFlowDescription.TabIndex = 2;
            // 
            // RegistrerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 461);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(btn_CreateUser);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegistrerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fluxo de caixa";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_CreateUser;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox txt_User;
        private GroupBox groupBox2;
        private DateTimePicker dtp_IniciaoVigencia;
        private Label label2;
        private TextBox txt_CashFlowDescription;
        private Label label4;
        private Label label3;
        private DateTimePicker dtp_FimVigencia;
    }
}