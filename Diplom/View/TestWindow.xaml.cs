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
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private readonly TestWindowViewModel? _testWindowViewModel = null;
        bool check = false;
        public TestWindow(Account account, int testID)
        {
            InitializeComponent();
            if(check!=true)
            { 
                _testWindowViewModel = (TestWindowViewModel)DataContext;
                if (_testWindowViewModel != null)
                {
                    _testWindowViewModel.updateTest(testID,account);
                    TestIDAccount.Text = _testWindowViewModel.Account.Login;
                    TestIdtest.Text = Convert.ToString(_testWindowViewModel.TestID);
                    check=true;
                }
            }

        }

    }
}
