using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoanPro
{
    public partial class AdminLogin : Form
    {
        MySqlCommand cmnd;
        MySqlConnection conn;
        string connection = "server=localhost;database=loanpro;UID=root;password=;";
        
        string correctUsername = "LoanPro@gmail.com";
        string correctPassword = "@Password";

        private bool ContainsSpecialCharacter(string password)
        {
            string specialChars = "!@#$%^&*()_+-={}[]:;'\"<>,.?/\\|`~";

            foreach (char c in password)
            {
                if (specialChars.Contains(c.ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        public AdminLogin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.IconRight = Properties.Resources.view;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_IconRightClick(object sender, EventArgs e)
        {
            if(txtPassword.UseSystemPasswordChar==true)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.IconRight = Properties.Resources.hide;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.IconRight = Properties.Resources.view;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            // Username Validation: Must contain "@" and end with "gmail.com"
            if (!enteredUsername.Contains("@") && !enteredUsername.EndsWith("gmail.com"))
            {
                MessageBox.Show("Username must be a valid Gmaigl address (e.g., example@gmail.com).", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password Validation: Must contain at least one special character
            if (!ContainsSpecialCharacter(enteredPassword))
            {
                MessageBox.Show("Password must contain at least one special character (e.g., @, #, *, etc.).", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Credentials Check
            if (enteredUsername == correctUsername && enteredPassword == correctPassword)
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                AdminDashboard form2 = new AdminDashboard();
                this.Hide();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
