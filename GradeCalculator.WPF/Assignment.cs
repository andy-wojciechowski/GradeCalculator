using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalculator
{
    public class Assignment
    {
        public string Name { get; set; }
        public GradeCategory category { get; set; }
        public double TotalPointsEarned { get; set; }
        public double TotalPossiblePoints { get; set; }
    }
}
