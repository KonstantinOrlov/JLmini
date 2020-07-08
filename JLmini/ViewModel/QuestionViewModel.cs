using JLmini.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JLmini.ViewModel
{
    class QuestionViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Question> Questions { get; set; }
        public QuestionViewModel()
        {
            Questions = new ObservableCollection<Question>
            {
                new Question{QuestionText="Основные понятия", Section = "БД", Stage ="Первая", Points=2, Time=20},
                new Question{QuestionText="Протокол HTTP", Section = "Web", Stage ="Первая", Points=1, Time=10},
                new Question{QuestionText="Командная оболочка CMD(Windows)", Section = "Другие знания", Stage ="Третья", Points=1, Time=5},
                new Question{QuestionText=".Net Core", Section = ".Net", Stage ="Третья", Points=3, Time=20}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

