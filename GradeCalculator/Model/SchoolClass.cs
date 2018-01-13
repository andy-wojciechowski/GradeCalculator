using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeCalculator.Model
{
    public abstract class SchoolClass : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<Assignment> Assignments { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract double CalculateFinalGrade();

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
