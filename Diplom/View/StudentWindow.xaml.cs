using Diplom.DataBase;
using Diplom.ViewModel;
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


namespace Diplom.View
{
    /// <summary>
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        Account accounts;
        public StudentWindow(Account account)
        {
            InitializeComponent();
            accounts = account;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Login exit = new();
            exit.Show();
            this.Close();
        }

        private void GOtoTest_Click(object sender, RoutedEventArgs e)
        {
            
            TestWindow exit = new(accounts, ChoseTest.SelectedIndex+1);
            exit.Show();
            this.Close();
        }
    }
}
