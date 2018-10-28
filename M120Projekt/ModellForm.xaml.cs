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
    /// Interaktionslogik für ModellForm.xaml
    /// </summary>
    public partial class ModellForm : Window
    {
        public ModellForm()
        {
            InitializeComponent();
        }
        private void SaveModel(object sender, EventArgs e)
        {
            MessageBox.Show("This would save the model!", null, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Cancel(object sender, EventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Alle Änderungen gehen verloren", null, MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.OK)
            {
                Close();
            }
        }
    }
}
