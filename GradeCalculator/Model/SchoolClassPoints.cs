using System.Linq;

namespace GradeCalculator.Model
{
    public class SchoolClassPoints : SchoolClass
    {
        public override double CalculateFinalGrade()
        {
            var totalEarnedPoints = this.Assignments.Sum(x => x.TotalPointsEarned);
            var totalPossiblePoints = this.Assignments.Sum(x => x.TotalPossiblePoints);

            return (totalEarnedPoints / totalPossiblePoints) * 100;
        }
    }
}
