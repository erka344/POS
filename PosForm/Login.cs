using PosLibrary.serve;

namespace PosForm
{
    public partial class Form1 : Form
    {
        private UserServe userServe;
        private readonly string ConnectionString = $"Data Source=\"C:\\Users\\erka\\source\\repos\\Pos\\PosForm\\PosDatabase.db\";";
        public Form1()
        {
            InitializeComponent();
            userServe = new UserServe(ConnectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            var ValidUser = userServe.Authentication(UserNameTextBox.Text, PasswordTextBox.Text);

            if (ValidUser != null)
            {
                // Нэвтрэлт амжилттай бол login form-ыг нууж, гол дэлгэц гаргана
                this.Hide();

                MainScreen mainScreen = new MainScreen();
                mainScreen.ShowDialog();

                // Гол дэлгэц хаагдсан дараа login form-ыг хаах
                this.Close();
            }
            else
            {
                MessageBox.Show("Хэрэглэгчийн нэр эсвэл нууц үг буруу байна.", "Нэвтрэлт амжилтгүй", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
