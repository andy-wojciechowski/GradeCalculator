using GradeCalculator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace GradeCalculator.Tests.Model
{
    [TestClass]
    public class SchoolClassCategoriesTests
    {
        [TestMethod]
        public void Test_CalculateFinalGrade()
        {
            //ARRANGE
            var schoolClassCategories = new SchoolClassCategories();
            schoolClassCategories.Categories = new ObservableCollection<GradeCategory>();

            schoolClassCategories.Categories.Add(new GradeCategory()
            {
                Name = "Category1",
                CategoryWeight = 0.2
            });

            schoolClassCategories.Categories.Add(new GradeCategory()
            {
                Name = "Category2",
                CategoryWeight = 0.3
            });

            schoolClassCategories.Categories.Add(new GradeCategory()
            {
                Name = "Category3",
                CategoryWeight = 0.5
            });

            schoolClassCategories.Assignments = new ObservableCollection<Assignment>();

            //Category 1 1 Assignment Full Credit
            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category1Assignment",
                Category = schoolClassCategories.Categories[0],
                TotalPossiblePoints = 10,
                TotalPointsEarned = 10
            });

            //Category 2 2 Assignments Full Credit
            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category2Assignment1",
                Category = schoolClassCategories.Categories[1],
                TotalPossiblePoints = 10,
                TotalPointsEarned = 10
            });
            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category2Assignment2",
                Category = schoolClassCategories.Categories[1],
                TotalPossiblePoints = 5,
                TotalPointsEarned = 5
            });

            //Category 2 3 Assignments Partial Credit
            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category3Assignment1",
                Category = schoolClassCategories.Categories[2],
                TotalPossiblePoints = 10,
                TotalPointsEarned = 7
            });
            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category3Assignment2",
                Category = schoolClassCategories.Categories[2],
                TotalPossiblePoints = 5,
                TotalPointsEarned = 5
            });

            //ACT
            var finalGrade = schoolClassCategories.CalculateFinalGrade();

            //ASSERT
            Assert.AreEqual(90, finalGrade);
        }

        [TestMethod]
        public void Test_GetAssignmentsByCategory()
        {
            //ARRANGE
            var schoolClassCategories = new SchoolClassCategories();
            schoolClassCategories.Categories = new ObservableCollection<GradeCategory>();

            schoolClassCategories.Categories.Add(new GradeCategory()
            {
                Name = "Category1",
                CategoryWeight = 0.2
            });

            schoolClassCategories.Categories.Add(new GradeCategory()
            {
                Name = "Category2",
                CategoryWeight = 0.3
            });

            schoolClassCategories.Categories.Add(new GradeCategory()
            {
                Name = "Category3",
                CategoryWeight = 0.5
            });

            schoolClassCategories.Assignments = new ObservableCollection<Assignment>();

            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category1Assignment",
                Category = schoolClassCategories.Categories[0],
                TotalPossiblePoints = 10,
                TotalPointsEarned = 10
            });

            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category2Assignment1",
                Category = schoolClassCategories.Categories[1],
                TotalPossiblePoints = 10,
                TotalPointsEarned = 10
            });
            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category2Assignment2",
                Category = schoolClassCategories.Categories[1],
                TotalPossiblePoints = 5,
                TotalPointsEarned = 5
            });

            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category3Assignment1",
                Category = schoolClassCategories.Categories[2],
                TotalPossiblePoints = 10,
                TotalPointsEarned = 7
            });
            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category3Assignment2",
                Category = schoolClassCategories.Categories[2],
                TotalPossiblePoints = 5,
                TotalPointsEarned = 5
            });

            //ACT
            var assignments = schoolClassCategories.GetAssignmentsByCategory();

            //ASSERT
            var category1Assignments = assignments["Category1"];
            Assert.AreEqual(1, category1Assignments.Count);
            Assert.AreEqual("Category1Assignment", category1Assignments[0].Name);

            var category2Assignments = assignments["Category2"];
            Assert.AreEqual(2, category2Assignments.Count);
            Assert.AreEqual("Category2Assignment1", category2Assignments[0].Name);
            Assert.AreEqual("Category2Assignment2", category2Assignments[1].Name);

            var category3Assignments = assignments["Category3"];
            Assert.AreEqual(2, category3Assignments.Count);
            Assert.AreEqual("Category3Assignment1", category3Assignments[0].Name);
            Assert.AreEqual("Category3Assignment2", category3Assignments[1].Name);
        }

        [TestMethod]
        public void Test_CalculateTotalCategoryGrade()
        {
            //ARRANGE
            var schoolClassCategories = new SchoolClassCategories();
            schoolClassCategories.Categories = new ObservableCollection<GradeCategory>();

            schoolClassCategories.Categories.Add(new GradeCategory()
            {
                Name = "Category1",
                CategoryWeight = 0.2
            });

            schoolClassCategories.Categories.Add(new GradeCategory()
            {
                Name = "Category2",
                CategoryWeight = 0.3
            });

            schoolClassCategories.Categories.Add(new GradeCategory()
            {
                Name = "Category3",
                CategoryWeight = 0.5
            });

            schoolClassCategories.Assignments = new ObservableCollection<Assignment>();

            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category1Assignment",
                Category = schoolClassCategories.Categories[0],
                TotalPossiblePoints = 10,
                TotalPointsEarned = 10
            });

            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category2Assignment1",
                Category = schoolClassCategories.Categories[1],
                TotalPossiblePoints = 10,
                TotalPointsEarned = 10
            });
            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category2Assignment2",
                Category = schoolClassCategories.Categories[1],
                TotalPossiblePoints = 5,
                TotalPointsEarned = 5
            });

            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category3Assignment1",
                Category = schoolClassCategories.Categories[2],
                TotalPossiblePoints = 10,
                TotalPointsEarned = 7
            });
            schoolClassCategories.Assignments.Add(new Assignment()
            {
                Name = "Category3Assignment2",
                Category = schoolClassCategories.Categories[2],
                TotalPossiblePoints = 5,
                TotalPointsEarned = 5
            });

            //ACT
            var result0 = schoolClassCategories.CalculateTotalCategoryGrade("Category1");
            var result1 = schoolClassCategories.CalculateTotalCategoryGrade("Category2");
            var result2 = schoolClassCategories.CalculateTotalCategoryGrade("Category3");

            Assert.AreEqual(10, result0.Item1);
            Assert.AreEqual(10, result0.Item2);
            Assert.AreEqual(15, result1.Item1);
            Assert.AreEqual(15, result1.Item2);
            Assert.AreEqual(12, result2.Item1);
            Assert.AreEqual(15, result2.Item2);
        }
    }
}
