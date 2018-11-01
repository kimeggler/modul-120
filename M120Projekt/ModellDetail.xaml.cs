using System;
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
    public partial class ModellDetail : UserControl
    {
        private MainWindow mainwindow;
        public ModellDetail(MainWindow parent)
        {
            InitializeComponent();
            mainwindow = parent;
        }
        private void CreateNewModel(object sender, EventArgs e)
        {
            //ModellForm modelform = new ModellForm();
            //modelform.Show();
        }
        private void UpdateModel(object sender, EventArgs e)
        {
            mainwindow.setZustand(MainWindow.Zustand.BearbeitungsAnsicht.ToString());
        }
        private void DeleteModel(object sender, EventArgs e)
        {
            if (MessageBox.Show("This would delete the model!", null, MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                mainwindow.setZustand(MainWindow.Zustand.MarkenAnsicht.ToString());
            }
            else {
                return;
            }
            
        }
    }
}
