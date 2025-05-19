using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosForm
{
    public partial class Payment : Form
    {
        private decimal TotalAmount;
        public Payment(int totalAmount)
        {
            InitializeComponent();
            TotalAmount = totalAmount;
            AmountLabel.Text = $"${totalAmount}";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal paidAmount;
            decimal totalAmount = TotalAmount; // TotalAmount гэдэг нь танай class-ийн гишүүн гэж үзлээ

            if (decimal.TryParse(AmountTextBox.Text, out paidAmount))
            {
                ChangeLabel.Text = $"${paidAmount - totalAmount}";
            }
            else
            {
                ChangeLabel.Text = "$0.00";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                AmountTextBox.Text += btn.Text;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            AmountTextBox.Text = string.Empty;
        }

        private void cashBtn_Click(object sender, EventArgs e)
        {
            string[] buttonsToDisable = { "button2", "button3", "button5", "button6", "button7", "button8", "button9", "button10", "button11", "button12", "button13", "button1" };

            foreach (string btnName in buttonsToDisable)
            {
                Control[] ctrls = this.Controls.Find(btnName, true);
                if (ctrls.Length > 0 && ctrls[0] is Button btn)
                {
                    btn.Enabled = true;
                }
            }
        }
    }
}
