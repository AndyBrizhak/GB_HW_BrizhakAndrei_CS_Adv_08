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
    /// Логика взаимодействия для EditEmpWindow.xaml
    /// </summary>
    public partial class EditEmpWindow : Window
    {
        //public EditEmpWindow(int i, Rep dbEmpDep)
        public EditEmpWindow(Employee selEmp, Rep dbEmpDep)
        {
            InitializeComponent();
            btn.Click += delegate
            {
                //var selEmp = dbEmpDep.DbEmployees.Single(e => e.GetHashCode() == i);
                dbEmpDep.EdEmp(selEmp, txt.Text);
               
                this.DialogResult = true;
            };

        }

        
    }
}
