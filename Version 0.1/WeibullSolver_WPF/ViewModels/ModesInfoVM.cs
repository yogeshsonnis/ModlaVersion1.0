using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeibullSolver_WPF.HelperClasses;
using WeibullSolverLibrary;
using WeibullSolverLibrary.Common_Code;

namespace WeibullSolver_WPF.ViewModels
{
    public class ModesInfoVM : BaseHandler
    {
       Failuremode selectedmode;

        public Failuremode Selectedmode
        {
            get
            {
                return selectedmode;
            }

            set
            {
                selectedmode = value;
                NotifyPropertyChanged("Selectedmode");
            }
        }

        public ModesInfoVM(Failuremode selectedmode)
        {
            this.Selectedmode = selectedmode;
        }
    }
}
