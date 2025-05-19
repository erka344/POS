namespace PosForm
{
    partial class Payment
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
            ChangeLabel = new Label();
            label3 = new Label();
            confirmBtn = new Button();
            cancelBtn = new Button();
            qpayBtn = new Button();
            cradBtn = new Button();
            cashBtn = new Button();
            AmountLabel = new Label();
            label2 = new Label();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            clearBtn = new Button();
            button3 = new Button();
            button2 = new Button();
            AmountTextBox = new TextBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // ChangeLabel
            // 
            ChangeLabel.AutoSize = true;
            ChangeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ChangeLabel.Location = new Point(114, 443);
            ChangeLabel.Name = "ChangeLabel";
            ChangeLabel.Size = new Size(36, 28);
            ChangeLabel.TabIndex = 47;
            ChangeLabel.Text = "$0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 443);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 46;
            label3.Text = "Change: ";
            // 
            // confirmBtn
            // 
            confirmBtn.Location = new Point(162, 491);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(141, 56);
            confirmBtn.TabIndex = 45;
            confirmBtn.Text = "confirm";
            confirmBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(12, 491);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(141, 56);
            cancelBtn.TabIndex = 44;
            cancelBtn.Text = "cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // qpayBtn
            // 
            qpayBtn.Location = new Point(206, 63);
            qpayBtn.Name = "qpayBtn";
            qpayBtn.Size = new Size(98, 56);
            qpayBtn.TabIndex = 43;
            qpayBtn.Text = "Qpay";
            qpayBtn.UseVisualStyleBackColor = true;
            // 
            // cradBtn
            // 
            cradBtn.Location = new Point(107, 63);
            cradBtn.Name = "cradBtn";
            cradBtn.Size = new Size(93, 56);
            cradBtn.TabIndex = 42;
            cradBtn.Text = "Card";
            cradBtn.UseVisualStyleBackColor = true;
            // 
            // cashBtn
            // 
            cashBtn.Location = new Point(13, 63);
            cashBtn.Name = "cashBtn";
            cashBtn.Size = new Size(86, 56);
            cashBtn.TabIndex = 41;
            cashBtn.Text = "Cash";
            cashBtn.UseVisualStyleBackColor = true;
            cashBtn.Click += cashBtn_Click;
            // 
            // AmountLabel
            // 
            AmountLabel.AutoSize = true;
            AmountLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AmountLabel.Location = new Point(118, 20);
            AmountLabel.Name = "AmountLabel";
            AmountLabel.Size = new Size(36, 28);
            AmountLabel.TabIndex = 40;
            AmountLabel.Text = "$0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 20);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 39;
            label2.Text = "Amount: ";
            // 
            // button11
            // 
            button11.Enabled = false;
            button11.Location = new Point(221, 365);
            button11.Name = "button11";
            button11.Size = new Size(83, 56);
            button11.TabIndex = 38;
            button11.Text = ".";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button1_Click;
            // 
            // button12
            // 
            button12.Enabled = false;
            button12.Location = new Point(117, 365);
            button12.Name = "button12";
            button12.Size = new Size(83, 56);
            button12.TabIndex = 37;
            button12.Text = "0";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button1_Click;
            // 
            // button13
            // 
            button13.Enabled = false;
            button13.Location = new Point(13, 365);
            button13.Name = "button13";
            button13.Size = new Size(83, 56);
            button13.TabIndex = 36;
            button13.Text = "00";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button1_Click;
            // 
            // button8
            // 
            button8.Enabled = false;
            button8.Location = new Point(221, 303);
            button8.Name = "button8";
            button8.Size = new Size(83, 56);
            button8.TabIndex = 35;
            button8.Text = "9";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button1_Click;
            // 
            // button9
            // 
            button9.Enabled = false;
            button9.Location = new Point(117, 303);
            button9.Name = "button9";
            button9.Size = new Size(83, 56);
            button9.TabIndex = 34;
            button9.Text = "8";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button1_Click;
            // 
            // button10
            // 
            button10.Enabled = false;
            button10.Location = new Point(13, 303);
            button10.Name = "button10";
            button10.Size = new Size(83, 56);
            button10.TabIndex = 33;
            button10.Text = "7";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button1_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(221, 241);
            button5.Name = "button5";
            button5.Size = new Size(83, 56);
            button5.TabIndex = 32;
            button5.Text = "6";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button1_Click;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.Location = new Point(117, 241);
            button6.Name = "button6";
            button6.Size = new Size(83, 56);
            button6.TabIndex = 31;
            button6.Text = "5";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button1_Click;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(13, 241);
            button7.Name = "button7";
            button7.Size = new Size(83, 56);
            button7.TabIndex = 30;
            button7.Text = "4";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button1_Click;
            // 
            // clearBtn
            // 
            clearBtn.Location = new Point(236, 125);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(68, 48);
            clearBtn.TabIndex = 29;
            clearBtn.Text = "C";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(221, 179);
            button3.Name = "button3";
            button3.Size = new Size(83, 56);
            button3.TabIndex = 28;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button1_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(117, 179);
            button2.Name = "button2";
            button2.Size = new Size(83, 56);
            button2.TabIndex = 27;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button1_Click;
            // 
            // AmountTextBox
            // 
            AmountTextBox.Location = new Point(13, 125);
            AmountTextBox.Multiline = true;
            AmountTextBox.Name = "AmountTextBox";
            AmountTextBox.Size = new Size(216, 48);
            AmountTextBox.TabIndex = 26;
            AmountTextBox.TextChanged += AmountTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(206, 141);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 25;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(13, 179);
            button1.Name = "button1";
            button1.Size = new Size(83, 56);
            button1.TabIndex = 24;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Payment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 575);
            Controls.Add(ChangeLabel);
            Controls.Add(label3);
            Controls.Add(confirmBtn);
            Controls.Add(cancelBtn);
            Controls.Add(qpayBtn);
            Controls.Add(cradBtn);
            Controls.Add(cashBtn);
            Controls.Add(AmountLabel);
            Controls.Add(label2);
            Controls.Add(button11);
            Controls.Add(button12);
            Controls.Add(button13);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button10);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(clearBtn);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(AmountTextBox);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Payment";
            Text = "Payment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ChangeLabel;
        private Label label3;
        private Button confirmBtn;
        private Button cancelBtn;
        private Button qpayBtn;
        private Button cradBtn;
        private Button cashBtn;
        private Label AmountLabel;
        private Label label2;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button clearBtn;
        private Button button3;
        private Button button2;
        private TextBox AmountTextBox;
        private Label label1;
        private Button button1;
    }
}