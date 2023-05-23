using System;
using Diplom.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Diplom.ViewModel
{
    public class StudentWindowViewModel : ViewModelBase
    {
        #region Свойства
        private List<Question> _questions;
        private List<string> _filterList = new();
        private string _filterValue;
        private List<Test> _testList;
        private List<int> _questionList = new();
        private List<Test> _displayingTest;

        
        #endregion
        #region Поля
        public List<Test> DisplayingTest
        {
            get { return _displayingTest; }
            set { Set(ref _displayingTest, value, nameof(DisplayingTest)); }
        }

        public List<int> QuestionList
        {
            get { return _questionList; }
            set { Set(ref _questionList, value, nameof(QuestionList));  }
        }
        public string FilterValue
        {
            get { return _filterValue; }
            set
            {
                Set(ref _filterValue, value, nameof(FilterValue));
                displayTest();
            }
        }

        public List<string> FilterList
        {
            get { return _filterList; }
            set { Set(ref _filterList, value, nameof(FilterList)); }
        }
        public List<Question> Questions
        {
            get { return _questions; }
            set { Set(ref _questions, value, nameof(Questions)); }
        }



        #endregion
        public StudentWindowViewModel()
        {
            using (ApplicationDbContext content = new ApplicationDbContext())
            { 
            FilterList.Add("Без фильтрации");
            foreach (var item in content.Disciplines.ToList())
            {
                FilterList.Add(item.Tittle);
            }
            _questions = content.Questions
                .Include(t=>t.TestNavigation)
                .ToList();
            _testList = content.Tests
                .Include(t => t.DisciplineNavigation)
                .ThenInclude(t=>t.TeacherNavigation)
                .Include(teac=>teac.DiscriptionNavigation)
                .ToList();
            }
            //DisplayingTest = new List<Test>(_testList); 
            _filterValue = FilterList[0];
            CountQuestion();
            displayTest();
        }
        private void displayTest()
        {
            DisplayingTest = FiltrByDiscipline(_testList);
            
        }
        private List<Test> FiltrByDiscipline(List<Test> tests)
        {
            if (_filterValue == FilterList[0])
                return tests;
            else
                return tests.Where(d => d.DisciplineNavigation.Tittle == FilterValue).ToList(); 
        }
        private void CountQuestion()
        {
            int j = 1;
            for (int i =0; i < _testList.Count; i++)
            {
                _questionList.Add(_questions.Where(t => t.Test == j).ToList().Count()) ;
                j =+1;
            }
            
        }
    }
}
