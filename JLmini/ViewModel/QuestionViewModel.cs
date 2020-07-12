using JLmini.Model;
using JLmini.MVVM;
using JLmini.View;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace JLmini.ViewModel
{
    class QuestionViewModel : ViewModelBase
    {
        private Question selectedQuestion;
        public ObservableCollection<Question> Questions { get; set; }
        private CommandBase addQuestion;

        public Question SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                selectedQuestion = value;
                OnPropertyChanged("SelectedQuestion");
            }
        }

        private UserControl aktuelleView;
        public UserControl AktuelleView
        {
            get { return aktuelleView; }
            set { aktuelleView = value; OnPropertyChanged(nameof(AktuelleView)); }
        }
        public CommandBase AddQuestion
        {
            get
            {
                return addQuestion ??
                 (addQuestion = new CommandBase(obj =>
                 {
                     Question question = new Question();
                     Questions.Insert(0, question);
                     SelectedQuestion = question;
                 }));
            }
        }

        public QuestionViewModel()
        {
            AktuelleView = new QuestionView();

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

