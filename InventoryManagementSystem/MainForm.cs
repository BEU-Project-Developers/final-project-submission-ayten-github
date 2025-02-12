﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        //to show subform in mainform
        private Form activeform=null;
        private void openChilForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();//eger form aktivdirse o close olunur
            activeform = childForm;//daha sonra ise aktiv child form olur
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);//artiq panele elave olunur 
            panelMain.Tag = childForm;//referans daxil edr
            childForm.BringToFront();//child formu digerlerinin qarshisni getiir
            childForm.Show();

        }
        //bu methodla her hansi bir imageye klik etdiyimz zaman o formu ekranda gostersin
        private void btnUser_Click(object sender, EventArgs e)
        {
            openChilForm(new UserForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChilForm(new CustomerForm());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            openChilForm(new CategoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChilForm(new ProductForm());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChilForm(new OrderForm());  
        }
    }
}
