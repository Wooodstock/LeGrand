namespace OpenWebNetWinForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMaison = new System.Windows.Forms.TabPage();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbupdateMdp = new System.Windows.Forms.TextBox();
            this.tbupdateEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbupdateNom = new System.Windows.Forms.TextBox();
            this.tbupdatePrenom = new System.Windows.Forms.TextBox();
            this.btnupdateUser = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbaddMdp = new System.Windows.Forms.TextBox();
            this.tbaddEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbaddNom = new System.Windows.Forms.TextBox();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.tbaddPrenom = new System.Windows.Forms.TextBox();
            this.btndelUser = new System.Windows.Forms.Button();
            this.btnaddUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabMaison.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Services";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(31, 48);
            this.buttonTest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(92, 19);
            this.buttonTest.TabIndex = 1;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMaison);
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Font = new System.Drawing.Font("Corbel", 8.25F);
            this.tabControl1.Location = new System.Drawing.Point(12, 107);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(748, 416);
            this.tabControl1.TabIndex = 2;
            // 
            // tabMaison
            // 
            this.tabMaison.BackColor = System.Drawing.Color.Black;
            this.tabMaison.Controls.Add(this.buttonTest);
            this.tabMaison.Controls.Add(this.button1);
            this.tabMaison.Location = new System.Drawing.Point(4, 22);
            this.tabMaison.Name = "tabMaison";
            this.tabMaison.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaison.Size = new System.Drawing.Size(740, 390);
            this.tabMaison.TabIndex = 0;
            this.tabMaison.Text = "Maison";
            // 
            // tabUsers
            // 
            this.tabUsers.BackColor = System.Drawing.Color.Black;
            this.tabUsers.BackgroundImage = global::OpenWebNetWinForm.Properties.Resources.bg_users2;
            this.tabUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabUsers.Controls.Add(this.label8);
            this.tabUsers.Controls.Add(this.label9);
            this.tabUsers.Controls.Add(this.tbupdateMdp);
            this.tabUsers.Controls.Add(this.tbupdateEmail);
            this.tabUsers.Controls.Add(this.label10);
            this.tabUsers.Controls.Add(this.label11);
            this.tabUsers.Controls.Add(this.tbupdateNom);
            this.tabUsers.Controls.Add(this.tbupdatePrenom);
            this.tabUsers.Controls.Add(this.btnupdateUser);
            this.tabUsers.Controls.Add(this.label7);
            this.tabUsers.Controls.Add(this.label6);
            this.tabUsers.Controls.Add(this.label5);
            this.tabUsers.Controls.Add(this.tbaddMdp);
            this.tabUsers.Controls.Add(this.tbaddEmail);
            this.tabUsers.Controls.Add(this.label4);
            this.tabUsers.Controls.Add(this.label3);
            this.tabUsers.Controls.Add(this.tbaddNom);
            this.tabUsers.Controls.Add(this.cbUsers);
            this.tabUsers.Controls.Add(this.tbaddPrenom);
            this.tabUsers.Controls.Add(this.btndelUser);
            this.tabUsers.Controls.Add(this.btnaddUser);
            this.tabUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(740, 390);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Utilisateurs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(421, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 105;
            this.label8.Text = "Mot de passe";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(421, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "Email";
            // 
            // tbupdateMdp
            // 
            this.tbupdateMdp.Location = new System.Drawing.Point(498, 259);
            this.tbupdateMdp.Name = "tbupdateMdp";
            this.tbupdateMdp.Size = new System.Drawing.Size(174, 21);
            this.tbupdateMdp.TabIndex = 11;
            // 
            // tbupdateEmail
            // 
            this.tbupdateEmail.Location = new System.Drawing.Point(459, 233);
            this.tbupdateEmail.Name = "tbupdateEmail";
            this.tbupdateEmail.Size = new System.Drawing.Size(213, 21);
            this.tbupdateEmail.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(548, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 107;
            this.label10.Text = "Nom";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(421, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 108;
            this.label11.Text = "Prénom";
            // 
            // tbupdateNom
            // 
            this.tbupdateNom.Location = new System.Drawing.Point(551, 207);
            this.tbupdateNom.Name = "tbupdateNom";
            this.tbupdateNom.Size = new System.Drawing.Size(121, 21);
            this.tbupdateNom.TabIndex = 9;
            // 
            // tbupdatePrenom
            // 
            this.tbupdatePrenom.Location = new System.Drawing.Point(424, 207);
            this.tbupdatePrenom.Name = "tbupdatePrenom";
            this.tbupdatePrenom.Size = new System.Drawing.Size(121, 21);
            this.tbupdatePrenom.TabIndex = 8;
            // 
            // btnupdateUser
            // 
            this.btnupdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnupdateUser.Location = new System.Drawing.Point(424, 285);
            this.btnupdateUser.Name = "btnupdateUser";
            this.btnupdateUser.Size = new System.Drawing.Size(248, 23);
            this.btnupdateUser.TabIndex = 12;
            this.btnupdateUser.Text = "Enregistrer";
            this.btnupdateUser.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(421, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "Utilisateurs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Mot de passe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Email";
            // 
            // tbaddMdp
            // 
            this.tbaddMdp.Location = new System.Drawing.Point(137, 207);
            this.tbaddMdp.Name = "tbaddMdp";
            this.tbaddMdp.Size = new System.Drawing.Size(174, 21);
            this.tbaddMdp.TabIndex = 4;
            // 
            // tbaddEmail
            // 
            this.tbaddEmail.Location = new System.Drawing.Point(98, 181);
            this.tbaddEmail.Name = "tbaddEmail";
            this.tbaddEmail.Size = new System.Drawing.Size(213, 21);
            this.tbaddEmail.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Prénom";
            // 
            // tbaddNom
            // 
            this.tbaddNom.Location = new System.Drawing.Point(190, 155);
            this.tbaddNom.Name = "tbaddNom";
            this.tbaddNom.Size = new System.Drawing.Size(121, 21);
            this.tbaddNom.TabIndex = 2;
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(424, 154);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(172, 21);
            this.cbUsers.TabIndex = 6;
            // 
            // tbaddPrenom
            // 
            this.tbaddPrenom.Location = new System.Drawing.Point(63, 155);
            this.tbaddPrenom.Name = "tbaddPrenom";
            this.tbaddPrenom.Size = new System.Drawing.Size(121, 21);
            this.tbaddPrenom.TabIndex = 1;
            // 
            // btndelUser
            // 
            this.btndelUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btndelUser.Location = new System.Drawing.Point(602, 153);
            this.btndelUser.Name = "btndelUser";
            this.btndelUser.Size = new System.Drawing.Size(70, 23);
            this.btndelUser.TabIndex = 7;
            this.btndelUser.Text = "Supprimer";
            this.btndelUser.UseVisualStyleBackColor = true;
            // 
            // btnaddUser
            // 
            this.btnaddUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnaddUser.Location = new System.Drawing.Point(63, 233);
            this.btnaddUser.Name = "btnaddUser";
            this.btnaddUser.Size = new System.Drawing.Size(248, 23);
            this.btnaddUser.TabIndex = 5;
            this.btnaddUser.Text = "Ajouter";
            this.btnaddUser.UseVisualStyleBackColor = true;
            this.btnaddUser.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OpenWebNetWinForm.Properties.Resources.legrand_logo;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 89);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(772, 536);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "LEGRAND - Home Center";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabMaison.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMaison;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.Button btndelUser;
        private System.Windows.Forms.Button btnaddUser;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.TextBox tbaddPrenom;
        private System.Windows.Forms.TextBox tbaddNom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbaddMdp;
        private System.Windows.Forms.TextBox tbaddEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbupdateMdp;
        private System.Windows.Forms.TextBox tbupdateEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbupdateNom;
        private System.Windows.Forms.TextBox tbupdatePrenom;
        private System.Windows.Forms.Button btnupdateUser;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

