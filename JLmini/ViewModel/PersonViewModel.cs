using JLmini.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace JLmini.ViewModel
{
    class PersonViewModel : INotifyPropertyChanged
    {
        private Person selectedPerson;

        public ObservableCollection<Person> People { get; set; }
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        public PersonViewModel()
        {
            People = new ObservableCollection<Person>
            {
                new Person{FirstName="Пётр", LastName="Петров"},
                new Person{FirstName="Степан", LastName="Степанов"},
                new Person{FirstName="Иван", LastName="Иванов"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
