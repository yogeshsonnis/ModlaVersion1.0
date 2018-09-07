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

        public ObservableCollection<ProjectParameters>CollModelSettings { get; set; }

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

        RelayCommand addSettingCommand;

        ProjectParameters settingDetails;

        public ModelSettingsVM()
        {
            AddSettingCommand = new RelayCommand(OnAddSetting);
            CollModelSettings = new ObservableCollection<ProjectParameters>();
            SettingDetails = new ProjectParameters();
        }

        private void OnAddSetting()
        {
            //CollModelSettings = new ObservableCollection<ProjectParameters>();
            if(SettingDetails.ProjectName != null)
            {
                CollModelSettings.Add(new ProjectParameters { ProjectName = SettingDetails.ProjectName, Projectinterval = SettingDetails.Projectinterval, Projectlife = SettingDetails.Projectlife });
                SettingDetails = new ProjectParameters();
            }
            else
            {
                MessageBox.Show("Please enter project name");
            }
        }
    }
}
