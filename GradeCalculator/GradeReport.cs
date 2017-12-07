using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace GradeCalculator
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
                        double worth = c.categories.Single(x => x.Name.Equals(kvp.Key)).CategoryWeight;
                        //TODO: Continue with the report
                    }
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
                System.Windows.Forms.MessageBox.Show(sb.ToString(), "Grade Calculator", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
