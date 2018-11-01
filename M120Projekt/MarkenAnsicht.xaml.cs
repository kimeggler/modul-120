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
    /// Interaktionslogik für MarkenAnsicht.xaml
    /// </summary>
    public partial class MarkenAnsicht : UserControl
    {
        MainWindow mainwindow;
        public MarkenAnsicht(MainWindow parent)
        {
            InitializeComponent();
            mainwindow = parent;
        }

        private void openModel(object sender, EventArgs e)
        {
            mainwindow.setZustand(MainWindow.Zustand.DetailAnsicht.ToString());
        }
    }
}
