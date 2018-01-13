using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeCalculator.Model
{
    public class SchoolClassCategories : SchoolClass
    {
        public ObservableCollection<GradeCategory> Categories { get; set; }

        public override double CalculateFinalGrade()
        {
            double pointsTotal = 0D;
            foreach (var gradeCategory in this.Categories)
            {
                //First gather the relevant assignments for this category
                var relevantAssignments = this.Assignments.Where(x => x.Category.Name.Equals(gradeCategory.Name));
                //Sum the total points earned in the category
                double totalPointsEarnedInCategory = relevantAssignments.Sum(x => x.TotalPointsEarned);
                double totalPossiblePoints = relevantAssignments.Sum(x => x.TotalPossiblePoints);

                //Next get the category worth as a number we can work with
                double worth = gradeCategory.CategoryWeight * 100;

                double commonDenominator = (worth / totalPossiblePoints);

                pointsTotal += totalPointsEarnedInCategory * commonDenominator;
            }
            return pointsTotal;
        }

        public Dictionary<string, List<Assignment>> GetAssignmentsByCategory()
        {
            var result = new Dictionary<string, List<Assignment>>();
            foreach (GradeCategory category in this.Categories)
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
    }
}
