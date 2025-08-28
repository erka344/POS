namespace PosForm
{
    partial class Profile
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
            username = new Label();
            role = new Label();
            accEditBtn = new Button();
            accDltBtn = new Button();
            usernameTxt = new TextBox();
            accAddBtn = new Button();
            passwordTxt = new TextBox();
            accSaveBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            roleCombo = new ComboBox();
            listView1 = new ListView();
            logoutBtn = new Button();
            SuspendLayout();
            // 
            // username
            // 
            username.AutoSize = true;
            username.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username.Location = new Point(54, 24);
            username.Name = "username";
            username.Size = new Size(70, 28);
            username.TabIndex = 0;
            username.Text = "label1";
            username.Click += username_Click;
            // 
            // role
            // 
            role.AutoSize = true;
            role.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            role.Location = new Point(54, 73);
            role.Name = "role";
            role.Size = new Size(53, 23);
            role.TabIndex = 1;
            role.Text = "label1";
            // 
            // accEditBtn
            // 
            accEditBtn.Location = new Point(12, 143);
            accEditBtn.Name = "accEditBtn";
            accEditBtn.Size = new Size(144, 29);
            accEditBtn.TabIndex = 2;
            accEditBtn.Text = "Edit";
            accEditBtn.UseVisualStyleBackColor = true;
            // 
            // accDltBtn
            // 
            accDltBtn.Location = new Point(12, 189);
            accDltBtn.Name = "accDltBtn";
            accDltBtn.Size = new Size(144, 29);
            accDltBtn.TabIndex = 3;
            accDltBtn.Text = "Delete";
            accDltBtn.UseVisualStyleBackColor = true;
            // 
            // usernameTxt
            // 
            usernameTxt.Location = new Point(177, 73);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.Size = new Size(144, 27);
            usernameTxt.TabIndex = 4;
            // 
            // accAddBtn
            // 
            accAddBtn.Enabled = false;
            accAddBtn.Location = new Point(178, 23);
            accAddBtn.Name = "accAddBtn";
            accAddBtn.Size = new Size(144, 29);
            accAddBtn.TabIndex = 5;
            accAddBtn.Text = "Add user";
            accAddBtn.UseVisualStyleBackColor = true;
            // 
            // passwordTxt
            // 
            passwordTxt.Location = new Point(178, 145);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.Size = new Size(144, 27);
            passwordTxt.TabIndex = 6;
            // 
            // accSaveBtn
            // 
            accSaveBtn.Location = new Point(178, 189);
            accSaveBtn.Name = "accSaveBtn";
            accSaveBtn.Size = new Size(144, 29);
            accSaveBtn.TabIndex = 8;
            accSaveBtn.Text = "Save";
            accSaveBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(178, 55);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 9;
            label1.Text = "Username";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(339, 55);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 10;
            label2.Text = "Role";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(178, 122);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 11;
            label3.Text = "New password";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(496, 25);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(186, 27);
            textBox4.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(496, 2);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 13;
            label4.Text = "Search";
            // 
            // roleCombo
            // 
            roleCombo.Enabled = false;
            roleCombo.FormattingEnabled = true;
            roleCombo.Items.AddRange(new object[] { "manager", "cashier" });
            roleCombo.Location = new Point(339, 73);
            roleCombo.Name = "roleCombo";
            roleCombo.Size = new Size(144, 28);
            roleCombo.TabIndex = 14;
            // 
            // listView1
            // 
            listView1.Location = new Point(496, 58);
            listView1.Name = "listView1";
            listView1.Size = new Size(186, 160);
            listView1.TabIndex = 15;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(12, 242);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(144, 29);
            logoutBtn.TabIndex = 16;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = true;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 283);
            Controls.Add(logoutBtn);
            Controls.Add(listView1);
            Controls.Add(roleCombo);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(accSaveBtn);
            Controls.Add(passwordTxt);
            Controls.Add(accAddBtn);
            Controls.Add(usernameTxt);
            Controls.Add(accDltBtn);
            Controls.Add(accEditBtn);
            Controls.Add(role);
            Controls.Add(username);
            Name = "Profile";
            Text = "Profile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label username;
        private Label role;
        private Button accEditBtn;
        private Button accDltBtn;
        private TextBox usernameTxt;
        private Button accAddBtn;
        private TextBox passwordTxt;
        private Button accSaveBtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private ComboBox roleCombo;
        private ListView listView1;
        private Button logoutBtn;
    }
}