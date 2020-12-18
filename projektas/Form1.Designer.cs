namespace projektas
{
    partial class Form1
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
            this.Username = new System.Windows.Forms.TextBox();
            this.UsernameVerb = new System.Windows.Forms.Label();
            this.PasswordVerb = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(169, 78);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(143, 20);
            this.Username.TabIndex = 2;
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // UsernameVerb
            // 
            this.UsernameVerb.AutoSize = true;
            this.UsernameVerb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameVerb.Location = new System.Drawing.Point(60, 76);
            this.UsernameVerb.Name = "UsernameVerb";
            this.UsernameVerb.Size = new System.Drawing.Size(87, 20);
            this.UsernameVerb.TabIndex = 3;
            this.UsernameVerb.Text = "Username:";
            // 
            // PasswordVerb
            // 
            this.PasswordVerb.AutoSize = true;
            this.PasswordVerb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordVerb.Location = new System.Drawing.Point(65, 137);
            this.PasswordVerb.Name = "PasswordVerb";
            this.PasswordVerb.Size = new System.Drawing.Size(82, 20);
            this.PasswordVerb.TabIndex = 4;
            this.PasswordVerb.Text = "Password:";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(169, 137);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(143, 20);
            this.Password.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "LOGIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 263);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.PasswordVerb);
            this.Controls.Add(this.UsernameVerb);
            this.Controls.Add(this.Username);
            this.Name = "Form1";
            this.Text = "Prisijungimas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label UsernameVerb;
        private System.Windows.Forms.Label PasswordVerb;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button button1;
    }
}

