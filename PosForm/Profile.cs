using PosLibrary.model;
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
    public partial class Profile : Form
    {
        private User user;
        public Profile(User user)
        {
            this.user = user;
            InitializeComponent();
            LoadingProfile();
        }

        private void LoadingProfile()
        {
            username.Text = user.UserName;
            role.Text = user.Role.ToString();
            if (user.Role == 0)
            {
                accAddBtn.Enabled = true;
                roleCombo.Enabled = true;
            }
        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
