using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeibullSolver_WPF.HelperClasses;
using WeibullSolverLibrary.Common_Code;

namespace WeibullSolver_WPF.ViewModels
{
    public class HomeVM : BaseHandler
    {
        #region privateFields
        RelayCommand addSettingCommand;
        RelayCommand addNewModelCommand;
        RelayCommand saveModelCommand;
        RelayCommand loadModelCommand;
        ProjectParameters settingDetails;
        ObservableCollection<ProjectParameters> collModelSettings;
        #endregion

        #region Properties
        public RelayCommand AddSettingCommand
        {
            get
            {
                return addSettingCommand;
            }

            set
            {
                addSettingCommand = value;
                NotifyPropertyChanged("AddSettingCommand");
            }
        }

        public RelayCommand AddNewModelCommand
        {
            get
            {
                return addNewModelCommand;
            }

            set
            {
                addNewModelCommand = value;
                NotifyPropertyChanged("AddNewModelCommand");
            }
        }

        public RelayCommand SaveModelCommand
        {
            get
            {
                return saveModelCommand;
            }

            set
            {
                saveModelCommand = value;
                NotifyPropertyChanged("SaveModelCommand");
            }
        }

        public RelayCommand LoadModelCommand
        {
            get
            {
                return loadModelCommand;
            }

            set
            {
                loadModelCommand = value;
                NotifyPropertyChanged("LoadModelCommand");
            }
        }

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

        public ObservableCollection<ProjectParameters> CollModelSettings
        {
            get
            {
                return collModelSettings;
            }

            set
            {
                collModelSettings = value;
                NotifyPropertyChanged("CollModelSettings");
            }
        }


        #endregion

        #region Constructor
        public HomeVM()
        {
            AddSettingCommand = new RelayCommand(OnAddSetting);
            AddNewModelCommand = new RelayCommand(OnAddNewModel);
            SaveModelCommand = new RelayCommand(OnSaveModel);
            LoadModelCommand = new RelayCommand(OnLoadModel);
            SettingDetails = new ProjectParameters();
        }

        private void OnAddSetting()
        {
            //CollModelSettings = new ObservableCollection<ProjectParameters>();
            if (SettingDetails.ProjectName != null)
            {
                CollModelSettings.Add(new ProjectParameters { ProjectName = SettingDetails.ProjectName, Projectinterval = SettingDetails.Projectinterval, Projectlife = SettingDetails.Projectlife });
                SettingDetails = new ProjectParameters();
            }
            else
            {
                MessageBox.Show("Please enter project name");
            }
        }
        private void OnLoadModel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

            }

        }

        private void OnSaveModel()
        {

        }

        private void OnAddNewModel()
        {
            //Model model = new Model();            ProjectParameters projectparameter = new ProjectParameters(); //Intialize
            CollModelSettings = new ObservableCollection<ProjectParameters>();
            CollModelSettings.Add(new ProjectParameters { ProjectName = "Project Life", Projectlife = 0 });            CollModelSettings.Add(new ProjectParameters { ProjectName = "Projects Interval", Projectinterval = 0 });            CollModelSettings.Add(new ProjectParameters { ProjectName = "Apply InspectionAt Time Zero", ApplyInspectionAtTimeZero = false });
        }
        #endregion
    }
}
