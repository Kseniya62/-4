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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
            Id.Focus();
        }
        peopleEntities db = Class1.Getcontext();
        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder e1 = new StringBuilder();
                if (Id.Text.Length == 0) e1.AppendLine("Введите код");


                if(e1.Length > 0)
                {
                    MessageBox.Show(e1.ToString());
                    return;
                }

                People p1 = new People();
                p1.Id = Convert.ToInt32(Id.Text);
                

                db.People.Add(p1);
                db.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cansel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
