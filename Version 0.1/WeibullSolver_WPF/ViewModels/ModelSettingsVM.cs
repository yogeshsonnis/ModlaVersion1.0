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
using WeibullSolverLibrary.Common_Code;
using WeibullSolver_WPF.ViewModels;

namespace WeibullSolver_WPF.ViewModels
{
    public class ModelSettingsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #region privateFields

        RelayCommand addSettingCommand;
        RelayCommand addNewModelCommand;
        RelayCommand saveModelCommand;
        RelayCommand loadModelCommand;

        ProjectParameters settingDetails;
        ObservableCollection<ProjectParameters> CollModelSettings;
        #endregion

        #region Properties
        // public ObservableCollection<ProjectParameters> CollModelSettings { get; set; }
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;

            public event EventHandler CanExecuteChanged;

            public RelayCommand(Action execute)
                : this(execute, null)
            {
            }

            public RelayCommand(Action execute, Func<bool> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");
                _execute = execute;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null ? true : _canExecute();
            }

            public void Execute(object parameter)
            {
                _execute();
            }

            public void RaiseCanExecuteChanged()
            {
                var handler = CanExecuteChanged;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
        public RelayCommand AddSettingCommand
        {
            get
            {
                return addSettingCommand;
            }

            set
            {
                addSettingCommand = value;
                RaisePropertyChanged("AddSettingCommand");
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
                RaisePropertyChanged("SettingDetails");
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
                RaisePropertyChanged("AddNewModelCommand");
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
                RaisePropertyChanged("SaveModelCommand");
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
                RaisePropertyChanged("LoadModelCommand");
            }
        }

        public ObservableCollection<ProjectParameters> CollModelSettings1
        {
            get
            {
                return CollModelSettings;
            }

            set
            {
                CollModelSettings = value;
                RaisePropertyChanged("CollModelSettings1");
            }
        }

        #endregion

        #region Constructor
        public ModelSettingsVM()
        {
            AddSettingCommand = new RelayCommand(OnAddSetting);
            AddNewModelCommand = new RelayCommand(OnAddNewModel);
            SaveModelCommand = new RelayCommand(OnSaveModel);
            LoadModelCommand = new RelayCommand(OnLoadModel);
            CollModelSettings1 = new ObservableCollection<ProjectParameters>();
            SettingDetails = new ProjectParameters();
        }
        #endregion

        #region Methods
        private void OnAddSetting()
        {
            //CollModelSettings = new ObservableCollection<ProjectParameters>();
            if (SettingDetails.ProjectName != null)
            {
                CollModelSettings1.Add(new ProjectParameters { ProjectName = SettingDetails.ProjectName, Projectinterval = SettingDetails.Projectinterval, Projectlife = SettingDetails.Projectlife });
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
            Model model = new Model();            ProjectParameters projectparameter = new ProjectParameters();
            CollModelSettings1 = new ObservableCollection<ProjectParameters>();
            //  CollModelSettings1.Add(new ProjectParameters { ProjectName = "ABC", Projectinterval = 0, Projectlife = 0 });
            CollModelSettings1.Add(new ProjectParameters { ProjectName = "Project Life",Projectlife= 0 });            CollModelSettings1.Add(new ProjectParameters { ProjectName = "Projects Interval", Projectinterval = 0 });            CollModelSettings1.Add(new ProjectParameters { ProjectName = "Apply InspectionAt Time Zero", ApplyInspectionAtTimeZero = false });
                //projectparameter.ProjectName = "";
                //projectparameter.Projectlife = 0;
                //projectparameter.Projectinterval = 0;
                //projectparameter.TimeWindows = 0;
           }
        #endregion
    }
}
