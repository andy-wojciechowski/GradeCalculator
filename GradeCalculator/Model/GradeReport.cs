using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace GradeCalculator.Model
{
    public class GradeReport
    {
        private List<SchoolClass> classes { get; set; }

        public GradeReport(List<SchoolClass> classes)
        {
            this.classes = classes;
        }

        public void GenerateReport(string filePath)
        {
            try
            {
                Application excelApp = new Application();
                Workbook excelWorkbook = null;
                Worksheet excelWorksheet = null;

                excelApp.Visible = true;
                excelWorkbook = excelApp.Workbooks.Add();
                excelWorksheet = excelWorkbook.Worksheets[1];

                int rowIndex = 1;
                int cellIndex = 1;

                foreach(var c in this.classes)
                {
                    excelWorksheet.Cells[rowIndex, cellIndex] = string.Format("Class: {0}", c.Name);
                    rowIndex += 1;
                    var assignments = c.GetAssignmentsByCategory();
                    foreach(var kvp in assignments)
                    {
                        double worth = c.Categories.Single(x => x.Name.Equals(kvp.Key)).CategoryWeight;
                        excelWorksheet.Cells[rowIndex, cellIndex] = string.Format("Grade Category: {0}", kvp.Key);
                        rowIndex += 1;
                        excelWorksheet.Cells[rowIndex, cellIndex] = string.Format("Category Weight: {0}", string.Format("{0:P2}", worth));
                        rowIndex += 1;
                        excelWorksheet.Cells[rowIndex, cellIndex] = "Assignment Breakdown";
                        rowIndex += 1;
                        foreach(var assignment in kvp.Value)
                        {
                            excelWorksheet.Cells[rowIndex, cellIndex] = assignment.Name;
                            excelWorksheet.Cells[rowIndex, cellIndex + 1] = string.Format("{0}/{1}", assignment.TotalPointsEarned, assignment.TotalPossiblePoints);
                            rowIndex += 1;
                        }
                        excelWorksheet.Cells[rowIndex, cellIndex] = "Total Category Grade";
                        var totalCategoryGrade = c.CalculateTotalCategoryGrade(kvp.Key);
                        excelWorksheet.Cells[rowIndex, cellIndex + 1] = string.Format("{0}/{1} {2:P2}", totalCategoryGrade.Item1, totalCategoryGrade.Item2, totalCategoryGrade.Item3);
                        rowIndex += 1;
                    }
                    excelWorksheet.Cells[rowIndex, cellIndex] = "Final Class Grade";
                    excelWorksheet.Cells[rowIndex, cellIndex + 1] = string.Format("{0:P2}", c.CalculateFinalGrade());
                }

                string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
                excelWorkbook.SaveAs(string.Format("{0}\\Grades as of {1}.xlsx", filePath, currentDate));
                excelWorkbook.Close();
                excelApp.Quit();

                Marshal.ReleaseComObject(excelWorksheet);
                Marshal.ReleaseComObject(excelWorkbook);
                Marshal.ReleaseComObject(excelApp);
            }
            catch(Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("An unexpected error has occured in Grade Calculator.");
                sb.AppendLine();
                sb.Append(ex.ToString());
                System.Windows.MessageBox.Show(sb.ToString(), "Grade Calculator", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
