using Diplom.Commands;
using Diplom.DataBase;
using Diplom.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Diplom.ViewModel
{
    public class RegistrationStudentViewModel : ViewModelBase
    {
        #region Свойтства
        ApplicationDbContext Context = new ApplicationDbContext();
        private List<Account>? _accounts;
        private int _studentId;
        private int _accountId;
        public bool isChange { get; set; }



        private string _fio;
        private string _login;
        private string _password;
        #endregion
        #region Поля


        public string FIO
        {
            get { return _fio; }
            set { Set(ref _fio, value, nameof(FIO)); }
        }
        public string Login
        {
            get { return _login; }
            set { Set(ref _login, value, nameof(Login)); }
        }
        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value, nameof(Password)); }
        }

        public List<Account> Accounts
        {
            get { return _accounts; }
            set { Set(ref _accounts, value, nameof(Accounts)); }
        }
        #endregion
        public RegistrationStudentViewModel()
        {
            Accounts = Context.Accounts
                .Include(s => s.Students)
                .ToList();
        }
        #region Методы
        private Account? GetAccount()
        {
            if (Login == null || Login.Replace(" ", "").Length == 0 ||
                    Password == null || Password.Replace(" ", "").Length == 0)
            {
                RegistrationNewStudent wnd = new RegistrationNewStudent();
                SetRedBoxBlockControl(wnd);
                return null;
            }
            else
            {
                Account account = new Account();
                account.Id = _accountId;
                account.Login = Login;
                account.Password = Password;
                account.Role = 1;
                return account;

            }
        }
        private Student? GetStudent()
        {
            if (_fio == null || _fio.Replace(" ", "").Length == 0)
            {
                RegistrationNewStudent wnd = new RegistrationNewStudent();
                SetRedBoxBlockControl(wnd);

                return null;
            }
            else
            {
                Student student = new Student();
                student.Id = _studentId;
                student.Fio = _fio;
                student.Account = Accounts.Last().Id;
                return student;
            }
        }
        private void SetRedBoxBlockControl(RegistrationNewStudent wnd)
        {
            if (Login == null || Login.Replace(" ", "").Length == 0)
                wnd.LoginBox.BorderBrush = Brushes.Red;
            if (Password == null || Password.Replace(" ", "").Length == 0)
                wnd.PasswordBox.BorderBrush = Brushes.Red;
            if (_fio == null || _fio.Replace(" ", "").Length == 0 || wnd.FioBox.Text == null || wnd.FioBox.Text.Replace(" ", "").Length == 0)
                wnd.FioBox.BorderBrush = Brushes.Red;
        }

        private void RegNewStudent(Account? accounts, Student? students)
        {
            if (accounts == null || students == null)
                return;
            using (var db = new ApplicationDbContext())
            {

                db.Accounts.Add(accounts);
                db.Students.Add(students);
                db.SaveChanges();
            }
        }

        #endregion
        public ICommand AddStudent => new Command(s =>
        {
            RegistrationNewStudent wnd = s as RegistrationNewStudent;
            Account? checkAcc = new Account();
            Student? checkStud = new Student();
            checkAcc = GetAccount();
            checkStud = GetStudent();
            if (Login == null || Login.Replace(" ", "").Length == 0 ||
                    Password == null || Password.Replace(" ", "").Length == 0 ||
                    _fio == null || _fio.Replace(" ", "").Length == 0)
            {
                SetRedBoxBlockControl(wnd);
            }
            else
            {
                bool forCheckRepeat = false;
                for (int i = 0; i < Accounts.Count; i++)
                {
                    if (Login == Accounts[i].Login && Password == Accounts[i].Password)
                    { MessageBox.Show("Логин и пароль уже существует", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Error); forCheckRepeat = true; break; }
                    else if (Login == Accounts[i].Login)
                    { MessageBox.Show("Логин уже существует", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Error); forCheckRepeat = true; break; }
                }
                if (forCheckRepeat == false)
                {
                    RegNewStudent(GetAccount(), GetStudent());
                    MessageBox.Show("Запись добавлена", "ВНИМАНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
                    isChange = true;
                }
            }
        });
    }
}
