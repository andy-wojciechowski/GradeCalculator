using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeCalculator.Model
{
    public class GradeCategory : INotifyPropertyChanged
    {
        private string name;
        private double categoryWeight;

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

        public double CategoryWeight
        {
            get
            {
                return categoryWeight;
            }
            set
            {
                this.categoryWeight = value;
                OnPropertyChanged("CategoryWeight");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
