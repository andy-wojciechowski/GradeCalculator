using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeCalculator.Model
{
    public class Assignment : INotifyPropertyChanged
    {
        private string name;
        private GradeCategory category;
        private double totalPointsEarned;
        private double totalPossiblePoints;

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

        public GradeCategory Category
        {
            get
            {
                return category;
            }
            set
            {
                this.category = value;
                OnPropertyChanged("Category");
            }
        }

        public double TotalPointsEarned
        {
            get
            {
                return totalPointsEarned;
            }
            set
            {
                this.totalPointsEarned = value;
                OnPropertyChanged("TotalPointsEarned");
            }
        }

        public double TotalPossiblePoints
        {
            get
            {
                return totalPossiblePoints;
            }
            set
            {
                this.totalPossiblePoints = value;
                OnPropertyChanged("TotalPossiblePoints");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
