﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwiftPayroll
{
    public partial class RegularEmployeeVIEW : UserControl
    {
        public RegularEmployeeVIEW()
        {
            InitializeComponent();
        }

        private void RegularEmployeeVIEW_Load(object sender, EventArgs e)
        {
     
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            ParentForm.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            ParentForm.Close();
        }
    }
}
