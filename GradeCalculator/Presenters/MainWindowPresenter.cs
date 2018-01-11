﻿using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using GradeCalculator.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeCalculator.Presenters
{
    public class MainWindowPresenter : IMainWindowPresenter
    {
        private IMainWindowView View { get; set; }
        private ObservableCollection<SchoolClass> classes { get; set; }

        public void GenerateExcelReport(string directoryPath)
        {
            GradeReport report = new GradeReport(classes.ToList());
            report.GenerateReport(directoryPath);
        }

        public void ReadExistingData()
        {
            this.classes = new ObservableCollection<SchoolClass>(App.ReadFromXml());
            var window = this.View as MainWindow;
            if(window != null)
            {
                window.classGrid.ItemsSource = this.classes;
            }
        }

        public void UpdateClass(SchoolClass classToUpdate)
        {
            EditClassWindow form = new EditClassWindow(classToUpdate);
            form.Show();
        }

        public void NewClass()
        {
            SchoolClass newClass = new SchoolClass() { Name = string.Empty, Assignments = new ObservableCollection<Assignment>(), Categories = new ObservableCollection<GradeCategory>() };
            this.classes.Add(newClass);
            EditClassWindow form = new EditClassWindow(newClass);
            form.Show();
        }

        public void SetView(IMainWindowView view)
        {
            this.View = view;
        }

        public void WriteToXML()
        {
            App.WriteToXml(new List<SchoolClass>(this.classes));
        }
    }
}
