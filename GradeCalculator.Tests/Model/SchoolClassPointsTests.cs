using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GradeCalculator.Model;
using System.Collections.ObjectModel;

namespace GradeCalculator.Tests.Model
{
    [TestClass]
    public class SchoolClassPointsTests
    {
        [TestMethod]
        public void Test_CalculateFinalGrade()
        {
            //ARRANGE
            var schoolClassPoints = new SchoolClassPoints();

            schoolClassPoints.Assignments = new ObservableCollection<Assignment>();

            schoolClassPoints.Assignments.Add(new Assignment()
            {
                Name = "Assignment0",
                TotalPointsEarned = 10,
                TotalPossiblePoints = 10
            });
            schoolClassPoints.Assignments.Add(new Assignment()
            {
                Name = "Assignment1",
                TotalPossiblePoints = 10,
                TotalPointsEarned = 7
            });

            //ACT
            var result = schoolClassPoints.CalculateFinalGrade();

            //ASSERT
            Assert.AreEqual(85, result);
        }
    }
}
