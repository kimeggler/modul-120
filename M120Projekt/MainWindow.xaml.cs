﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Aufruf diverse APIDemo Methoden
            //APIDemo.DemoBCreate();
            //APIDemo.DemoACreate();
            //APIDemo.DemoARead();
            //APIDemo.DemoBRead();
            //APIDemo.DemoAUpdate();
            //APIDemo.DemoARead();
            //APIDemo.DemoBRead();
            //APIDemo.DemoADelete();
            //APIDemo.DemoBRead();
        }

        private void OpenModel(object sender, EventArgs e)
        {
            ModellDetail detail = new ModellDetail();
            detail.Show();
        }
    }
}
