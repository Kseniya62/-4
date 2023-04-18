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

namespace Подготовка_4
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit()
        {
            InitializeComponent();
        }
        peopleEntities db = Class1.Getcontext();
        People p1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            p1 = Class1.Id;
            Id.Text = p1.Id.ToString();
            Name.Text = p1.Name;
        }
    }
}
