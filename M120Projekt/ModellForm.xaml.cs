using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        enum Zustand
        {
            Unvollständig,
            Unveraendert,
            Ungespeichert,
            Gespeichert
        }

        private Zustand zustand = Zustand.Unveraendert;

        public ModellForm()
        {
            InitializeComponent();
        }
        private void SaveModel(object sender, EventArgs e)
        {
            bool jahrgangValid = checkIfValidInput(jahrgang, "^([0-9]+)$");
            bool gewichtValid = checkIfValidInput(gewicht, "^([0-9]+)$");
            bool hoechstgeschwindigkeitValid = checkIfValidInput(hoechstgeschwindigkeit, "^([0-9]+)$");
            bool hubraumValid = checkIfValidInput(hubraum, "^([0-9]+)$");
            bool drehmomentValid = checkIfValidInput(drehmoment, "^([0-9]+)$");
            bool leistungValid = checkIfValidInput(leistung, "^([0-9]+)$");
            if( jahrgangValid && gewichtValid && hoechstgeschwindigkeitValid && hubraumValid && drehmomentValid && leistungValid )
            {
                zustand = Zustand.Gespeichert;
                MessageBox.Show("This would save the model!", null, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                return;
            }
        }
        private void Cancel(object sender, EventArgs e)
        {
            checkCurrentZustand((Button)sender);
        }
        private void textChanged(object sender, EventArgs e)
        {
            if(this.IsLoaded)
            {
                zustand = Zustand.Ungespeichert;
                checkIfComplete();
            }
        }
        private void checkCurrentZustand(Button sender)
        {
            if (sender.Name == "cancel")
            {
                if (zustand == Zustand.Unveraendert)
                {
                    Close();
                }
                else if (zustand == Zustand.Ungespeichert)
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Alle Änderungen gehen verloren", null, MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (dialogResult == MessageBoxResult.OK)
                    {
                        Close();
                    }
                }
            }
        }

        private void checkIfComplete()
        {
            if(name.Text != "" && marke.SelectedItem != null && jahrgang.Text != "" && bauart.Text != "" && leistung.Text != "" && drehmoment.Text != "" && hubraum.Text != "" && hoechstgeschwindigkeit.Text != "" && motor.Text != "" && gewicht.Text != "")
            {
                save.IsEnabled = true;
            }
        }

        private bool checkIfValidInput(object sender, String pattern)
        {
            TextBox textBox = sender as TextBox;
            Match match = Regex.Match(textBox.Text, pattern);
            if (match.Success)
            {
                textBox.ClearValue(TextBox.BorderBrushProperty);
                return true;
            }
            textBox.BorderBrush = Brushes.Red;
            return false;
        }
    }
}
