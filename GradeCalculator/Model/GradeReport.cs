﻿using System;
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
                    rowIndex += 2;
                    if(c is SchoolClassCategories)
                    {
                        var classCategories = (SchoolClassCategories)c;
                        var assignments = classCategories.GetAssignmentsByCategory();
                        foreach (var kvp in assignments)
                        {
                            double worth = classCategories.Categories.Single(x => x.Name.Equals(kvp.Key)).CategoryWeight;
                            excelWorksheet.Cells[rowIndex, cellIndex] = string.Format("Grade Category: {0}", kvp.Key);
                            rowIndex += 1;
                            excelWorksheet.Cells[rowIndex, cellIndex] = string.Format("Category Weight: {0}", string.Format("{0:P2}", worth));
                            rowIndex += 2;
                            SetAssignmentBreakdown(excelWorksheet, kvp.Value, rowIndex, cellIndex);
                            rowIndex += 3;
                            excelWorksheet.Cells[rowIndex, cellIndex] = "Total Category Grade";
                            var totalCategoryGrade = classCategories.CalculateTotalCategoryGrade(kvp.Key);
                            excelWorksheet.Cells[rowIndex, cellIndex + 1] = string.Format("=\"{0}/{1}\"", totalCategoryGrade.Item1, totalCategoryGrade.Item2);
                            rowIndex += 2;
                        }
                    }
                    else
                    {
                        SetAssignmentBreakdown(excelWorksheet, new List<Assignment>(c.Assignments), rowIndex, cellIndex);
                        rowIndex += 3;
                    }
                    excelWorksheet.Cells[rowIndex, cellIndex] = "Final Class Grade";
                    excelWorksheet.Cells[rowIndex, cellIndex + 1] = string.Format("{0}", c.CalculateFinalGrade());
                    rowIndex += 2;
                }

                excelWorksheet.Columns["A:B"].AutoFit();

                excelWorkbook.SaveAs(string.Format("{0}\\Grade Report", filePath), FileFormat:XlFileFormat.xlWorkbookDefault);

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

        private void SetAssignmentBreakdown(Worksheet excelWorksheet, List<Assignment> assignments, int rowIndex, int cellIndex)
        {
            excelWorksheet.Cells[rowIndex, cellIndex] = "Assignment Breakdown";
            rowIndex += 1;
            foreach (var assignment in assignments)
            {
                excelWorksheet.Cells[rowIndex, cellIndex] = string.Format("=\"{0}\"", assignment.Name);
                excelWorksheet.Cells[rowIndex, cellIndex + 1] = string.Format("=\"{0}/{1}\"", assignment.TotalPointsEarned, assignment.TotalPossiblePoints);
                rowIndex += 1;
            }
        }
    }
}
