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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für ModellDetail.xaml
    /// </summary>
    public partial class ModellDetail : Window
    {
        public ModellDetail()
        {
            InitializeComponent();
        }
        private void CreateNewModel(object sender, EventArgs e)
        {
            ModellForm modelform = new ModellForm();
            modelform.Show();
        }
        private void UpdateModel(object sender, EventArgs e)
        {
            ModellForm modelform = new ModellForm();
            modelform.Show();
        }
        private void DeleteModel(object sender, EventArgs e)
        {
            MessageBox.Show("This would delete the model!", null, MessageBoxButton.YesNo, MessageBoxImage.Stop);
        }
    }
}
