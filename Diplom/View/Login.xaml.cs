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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ApplicationDbContext context = new ApplicationDbContext();
        List<Account> accounts = new List<Account>();
        public Login()
        {
            InitializeComponent();
            accounts = context.Accounts.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (LoginBox.Text == accounts[i].Login && PasswordBox.Text == accounts[i].Password)
                {
                    if (accounts[i].Role == 1)
                    {
                        StudentWindow open = new StudentWindow(accounts[i]);
                        open.Show();
                        this.Close();
                    }
                    else if (accounts[i].Role == 2)
                    {
                        TeacherWindow open = new TeacherWindow(accounts[i]);
                        open.Show();
                        this.Close();
                    }
                    else if  (accounts[i].Role == 3)
                    {
                        //Окно админа
                    }
                    else
                    {
                        if (LoginBox.Text != accounts[i].Login)
                            MessageBox.Show("Вы ввели неправильный логин", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Warning);
                        else if (PasswordBox.Text != accounts[i].Password)
                            MessageBox.Show("Вы ввели неправильный пароль", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Warning);
                        else
                            MessageBox.Show("Вы ввели неправильный логин и пароль", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }    

                }
                }
        }
    }
}
