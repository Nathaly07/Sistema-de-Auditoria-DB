namespace SistemaAuditoria
{
    partial class LoginForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtserver = new TextBox();
            txtuser = new TextBox();
            txtpassword = new TextBox();
            IngresaButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(142, 116);
            label4.Name = "label4";
            label4.Size = new Size(58, 21);
            label4.TabIndex = 3;
            label4.Text = "Server:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(142, 177);
            label5.Name = "label5";
            label5.Size = new Size(67, 21);
            label5.TabIndex = 4;
            label5.Text = "Usuario:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(142, 234);
            label6.Name = "label6";
            label6.Size = new Size(92, 21);
            label6.TabIndex = 5;
            label6.Text = "Contraseña:";
            // 
            // txtserver
            // 
            txtserver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtserver.Location = new Point(243, 113);
            txtserver.Name = "txtserver";
            txtserver.PlaceholderText = "Ingresa el server";
            txtserver.Size = new Size(160, 29);
            txtserver.TabIndex = 6;
            // 
            // txtuser
            // 
            txtuser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtuser.Location = new Point(245, 169);
            txtuser.Name = "txtuser";
            txtuser.PlaceholderText = "Ingrese el usuario";
            txtuser.Size = new Size(158, 29);
            txtuser.TabIndex = 7;
            // 
            // txtpassword
            // 
            txtpassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpassword.Location = new Point(245, 231);
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
            txtpassword.PlaceholderText = "Ingrese la contraseña";
            txtpassword.Size = new Size(158, 29);
            txtpassword.TabIndex = 8;
            // 
            // IngresaButton
            // 
            IngresaButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IngresaButton.Location = new Point(152, 292);
            IngresaButton.Name = "IngresaButton";
            IngresaButton.Size = new Size(251, 41);
            IngresaButton.TabIndex = 9;
            IngresaButton.Text = "Iniciar Sesion";
            IngresaButton.UseVisualStyleBackColor = true;
            IngresaButton.Click += IngresaButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 408);
            Controls.Add(IngresaButton);
            Controls.Add(txtpassword);
            Controls.Add(txtuser);
            Controls.Add(txtserver);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Form1";
            FormClosing += this.LoginForm_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtserver;
        private TextBox txtuser;
        private TextBox txtpassword;
        private Button IngresaButton;
    }
}
