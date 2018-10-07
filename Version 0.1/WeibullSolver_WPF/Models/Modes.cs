using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeibullSolver_WPF.HelperClasses;

namespace WeibullSolver_WPF.Model
{
    public class Modes : BaseHandler
    {
        string component;
        string what;
        string due_To;

        public string Component
        {
            get
            {
                return component;
            }

            set
            {
                component = value;
                NotifyPropertyChanged("Component");
            }
        }

        public string What
        {
            get
            {
                return what;
            }

            set
            {
                what = value;
                NotifyPropertyChanged("What");
            }
        }

        public string Due_To
        {
            get
            {
                return due_To;
            }

            set
            {
                due_To = value;
                NotifyPropertyChanged("Due_To");
            }
        }
    }
}
