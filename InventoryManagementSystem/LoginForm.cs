using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-89C4245;Initial Catalog=testsql;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPass.Checked==false)
                txtPass.UseSystemPasswordChar = true;
            else txtPass.UseSystemPasswordChar = false;
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //pictureye klik etdikde applicationdan chixilmasi
            if(MessageBox.Show("Exit aplication", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cm=new SqlCommand("SELECT *FROM tbUser WHERE username=@username AND password=@password",con);
                cm.Parameters.AddWithValue("@username",txtName.Text);
                cm.Parameters.AddWithValue("@password",txtPass.Text);
                con.Open(); 
                dr=cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows) 
                {//burda daxil olanda fullnamenin verilmesi
                    MessageBox.Show("Welcome " + dr["fullname"].ToString() + " ", "Acces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm mainForm=new MainForm();   
                    mainForm.ShowDialog();

                }
                else
                {
                    MessageBox.Show(" Invalid password or username ","Acces",MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                con.Close();

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
