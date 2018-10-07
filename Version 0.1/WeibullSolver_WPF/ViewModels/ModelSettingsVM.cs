using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeibullSolver_WPF.ViewModels;
using WeibullSolver_WPF.HelperClasses;
using WeibullSolverLibrary;
using WeibullSolverLibrary.Common_Code;

namespace WeibullSolver_WPF.ViewModels
{
    public class ModelSettingsVM : BaseHandler
    {

        #region privateFields
        ProjectParameters settingDetails;
        #endregion
        public ProjectParameters SettingDetails
        {
            get
            {
                return settingDetails;
            }

            set
            {
                settingDetails = value;
                NotifyPropertyChanged("SettingDetails");
            }
        }
        #region Constructor
        public ModelSettingsVM()
        {
            SettingDetails = new ProjectParameters();
        }
        #endregion
    }
}
