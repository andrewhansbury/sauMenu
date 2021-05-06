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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();

        }

        
        SqlConnection connection = new SqlConnection(@"Server=10.14.2.24\SQLEXPRESS;Database=saumenudb;User Id = sa; password=Andr1234;Trusted_Connection=False;MultipleActiveResultSets=true;");
    
        
        
        //OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            if (phonenumber.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPassword.Text == txtComPassword.Text)
            {
                connection.Open();
                string register = "INSERT INTO Users VALUES ('" + phonenumber.Text + "','" + txtPassword.Text + "')";
                SqlCommand command = connection.CreateCommand();
                command.CommandText = register;
                command.ExecuteNonQuery();
                connection.Close();

                phonenumber.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";

                MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Passwords does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            phonenumber.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            phonenumber.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            //label2.Text = kryptonDateTimePicker1.Value.ToShortDateString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
