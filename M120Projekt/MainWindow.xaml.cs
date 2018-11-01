using System;
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

        private ModellDetail modeldetail;
        private TopDownNavigation topdownnav;
        private MarkenAnsicht markenansicht;
        private ModellForm modelform;
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

            topdownnav = new TopDownNavigation(this);
            modeldetail = new ModellDetail(this);
            markenansicht = new MarkenAnsicht(this);
            modelform = new ModellForm(this);

            topdown.Children.Add(topdownnav);

            renderView();
            renderTopDownNav();
        }

        public enum Zustand
        {
            Listenansicht,
            MarkenAnsicht,
            DetailAnsicht,
            BearbeitungsAnsicht,
            Gespeichert,
        }
        private string activeZustand = Zustand.MarkenAnsicht.ToString();

        public string getZustand()
        {
            return activeZustand;
        }

        public void setZustand(string zustand)
        {
            activeZustand = zustand;
            renderTopDownNav();
            renderView();
        }

        private void neu_click(object sender, EventArgs e)
        {
            return;
        }

        private void renderTopDownNav()
        {
            string activeZustand = getZustand();
            if (activeZustand == "Listenansicht")
            {
                topdownnav.list();
            }
            else if (activeZustand == "MarkenAnsicht")
            {
                topdownnav.marke();
            }
            else if (activeZustand == "DetailAnsicht")
            {
                topdownnav.detail();
            }
            else if (activeZustand == "BearbeitungsAnsicht")
            {
                topdownnav.edit();
            }
        }

        private void renderView()
        {
            string activeZustand = getZustand();
            if (activeZustand == "Listenansicht")
            {
                platzhalter.Content = modeldetail;
            }
            else if (activeZustand == "MarkenAnsicht")
            {
                platzhalter.Content = markenansicht;
            }
            else if (activeZustand == "DetailAnsicht")
            {
                platzhalter.Content = modeldetail;
            }
            else if (activeZustand == "BearbeitungsAnsicht")
            {
                platzhalter.Content = modelform;
            }
        }
    }
}
