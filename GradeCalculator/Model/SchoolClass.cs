using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeCalculator.Model
{
    public class SchoolClass
    {
        public string Name { get; set; }
        public List<GradeCategory> Categories { get; set; }
        public List<Assignment> Assignments { get; set; }

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

        public double CalculateTotalCategoryGrade(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
