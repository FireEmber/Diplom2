using Diplom.DataBase;
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
    /// Логика взаимодействия для TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public TeacherWindow(Account account)
        {
            InitializeComponent();
        }

        private void RegistNewStudent_Click(object sender, RoutedEventArgs e)
        {
            RegistrationNewStudent open = new RegistrationNewStudent();
            open.Show();

        }

        private void GotoCreateNewTest_Click(object sender, RoutedEventArgs e)
        {
            CreateTestWindow open = new CreateTestWindow();
            open.Show();
        }

        private void GotoAttest_Click(object sender, RoutedEventArgs e)
        {
            TestScoreWindow open = new TestScoreWindow();
            open.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Login open = new Login();
            open.Show();
            this.Close();
        }
    }
}
