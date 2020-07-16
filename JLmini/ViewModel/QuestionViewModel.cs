using JLmini.Model;
using JLmini.MVVM;
using JLmini.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace JLmini.ViewModel
{
    class QuestionViewModel : ViewModelBase
    {
        private Question selectedQuestion;
        private CommandBase addQuestion;
        private CommandBase removeQuestion;
        public ObservableCollection<Question> Questions { get; set; }

        public Question SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                selectedQuestion = value;
                OnPropertyChanged("SelectedQuestion");
            }
        }

        public CommandBase AddQuestion
        {
            get
            {
                return addQuestion ??
            (addQuestion = new CommandBase(obj =>
            {
                Questions.Add(SelectedQuestion);
                SelectedQuestion = new Question();
            }));
            }
        }
        public CommandBase RemoveQuestion
        {
            get
            {
                return removeQuestion ??
                    (removeQuestion = new CommandBase(obj =>
                    {
                        Question question = obj as Question;
                        if (question != null)
                        {
                            Questions.Remove(question);
                        }
                    },
                    (obj) => Questions.Count > 0));
            }
        }


        public QuestionViewModel()
        {
            SelectedQuestion = new Question();
            Questions = new ObservableCollection<Question>
            {
                new Question{QuestionText="Основные понятия", Section = "БД", Stage ="Первая", Points=2, Time=20},
                new Question{QuestionText="Протокол HTTP", Section = "Web", Stage ="Первая", Points=1, Time=10},
                new Question{QuestionText="Командная оболочка CMD(Windows)", Section = "Другие знания", Stage ="Третья", Points=1, Time=5},
                new Question{QuestionText=".Net Core", Section = ".Net", Stage ="Третья", Points=3, Time=20}
            };
        }

       
    }
}

