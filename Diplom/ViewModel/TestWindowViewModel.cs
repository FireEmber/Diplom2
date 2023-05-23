using Diplom.Commands;
using Diplom.DataBase;
using Diplom.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Diplom.ViewModel
{
    public class TestWindowViewModel:ViewModelBase
    {
        #region Поля
        private int _scoreTrueAnswer;
        private string _choiceVariable1 = "";
        private string _choiseVariable2 = "";
        private string _choiceVariable3 = "";
        private string _choiceVariable4 = "";
        private string _exirsise="";
        private string _question="";
        private List<Question> _questions=new List<Question>();
        private int index;
        private List<string> newQuestion = new();
        private int _countQuestins;
        private int _allCountQuestion;
        private int _testID;
        private Account _account;
        private List<Question> _listQuestion= new List<Question>();
        private List<int> _listId = new();

        #endregion
        #region Свойства
        public List<Question> ListQuestion
        {
            get { return _listQuestion; }
            set { Set(ref _listQuestion, value, nameof(ListQuestion)); }
        }
        public Account Account
        {
            get { return _account; }
            set { Set(ref _account, value, nameof(Account)); }
        }
        public int TestID
        {
            get { return _testID; }
            set { Set(ref _testID, value, nameof(TestID)); }
        }
        public bool isChange = false;
        public int AllCountQuestion
        {
            get { return _allCountQuestion; }
            set { Set(ref _allCountQuestion, value, nameof(AllCountQuestion)); }
        }
        public int CountQuestins
        {
            get { return _countQuestins; }
            set { Set(ref _countQuestins, value, nameof(CountQuestins)); }
        }
        public int ScoreTrueAnswer
        {
            get { return _scoreTrueAnswer; }
            set { Set(ref _scoreTrueAnswer, value,nameof(ScoreTrueAnswer)); }
        }
        public string ChoiceVariable1
        {
            get { return _choiceVariable1; }
            set { Set(ref _choiceVariable1, value, nameof(ChoiceVariable1)); }
        }
        public string ChoiceVariable2
        {
            get { return _choiseVariable2; }
            set { Set(ref _choiseVariable2, value,nameof(ChoiceVariable2)); }
        }
        public string ChoiceVariable3
        {
            get { return _choiceVariable3; }
            set { Set(ref _choiceVariable3, value, nameof(ChoiceVariable3)); }
        }
        public string ChoiceVariable4
        {
            get { return _choiceVariable4; }
            set { Set(ref _choiceVariable4, value, nameof(ChoiceVariable4)); }
        }
        public string Exirsise
        {
            get { return _exirsise; }
            set { Set(ref _exirsise, value, nameof(Exirsise)); }
        }
        public string Question1
        {
            get { return _question; }
            set { Set(ref _question, value, nameof(Question1)) ; }
        }
        public List<Question> Questions
        {
            get { return _questions; }
            set { Set(ref _questions, value, nameof(Questions)); }
        } 
        #endregion
        public TestWindowViewModel()
        {

        }
        public void updateTest(int idTest,Account LoginAccount)
        {
            _account = LoginAccount;
            _testID = idTest;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                _questions = context.Questions
                    .Where(q=>q.Test==_testID)
                    .Include(ta => ta.FalseAnswerNavigation)
                    .Include(fa => fa.TrueAnswerNavigation)
                    .ToList();
            }
            _allCountQuestion = _questions.Count();
            _listId = _questions.Select(q => q.Id).ToList();
            _countQuestins = 0;
            index=0;
            SetAnswer();
        }
        public ICommand ChoseAnswerButton1 => new Command(s =>
        {
            TestWindow wnd = new(_account, _testID);
            CountTrullyAnsweronButton1(wnd);
            SetAnswer();
            isChange = true;
        });
        public ICommand ChoseAnswerButton2 => new Command(s =>
        {
            TestWindow wnd = new(_account, _testID);
            CountTrullyAnsweronButton1(wnd);
            SetAnswer();
            isChange = true;
        }); 
        public ICommand ChoseAnswerButton3 => new Command(s =>
        {
            TestWindow wnd = new(_account, _testID);
            CountTrullyAnsweronButton1(wnd);
            SetAnswer();
            isChange = true;
        }); 
        public ICommand ChoseAnswerButton4 => new Command(s =>
        {
            TestWindow wnd = new(_account,_testID);
            CountTrullyAnsweronButton1(wnd);
            SetAnswer();
            isChange = true;
        });
        public void CountTrullyAnsweronButton1(TestWindow wnd)
        {
            if (wnd.AnswerButton1.Content.ToString() == _questions[index].TrueAnswerNavigation.TrueAnswer1)
            {
                _scoreTrueAnswer += 1;
            }
        }
        public void CountTrullyAnsweronButton2(TestWindow wnd)
        {
            if (wnd.AnswerButton2.Content.ToString() == _questions[index].TrueAnswerNavigation.TrueAnswer1)
            {
                _scoreTrueAnswer += 1;
            }
        }
        public void CountTrullyAnsweronButton3(TestWindow wnd)
        {
            if (wnd.AnswerButton3.Content.ToString() == _questions[index].TrueAnswerNavigation.TrueAnswer1)
            {
                _scoreTrueAnswer += 1;
            }
        }
        public void CountTrullyAnsweronButton4(TestWindow wnd)
        {
            if (wnd.AnswerButton4.Content.ToString() == _questions[index].TrueAnswerNavigation.TrueAnswer1)
            {
                _scoreTrueAnswer += 1;
            }
        }
        public void SetAnswer()
        {
            Exirsise = _questions[index].Exirsise;
            Question1 = _questions[index].Question1;
            Random rnd = new Random();
            switch (rnd.Next(1,4))
            {
                case (1):
                    _choiceVariable1 = _questions[index].TrueAnswerNavigation.TrueAnswer1;
                    _choiseVariable2 = _questions[index].FalseAnswerNavigation.FalseAnswer1;
                    _choiceVariable3 = _questions[index].FalseAnswerNavigation.FalseAnswer2;
                    _choiceVariable4 = _questions[index].FalseAnswerNavigation.FalseAnswer3;
                    break;
                case (2):
                    _choiceVariable1 = _questions[index].FalseAnswerNavigation.FalseAnswer3;
                    _choiseVariable2 = _questions[index].TrueAnswerNavigation.TrueAnswer1;
                    _choiceVariable3 = _questions[index].FalseAnswerNavigation.FalseAnswer1;
                    _choiceVariable4 = _questions[index].FalseAnswerNavigation.FalseAnswer2;
                    break;
                case (3):
                    _choiceVariable1 = _questions[index].FalseAnswerNavigation.FalseAnswer2;
                    _choiseVariable2 = _questions[index].FalseAnswerNavigation.FalseAnswer3;
                    _choiceVariable3 = _questions[index].TrueAnswerNavigation.TrueAnswer1;
                    _choiceVariable4 = _questions[index].FalseAnswerNavigation.FalseAnswer1;
                    break;
                case (4):
                    _choiceVariable1 = _questions[index].FalseAnswerNavigation.FalseAnswer1;
                    _choiseVariable2 = _questions[index].FalseAnswerNavigation.FalseAnswer2;
                    _choiceVariable3 = _questions[index].FalseAnswerNavigation.FalseAnswer3;
                    _choiceVariable4 = _questions[index].TrueAnswerNavigation.TrueAnswer1;
                    break;
            }
            index = +1;
            CountQuestins = +1;
            if (index > _listId.Count)
            {
                TestScore testScore = new();
                testScore.Student = _account.Id;
                testScore.Test = _testID;
                //<50% - 2, <70%&>50% - 3, <90%&70> - 4, 90+ - 5
                float procent;
                if (_scoreTrueAnswer != 0)
                {
                    
                    procent = _scoreTrueAnswer / index * 100;
                    switch (procent)
                    {
                        case < 50:
                            MessageBox.Show("Вы набрали меньше 50%. Поздравляю вы получили 2");
                            testScore.TestScore1 = 2;
                            break;
                        case (<70):
                            MessageBox.Show("Вы набрали меньше 70%. Поздравляю вы получили 3");
                            testScore.TestScore1 = 3;
                            break;
                        case < 90:
                            MessageBox.Show("Вы набрали меньше 90%. Поздравляю вы получили 4");
                            testScore.TestScore1 = 4;
                            break;
                        case > 90:
                            MessageBox.Show("Вы набрали больше 90%. Поздравляю вы получили 5");
                            testScore.TestScore1 = 5;
                            break;
                    }
                }
                else
                { 
                    MessageBox.Show("Ты идиот да? набрать 0 нахуй, ноль, ЗЕРО СУКА, как мне это вносить в базу данных? как ноль или что?");
                    testScore.TestScore1 = 2;
                }
                using (var db = new ApplicationDbContext())
                {
                    db.TestScores.Add(testScore);
                    db.SaveChanges();
                }
                TestWindow wnd = new(_account, _testID);
                StudentWindow swnd = new(_account);
                swnd.Show();
                wnd.Close();
            }
        }
    }
}
