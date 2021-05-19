
namespace TrackerUI
{
    partial class CreateTeamForm
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
            this.teamNameValue = new System.Windows.Forms.TextBox();
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.selectPlayerDropDown = new System.Windows.Forms.ComboBox();
            this.selectPlayerLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.firstNameValue = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameValue = new System.Windows.Forms.TextBox();
            this.emailAddressLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cellphoneNumberLabel = new System.Windows.Forms.Label();
            this.createPlayerButton = new System.Windows.Forms.Button();
            this.playersListBox = new System.Windows.Forms.ListBox();
            this.removePlayerButton = new System.Windows.Forms.Button();
            this.createTeamButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // teamNameValue
            // 
            this.teamNameValue.Location = new System.Drawing.Point(41, 113);
            this.teamNameValue.Name = "teamNameValue";
            this.teamNameValue.Size = new System.Drawing.Size(341, 35);
            this.teamNameValue.TabIndex = 47;
            // 
            // teamNameLabel
            // 
            this.teamNameLabel.AutoSize = true;
            this.teamNameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.teamNameLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.teamNameLabel.Location = new System.Drawing.Point(41, 80);
            this.teamNameLabel.Name = "teamNameLabel";
            this.teamNameLabel.Size = new System.Drawing.Size(124, 30);
            this.teamNameLabel.TabIndex = 46;
            this.teamNameLabel.Text = "Team Name";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.headerLabel.Location = new System.Drawing.Point(12, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(213, 50);
            this.headerLabel.TabIndex = 45;
            this.headerLabel.Text = "Create Team";
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.BackColor = System.Drawing.Color.White;
            this.addPlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addPlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.addPlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.addPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPlayerButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addPlayerButton.ForeColor = System.Drawing.Color.SkyBlue;
            this.addPlayerButton.Location = new System.Drawing.Point(41, 228);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(341, 43);
            this.addPlayerButton.TabIndex = 53;
            this.addPlayerButton.Text = "Add Player";
            this.addPlayerButton.UseVisualStyleBackColor = false;
            // 
            // selectPlayerDropDown
            // 
            this.selectPlayerDropDown.FormattingEnabled = true;
            this.selectPlayerDropDown.Location = new System.Drawing.Point(41, 184);
            this.selectPlayerDropDown.Name = "selectPlayerDropDown";
            this.selectPlayerDropDown.Size = new System.Drawing.Size(341, 38);
            this.selectPlayerDropDown.TabIndex = 52;
            // 
            // selectPlayerLabel
            // 
            this.selectPlayerLabel.AutoSize = true;
            this.selectPlayerLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectPlayerLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.selectPlayerLabel.Location = new System.Drawing.Point(41, 151);
            this.selectPlayerLabel.Name = "selectPlayerLabel";
            this.selectPlayerLabel.Size = new System.Drawing.Size(130, 30);
            this.selectPlayerLabel.TabIndex = 51;
            this.selectPlayerLabel.Text = "Select Player";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createPlayerButton);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.cellphoneNumberLabel);
            this.groupBox1.Controls.Add(this.lastNameLabel);
            this.groupBox1.Controls.Add(this.lastNameValue);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.emailAddressLabel);
            this.groupBox1.Controls.Add(this.firstNameValue);
            this.groupBox1.Controls.Add(this.firstNameLabel);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(41, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 352);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Player";
            // 
            // firstNameValue
            // 
            this.firstNameValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstNameValue.Location = new System.Drawing.Point(13, 62);
            this.firstNameValue.Name = "firstNameValue";
            this.firstNameValue.Size = new System.Drawing.Size(313, 33);
            this.firstNameValue.TabIndex = 10;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstNameLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.firstNameLabel.Location = new System.Drawing.Point(13, 29);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(113, 30);
            this.firstNameLabel.TabIndex = 9;
            this.firstNameLabel.Text = "First Name";
            // 
            // lastNameValue
            // 
            this.lastNameValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameValue.Location = new System.Drawing.Point(13, 131);
            this.lastNameValue.Name = "lastNameValue";
            this.lastNameValue.Size = new System.Drawing.Size(313, 33);
            this.lastNameValue.TabIndex = 12;
            // 
            // emailAddressLabel
            // 
            this.emailAddressLabel.AutoSize = true;
            this.emailAddressLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.emailAddressLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.emailAddressLabel.Location = new System.Drawing.Point(13, 167);
            this.emailAddressLabel.Name = "emailAddressLabel";
            this.emailAddressLabel.Size = new System.Drawing.Size(143, 30);
            this.emailAddressLabel.TabIndex = 11;
            this.emailAddressLabel.Text = "Email Address";
            this.emailAddressLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(13, 200);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(313, 33);
            this.textBox2.TabIndex = 14;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.lastNameLabel.Location = new System.Drawing.Point(13, 98);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(112, 30);
            this.lastNameLabel.TabIndex = 13;
            this.lastNameLabel.Text = "Last Name";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(13, 269);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(313, 33);
            this.textBox3.TabIndex = 16;
            // 
            // cellphoneNumberLabel
            // 
            this.cellphoneNumberLabel.AutoSize = true;
            this.cellphoneNumberLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cellphoneNumberLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.cellphoneNumberLabel.Location = new System.Drawing.Point(13, 236);
            this.cellphoneNumberLabel.Name = "cellphoneNumberLabel";
            this.cellphoneNumberLabel.Size = new System.Drawing.Size(106, 30);
            this.cellphoneNumberLabel.TabIndex = 15;
            this.cellphoneNumberLabel.Text = "Cellphone";
            // 
            // createPlayerButton
            // 
            this.createPlayerButton.BackColor = System.Drawing.Color.White;
            this.createPlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createPlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.createPlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.createPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPlayerButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createPlayerButton.ForeColor = System.Drawing.Color.SkyBlue;
            this.createPlayerButton.Location = new System.Drawing.Point(13, 308);
            this.createPlayerButton.Name = "createPlayerButton";
            this.createPlayerButton.Size = new System.Drawing.Size(313, 38);
            this.createPlayerButton.TabIndex = 51;
            this.createPlayerButton.Text = "Create Player";
            this.createPlayerButton.UseVisualStyleBackColor = false;
            // 
            // playersListBox
            // 
            this.playersListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playersListBox.FormattingEnabled = true;
            this.playersListBox.ItemHeight = 30;
            this.playersListBox.Location = new System.Drawing.Point(421, 150);
            this.playersListBox.Name = "playersListBox";
            this.playersListBox.Size = new System.Drawing.Size(350, 332);
            this.playersListBox.TabIndex = 55;
            // 
            // removePlayerButton
            // 
            this.removePlayerButton.BackColor = System.Drawing.Color.Crimson;
            this.removePlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.removePlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.removePlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.removePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removePlayerButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removePlayerButton.ForeColor = System.Drawing.Color.White;
            this.removePlayerButton.Location = new System.Drawing.Point(618, 113);
            this.removePlayerButton.Name = "removePlayerButton";
            this.removePlayerButton.Size = new System.Drawing.Size(153, 31);
            this.removePlayerButton.TabIndex = 57;
            this.removePlayerButton.Text = "Remove Player";
            this.removePlayerButton.UseVisualStyleBackColor = false;
            // 
            // createTeamButton
            // 
            this.createTeamButton.BackColor = System.Drawing.Color.SkyBlue;
            this.createTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.createTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.createTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTeamButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createTeamButton.ForeColor = System.Drawing.Color.White;
            this.createTeamButton.Location = new System.Drawing.Point(485, 594);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Size = new System.Drawing.Size(286, 61);
            this.createTeamButton.TabIndex = 59;
            this.createTeamButton.Text = "Create Team";
            this.createTeamButton.UseVisualStyleBackColor = false;
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 673);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.removePlayerButton);
            this.Controls.Add(this.playersListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addPlayerButton);
            this.Controls.Add(this.selectPlayerDropDown);
            this.Controls.Add(this.selectPlayerLabel);
            this.Controls.Add(this.teamNameValue);
            this.Controls.Add(this.teamNameLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "CreateTeamForm";
            this.Text = "Create Team";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teamNameValue;
        private System.Windows.Forms.Label teamNameLabel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button addPlayerButton;
        private System.Windows.Forms.ComboBox selectPlayerDropDown;
        private System.Windows.Forms.Label selectPlayerLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label cellphoneNumberLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameValue;
        private System.Windows.Forms.Label emailAddressLabel;
        private System.Windows.Forms.TextBox firstNameValue;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Button createPlayerButton;
        private System.Windows.Forms.ListBox playersListBox;
        private System.Windows.Forms.Button removePlayerButton;
        private System.Windows.Forms.Button createTeamButton;
    }
}