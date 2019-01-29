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
    /// Логика взаимодействия для AddDepWindow.xaml
    /// </summary>
    public partial class AddDepWindow : Window
    {
        public AddDepWindow(Rep dbEmpDep)
        {
            InitializeComponent();
            btn.Click += delegate
            {
                dbEmpDep.AddDep(txt.Text);
                this.DialogResult = true;
            };

        }
    }
}
