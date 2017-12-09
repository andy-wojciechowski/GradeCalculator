using System.Windows;

namespace GradeCalculator.Presenters
{
    public class BasePresenter<TWindow> where TWindow : Window
    {
        private TWindow view;
        public TWindow View
        {
            get
            {
                return view;
            }
        }

        public BasePresenter(TWindow View)
        {
            this.view = View;
        }
    }
}
