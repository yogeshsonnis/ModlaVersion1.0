using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeibullSolver_WPF.HelperClasses;

namespace WeibullSolver_WPF.Model
{
    public class Primary_Tasks : BaseHandler
    {
        string task;
        string task_Type;
        string optimised_Frequency;

        public string Task
        {
            get
            {
                return task;
            }

            set
            {
                task = value;
                NotifyPropertyChanged("Task");
            }
        }

        public string Task_Type
        {
            get
            {
                return task_Type;
            }

            set
            {
                task_Type = value;
                NotifyPropertyChanged("Task_Type");
            }
        }

        public string Optimised_Frequency
        {
            get
            {
                return optimised_Frequency;
            }

            set
            {
                optimised_Frequency = value;
                NotifyPropertyChanged("Optimised_Frequency");
            }
        }
    }
}
