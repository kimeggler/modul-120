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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für TopDownNavigation.xaml
    /// </summary>
    public partial class TopDownNavigation : UserControl
    {
        private MainWindow mainwindow;
        public TopDownNavigation(MainWindow parent)
        {
            InitializeComponent();
            mainwindow = parent;
        }

        public void list()
        {
            back.IsEnabled = false;
            newbutton.IsEnabled = true;
            save.IsEnabled = false;
            editButton.IsEnabled = false;
            delete.IsEnabled = false;
        }

        public void marke()
        {
            back.IsEnabled = false;
            newbutton.IsEnabled = true;
            save.IsEnabled = false;
            editButton.IsEnabled = false;
            delete.IsEnabled = false;
        }

        public void detail()
        {
            back.IsEnabled = false;
            newbutton.IsEnabled = true;
            save.IsEnabled = false;
            editButton.IsEnabled = true;
            delete.IsEnabled = true;
        }

        public void edit()
        {
            back.IsEnabled = false;
            newbutton.IsEnabled = false;
            save.IsEnabled = true;
            editButton.IsEnabled = false;
            delete.IsEnabled = true;
        }

        //private void renderButtons()
        //{
        //    string activeZustand = mainwindow.getZustand();
        //    if (activeZustand == "Listenansicht")
        //    {
        //        buttonField.Children.Clear();

        //        ColumnDefinition first = new ColumnDefinition();
        //        first.Width = new GridLength(90);
        //        buttonField.ColumnDefinitions.Add(first);

        //        Button neu = new Button();
        //        neu.Content = "Neu";
        //        neu.Name = "new";
        //        buttonField.Children.Add(neu);
        //    }
        //    else if (activeZustand == "MarkenAnsicht")
        //    {
        //        buttonField.Children.Clear();

        //        ColumnDefinition first = new ColumnDefinition();
        //        first.Width = new GridLength(90);
        //        buttonField.ColumnDefinitions.Add(first);

        //        ColumnDefinition second = new ColumnDefinition();
        //        second.Width = new GridLength(90);
        //        buttonField.ColumnDefinitions.Add(second);

        //        ColumnDefinition third = new ColumnDefinition();
        //        third.Width = new GridLength(90);
        //        buttonField.ColumnDefinitions.Add(third);

        //        Button neu = new Button();
        //        neu.Content = "Neu";
        //        neu.Name = "new";
        //        buttonField.Children.Add(neu);
        //        Grid.SetColumn(neu, 0);

        //        Button edit = new Button();
        //        edit.Content = "Test";
        //        edit.Name = "edit";
        //        buttonField.Children.Add(edit);
        //        Grid.SetColumn(edit, 1);

        //        Button delete = new Button();
        //        delete.Content = "Löschen";
        //        delete.Name = "delete";
        //        buttonField.Children.Add(delete);
        //        Grid.SetColumn(delete, 2);

        //    }
        //    else if (activeZustand == "DetailAnsicht")
        //    {
        //        buttonField.Children.Clear();

        //        ColumnDefinition first = new ColumnDefinition();
        //        first.Width = new GridLength(90);
        //        buttonField.ColumnDefinitions.Add(first);
        //        ColumnDefinition second = new ColumnDefinition();
        //        second.Width = new GridLength(90);
        //        buttonField.ColumnDefinitions.Add(second);
        //        ColumnDefinition third = new ColumnDefinition();
        //        third.Width = new GridLength(90);
        //        buttonField.ColumnDefinitions.Add(third);

        //        Button neu = new Button(); Thickness margin = neu.Margin;
        //        margin.Right = 20;
        //        neu.Margin = margin;
        //        neu.Content = "Neu";
        //        neu.Name = "new";
        //        buttonField.Children.Add(neu);

        //        Button edit = new Button();
        //        edit.Margin = margin;
        //        edit.Content = "Bearbeiten";
        //        edit.Name = "edit";
        //        buttonField.Children.Add(edit);

        //        Button delete = new Button();
        //        delete.Margin = margin;
        //        delete.Content = "Löschen";
        //        delete.Name = "delete";
        //        buttonField.Children.Add(delete);

        //    }
        //    else if (activeZustand == "BearbeitungsAnsicht")
        //    {
        //        buttonField.Children.Clear();

        //        ColumnDefinition first = new ColumnDefinition();
        //        first.Width = new GridLength(90);
        //        buttonField.ColumnDefinitions.Add(first);
        //        ColumnDefinition second = new ColumnDefinition();
        //        second.Width = new GridLength(90);
        //        buttonField.ColumnDefinitions.Add(second);

        //        Button save = new Button();
        //        Thickness margin = save.Margin;
        //        margin.Right = 20;
        //        save.Margin = margin;
        //        save.Content = "Neu";
        //        save.Name = "new";
        //        buttonField.Children.Add(save);

        //        Button cancel = new Button();
        //        cancel.Margin = margin;
        //        cancel.Content = "Bearbeiten";
        //        cancel.Name = "edit";
        //        buttonField.Children.Add(cancel);
        //    }
        //    else if (activeZustand == "Gespeichert")
        //    {
        //        buttonField.Children.Clear();
        //    }

    }
}
