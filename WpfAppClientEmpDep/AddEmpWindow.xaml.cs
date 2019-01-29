﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppClientEmpDep
{
    /// <summary>
    /// Логика взаимодействия для AddEmpWindow.xaml
    /// </summary>
    public partial class AddEmpWindow : Window
    {
        public AddEmpWindow(Rep dbEmpDep, int IDep)
        {
            InitializeComponent();
            btnAddEmp.Click += delegate
            {
                dbEmpDep.AddEmp(txtBoxFName.Text, txtBoxLName.Text, txtBoxAge.Text, IDep);
                this.DialogResult = true;
            };
        }
    }
}
