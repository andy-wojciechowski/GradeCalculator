using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeCalculator.Model
{
    public class SchoolClass : INotifyPropertyChanged
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

        public ObservableCollection<GradeCategory> Categories { get; set; }
        public ObservableCollection<Assignment> Assignments { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public double CalculateFinalGrade()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<Assignment>> GetAssignmentsByCategory()
        {
            var result = new Dictionary<string, List<Assignment>>();
            foreach(GradeCategory category in this.Categories)
            {
                List<Assignment> relevantAssignments = this.Assignments.Where(x => x.Category.Name.Equals(category.Name)).ToList();
                result.Add(category.Name, relevantAssignments);
            }
            return result;
        }

        public Tuple<double, double, double> CalculateTotalCategoryGrade(string Name)
        {
            var relevantAssignments = this.Assignments.Where(x => x.Category.Name.Equals(name)).ToList();
            double totalEarnedPoints = relevantAssignments.Sum(x => x.TotalPointsEarned);
            double totalPossiblePoints = relevantAssignments.Sum(x => x.TotalPossiblePoints);

            return new Tuple<double, double, double>(totalEarnedPoints, totalPossiblePoints, totalEarnedPoints / totalPossiblePoints);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
