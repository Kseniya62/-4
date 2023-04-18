using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Подготовка_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        peopleEntities db = Class1.Getcontext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.People.Load();
            List.ItemsSource = db.People.Local.ToBindingList();
            List1.ItemsSource = db.People.Local.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add d = new Add();
            d.ShowDialog();
            List.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Class1.Id = (People)List.SelectedItem;
            Edit ed = new Edit();
            ed.ShowDialog();
            List.Focus();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rez = MessageBox.Show("Удалить запись?", "Удалить запись",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(rez== MessageBoxResult.Yes)
            {
                try
                {
                    var row = (People)List.SelectedItem;
                    db.People.Remove(row);
                    db.SaveChanges();
                    List.Items.Refresh();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберете запись");
                }
            }
        }

        private void List1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List1.ItemsSource = db.People.Local.ToList();
            List1.ItemsSource = db.People.Local.ToList();
            var filtr = db.People.Local.ToList();
            People people = List1.SelectedItem as People;
            if (people != null)
            {
                filtr = filtr.Where(p => p.Address == people.Address).ToList();
            }
            List.ItemsSource = filtr;
        }
    }
}
