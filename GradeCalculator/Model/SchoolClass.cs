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
            double pointsTotal = 0D;
            double percentagesTotal = this.Categories.Sum(x => x.CategoryWeight);
            foreach(var gradeCategory in this.Categories)
            {
                var relevantAssignments = this.Assignments.Where(x => x.Category.Name.Equals(gradeCategory.Name));
                var totalPoints = relevantAssignments.Sum(x => x.TotalPointsEarned);
                pointsTotal += totalPoints * gradeCategory.CategoryWeight;
            }
            return pointsTotal / percentagesTotal;
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

        public Tuple<double, double> CalculateTotalCategoryGrade(string categoryName)
        {
            var relevantAssignments = this.Assignments.Where(x => x.Category.Name.Equals(categoryName)).ToList();
            double totalEarnedPoints = relevantAssignments.Sum(x => x.TotalPointsEarned);
            double totalPossiblePoints = relevantAssignments.Sum(x => x.TotalPossiblePoints);

            return new Tuple<double, double>(totalEarnedPoints, totalPossiblePoints);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
