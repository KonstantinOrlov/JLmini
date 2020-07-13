using JLmini.Model;
using JLmini.MVVM;
using System.Collections.ObjectModel;

namespace JLmini.ViewModel
{
    class PersonViewModel : ViewModelBase
    {
        private Person selectedPerson;
        private CommandBase addPerson;
        private CommandBase removePerson;
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

        public CommandBase RemovePerson
        {
            get
            {
                return removePerson ??
                    (removePerson = new CommandBase(obj =>
                    {
                        Person person = obj as Person;
                        if (person != null)
                        {
                            People.Remove(person);
                        }
                    },
                    (obj) => People.Count > 0));
            }
        }
    }
}
