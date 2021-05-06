using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace login_and_Register_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Server=10.14.2.24\SQLEXPRESS;Database=saumenudb;User Id = sa; password=Andr1234;Trusted_Connection=False;MultipleActiveResultSets=true;");
       
     

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string login = "SELECT * FROM Users WHERE number= '" + phonenumber.Text + "' and password= '" + txtpassword.Text + "'";
            
            SqlCommand command = connection.CreateCommand();
            command.CommandText = login;
            SqlDataReader dr = command.ExecuteReader();
            

           

            if (dr.Read() == true)
            {
                MessageBox.Show("You are registered for our service!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                new dashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Number or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phonenumber.Text = "";
                txtpassword.Text = "";
                phonenumber.Focus();
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            phonenumber.Text = "";
            txtpassword.Text = "";
            phonenumber.Focus();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                
            }
            else
            {
                txtpassword.PasswordChar = '•';
                
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
