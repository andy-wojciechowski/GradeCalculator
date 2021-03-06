﻿using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IEditClassPointsPresenter
    {
        void SetView(IEditClassPointsView view);
        void SetClass(SchoolClass model);
        void UpdateAssignment();
        void AddAssignment();
        void SetDataBindings();
    }
}
