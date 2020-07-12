using JLmini.Model;
using JLmini.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JLmini.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;

        PersonViewModel PersonVM = new PersonViewModel();
        QuestionViewModel QuestionVM = new QuestionViewModel();

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public MainViewModel()
        {
            CurrentViewModel = PersonVM;
        }
    }
}
