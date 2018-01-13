using GradeCalculator.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace GradeCalculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string FILE_NAME = "C:\\temp\\GradeCalculatorData.xml";

        public static List<SchoolClass> ReadFromXml()
        {
            List<SchoolClass> classes = new List<SchoolClass>();
            if(File.Exists(FILE_NAME))
            {
                XDocument xDoc = XDocument.Load(FILE_NAME);
                List<XElement> allClasses = xDoc.Descendants().Where(x => x.Name.LocalName.Equals("ClassCategories")).ToList();
                allClasses = allClasses.Concat(xDoc.Descendants().Where(x => x.Name.LocalName.Equals("ClassPoints"))).ToList();
                foreach(var element in allClasses)
                {
                    bool isClassWithCategories = element.Name.LocalName.Equals("ClassCategories");
                    SchoolClass c = null;
                    if (isClassWithCategories)
                        c = new SchoolClassCategories();
                    else
                        c = new SchoolClassPoints();

                    c.Name = element.Attribute("Name").Value;
                    c.Assignments = new ObservableCollection<Assignment>();

                    if(isClassWithCategories)
                    {
                        SchoolClassCategories classCategories = (SchoolClassCategories)c;
                        classCategories.Categories = new ObservableCollection<GradeCategory>();
                        List<XElement> allCategoryElements = element.Descendants().Where(x => x.Name.LocalName.Equals("Category")).ToList();
                        foreach (var categoryElement in allCategoryElements)
                        {
                            GradeCategory gradeCategory = new GradeCategory();
                            gradeCategory.Name = categoryElement.Attribute("Name").Value;

                            double worth;
                            double.TryParse(categoryElement.Attribute("CategoryWorth").Value, out worth);

                            gradeCategory.CategoryWeight = worth;

                            classCategories.Categories.Add(gradeCategory);
                        }
                    }

                    List<XElement> allAssignmentElements = element.Descendants().Where(x => x.Name.LocalName.Equals("Assignment")).ToList();
                    foreach(var assignmentElement in allAssignmentElements)
                    {
                        Assignment assignment = new Assignment();
                        assignment.Name = assignmentElement.Attribute("Name").Value;

                        if(isClassWithCategories)
                        {
                            SchoolClassCategories classCategories = (SchoolClassCategories)c;
                            string categoryName = assignmentElement.Attribute("CategoryName").Value;
                            GradeCategory category = classCategories.Categories.Single(x => x.Name.Equals(categoryName));
                            assignment.Category = category;
                        }

                        double totalPointsEarned;
                        double.TryParse(assignmentElement.Attribute("TotalPointsEarned").Value, out totalPointsEarned);
                        assignment.TotalPointsEarned = totalPointsEarned;

                        double totalPossiblePoints;
                        double.TryParse(assignmentElement.Attribute("TotalPossiblePoints").Value, out totalPossiblePoints);
                        assignment.TotalPossiblePoints = totalPossiblePoints;

                        c.Assignments.Add(assignment);
                    }

                    classes.Add(c);
                }
            }
            return classes;
        }

        public static void WriteToXml(List<SchoolClass> schoolClassData)
        {
            if(!Directory.Exists("C\\temp")) { Directory.CreateDirectory("C:\\temp"); }

            if(File.Exists(FILE_NAME))
            {
                File.Delete(FILE_NAME);

                XElement xmlTree = GetXmlTreeFromData(schoolClassData);
                xmlTree.Save(FILE_NAME);
            }
            else
            {
                XElement xmlTree = GetXmlTreeFromData(schoolClassData);
                xmlTree.Save(FILE_NAME);
            }
        }

        private static XElement GetXmlTreeFromData(List<SchoolClass> schoolClassData)
        {
            var classesWithCategories = schoolClassData.Where(x => x is SchoolClassCategories).Cast<SchoolClassCategories>();
            var classesWithPoints = schoolClassData.Where(x => x is SchoolClassPoints).Cast<SchoolClassPoints>();

            var categoryElements = from c in classesWithCategories
                                   select new XElement("ClassCategories", new XAttribute("Name", c.Name),
                                   from category in c.Categories
                                   select new XElement("Category",
                                       new XAttribute("Name", category.Name),
                                       new XAttribute("CategoryWorth", category.CategoryWeight)),
                                   from assignment in c.Assignments
                                   select new XElement("Assignment",
                                                       new XAttribute("Name", assignment.Name),
                                                       new XAttribute("CategoryName", assignment.Category != null ? assignment.Category.Name : string.Empty),
                                                       new XAttribute("TotalPointsEarned", assignment.TotalPointsEarned),
                                                       new XAttribute("TotalPossiblePoints", assignment.TotalPossiblePoints)));

            var pointElements = from c in classesWithPoints
                                select new XElement("ClassPoints", new XAttribute("Name", c.Name),
                                from assignment in c.Assignments
                                select new XElement("Assignment",
                                                    new XAttribute("Name", assignment.Name),
                                                    new XAttribute("TotalPointsEarned", assignment.TotalPointsEarned),
                                                    new XAttribute("TotalPossiblePoints", assignment.TotalPossiblePoints)));

            var allElements = categoryElements.Concat(pointElements);

            return new XElement("Root", allElements.Select(x => x));
        }
    }
}
