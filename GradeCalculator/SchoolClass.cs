using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeCalculator
{
    public class SchoolClass
    {
        public string Name { get; set; }
        public List<GradeCategory> categories { get; set; }
        public List<Assignment> Assignments { get; set; }

        public double CalculateFinalGrade()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<Assignment>> GetAssignmentsByCategory()
        {
            var result = new Dictionary<string, List<Assignment>>();
            foreach(GradeCategory category in this.categories)
            {
                List<Assignment> relevantAssignments = this.Assignments.Where(x => x.category.Name.Equals(category.Name)).ToList();
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
