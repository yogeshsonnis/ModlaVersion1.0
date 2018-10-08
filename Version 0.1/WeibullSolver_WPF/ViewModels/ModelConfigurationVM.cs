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
    public class ModelConfigurationVM : BaseHandler
    {
        FMTask newFMTask;
        Effect newEffect;
        Failuremode newFailuremode;
        FunctionalFailure newFunctionFailure;
        ObservableCollection<FMTask> fMTasks;
        ObservableCollection<Failuremode> failureModeColl;
        ObservableCollection<FunctionalFailure> functionFailureColl;
        ObservableCollection<FMTask> plannedTasks;
        ObservableCollection<FMTask> inspectionTasks;
        ObservableCollection<Effect> effectColl;
        FMTask isSelectedCorrectiveTask;
        bool isCheckedSolve;
        bool isCheckedFunctionFailureSolve;
        bool isCheckedFailureMode;
        public FMTask NewFMTask
        {
            get { return newFMTask; }
            set { newFMTask = value; NotifyPropertyChanged("NewFMTask"); }
        }

        public RelayCommand SaveFMTaskCommand { get; set; }

        public RelayCommand SaveFailuremodeCommand { get; set; }

        public RelayCommand SaveFunctionFailure { get; set; }

        public RelayCommand CheckSolve { get; set; }

        public RelayCommand CheckFuntionFailure { get; set; }

        public RelayCommand SaveEffectCommand { get; set; }

        public ObservableCollection<FMTask> FMTasks
        {
            get
            {
                return fMTasks;
            }

            set
            {
                fMTasks = value;
                NotifyPropertyChanged("FMTasks");
            }
        }

        public Failuremode NewFailuremode
        {
            get
            {
                return newFailuremode;
            }

            set
            {
                newFailuremode = value;
                NotifyPropertyChanged("NewFailuremode");
            }
        }

        public ObservableCollection<Failuremode> FailureModeColl
        {
            get
            {
                return failureModeColl;
            }

            set
            {
                failureModeColl = value;
                NotifyPropertyChanged("Failuremode");
            }
        }

        public FunctionalFailure NewFunctionFailure
        {
            get
            {
                return newFunctionFailure;
            }

            set
            {
                newFunctionFailure = value;
                NotifyPropertyChanged("NewFunctionFailure");
            }
        }

        public ObservableCollection<FunctionalFailure> FunctionFailureColl
        {
            get
            {
                return functionFailureColl;
            }

            set
            {
                functionFailureColl = value;
                NotifyPropertyChanged("FunctionFailureColl");
            }
        }

        public FMTask IsSelectedCorrectiveTask
        {
            get
            {
                return isSelectedCorrectiveTask;
            }

            set
            {
                isSelectedCorrectiveTask = value;
                NotifyPropertyChanged("IsSelectedCorrectiveTask");
            }
        }
        public bool IsCheckedSolve
        {
            get
            {
                return isCheckedSolve;
            }

            set
            {
                isCheckedSolve = value;
                NotifyPropertyChanged("IsCheckedSolve");
            }
        }

        public ObservableCollection<FMTask> PlannedTasks
        {
            get
            {
                return plannedTasks;
            }

            set
            {
                plannedTasks = value;
                NotifyPropertyChanged("PlannedTasks");
            }
        }
        public ObservableCollection<FMTask> InspectionTasks
        {
            get
            {
                return inspectionTasks;
            }

            set
            {
                inspectionTasks = value;
                NotifyPropertyChanged("InspectionTasks");
            }
        }

        public bool IsCheckedFailureMode
        {
            get
            {
                return isCheckedFailureMode;
            }

            set
            {
                isCheckedFailureMode = value;
                NotifyPropertyChanged("IsCheckedFailureMode");
                if(IsCheckedFailureMode==true)
                {
                    PlannedTasks = FMTasks;
                    InspectionTasks = FMTasks;
                }
            }
        }

        public ObservableCollection<Effect> EffectColl
        {
            get
            {
                return effectColl;
            }

            set
            {
                effectColl = value;
                NotifyPropertyChanged("EffectColl");
            }
        }

        public Effect NewEffect
        {
            get
            {
                return newEffect;
            }

            set
            {
                newEffect = value;
                NotifyPropertyChanged("NewEffect");
            }
        }

        public bool IsCheckedFunctionFailureSolve
        {
            get
            {
                return isCheckedFunctionFailureSolve;
            }

            set
            {
                isCheckedFunctionFailureSolve = value;
                NotifyPropertyChanged("IsCheckedFunctionFailureSolve");
            }
        }

        public ModelConfigurationVM()
        {
            NewFMTask = new FMTask();
            NewEffect = new Effect();
            NewFailuremode = new Failuremode();
            NewFunctionFailure = new FunctionalFailure();
            FMTasks = new ObservableCollection<FMTask>();
            EffectColl = new ObservableCollection<Effect>();
            FailureModeColl = new ObservableCollection<Failuremode>();
            SaveFMTaskCommand = new RelayCommand(OnSaveFMTask);
            SaveEffectCommand = new RelayCommand(OnSaveEffect);
            SaveFailuremodeCommand = new RelayCommand(OnSaveFailuremode);
            SaveFunctionFailure = new RelayCommand(OnSaveFunctionFailure);
            CheckSolve = new RelayCommand(OnCheckSolve);
            CheckFuntionFailure = new RelayCommand(OnFuntionFailure);
        }
        
        #region FMTAsk
        private void OnSaveFMTask()
        {
            var v = NewFMTask;
            FMTasks.Add(NewFMTask);
            MessageBox.Show("New FM Task is created successfully");
            NewFMTask = new FMTask();
        }
        #endregion

        #region Effect
        private void OnSaveEffect()
        {
            var e = NewEffect;
            EffectColl.Add(NewEffect);
            MessageBox.Show("Effect created successfully");
            NewEffect = new Effect();
        }
        #endregion

        #region FailureMode
        private void OnSaveFailuremode()
        {
            //NewFailuremode.ProjectParams = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };
            //NewFailuremode.PlannedTasks = FMTasks.ToList();
            //NewFailuremode.InspectionTasks = FMTasks.ToList();
            //NewFailuremode.CorrectiveTask = FMTasks.FirstOrDefault();
            //NewFailuremode = new Failuremode() { Name = "Test", ID = "FM001", Eta = 70762, Beta = 3.92, Gamma = 14227, Initialage = 0 };
            //ProjectParameters PRJ1 = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };
            //NewFailuremode.ProjectParams = PRJ1;
            //NewFailuremode.CorrectiveTask = new FMTask() { Description = "CR1", TaskCost = 1819, TaskDuration = 0, Agereductionfactor = 1 };
            //NewFailuremode.PlannedTasks.Add(new FMTask() { Description = "PR1", FixedInterval = true, TaskInterval = 8760, TaskCost = 2385, TaskDuration = 13, Secondary = false, Agereductionfactor = 1 });
            //NewFailuremode.PlannedTasks.Add(new FMTask() { Description = "PR2", TaskInterval = 10000, TaskCost = 110, TaskDuration = 13, Secondary = true, Agereductionfactor = 1 });
            //NewFailuremode.InspectionTasks.Add(new FMTask() { TaskCost = 4430, TaskDuration = 0, TaskInterval = 448, PFInterval = 3130, DetectionProbability = 1 });
            //NewFailuremode.Effects.Add(new Effect() { Name = "Environmental Risk", EffectCost = 7738, EffectProbability = .2, EffectType = "Environmental", ApplyToCorrective = true });
            //NewFailuremode.Solve();
            var v = NewFailuremode;
            FailureModeColl.Add(NewFailuremode);
            MessageBox.Show("Failuremode is created successfully");
            NewFailuremode = new Failuremode();
        }

        private void OnCheckSolve()
        {
            if (IsCheckedSolve == true)
            {
               // List<Effect> tempList = new List<Effect>();
                ProjectParameters PRJ1 = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };
                //NewFailuremode = new Failuremode() { Name = "Test", ID = "FM001", Eta = 8760, Beta = 5, Gamma = 0, Initialage = 0 };
                //NewFailuremode.CorrectiveTask = new FMTask() { Description = "CR1", TaskCost = 10000, TaskDuration = 24, Agereductionfactor = 1 };
                //NewFailuremode.PlannedTasks.Add(new FMTask() { Description = "PR1", FixedInterval = true, TaskInterval = 8760, TaskCost = 5000, TaskDuration = 10, Secondary = false, Agereductionfactor = 1 });
                //NewFailuremode.PlannedTasks.Add(new FMTask() { Description = "PR2", TaskInterval = 10000, TaskCost = 100, TaskDuration = 1, Secondary = true, Agereductionfactor = 1 });
                //NewFailuremode.InspectionTasks.Add(new FMTask() { TaskCost = 10, TaskDuration = 1, TaskInterval = 738, PFInterval = 438, DetectionProbability = .3 });
                //NewFailuremode.Effects.Add(new Effect() { Name = "Environmental Risk", EffectCost = 2000, EffectProbability = .11, EffectType = "Environmental", ApplyToCorrective = true });
                NewFailuremode.ProjectParams = PRJ1;
                NewFailuremode.CorrectiveTask = IsSelectedCorrectiveTask;
                NewFailuremode.PlannedTasks = PlannedTasks.Where(x => x.IsCheckedPlannedTasks == true).ToList();
                NewFailuremode.InspectionTasks = InspectionTasks.Where(x => x.IsCheckedInspectionTasks == true).ToList();
               // NewFailuremode.Effects = EffectColl.ToList();
               NewFailuremode.Effects = EffectColl.Where(x => x.IsCheckedEffect == true).ToList();
                NewFailuremode.Solve();

            }
        }

        #endregion

        #region FunctionFailure
        private void OnSaveFunctionFailure()
        {
            NewFunctionFailure.Failuremodes = new Dictionary<string, Failuremode>();
            int i = 1;
            foreach(var mode in FailureModeColl)
            {
                NewFunctionFailure.Failuremodes.Add(String.Concat("Fun", i), mode);
                i++;
            }
            MessageBox.Show("Function Failure is created successfully");
        }

        private void OnFuntionFailure()
        {
            if (IsCheckedFunctionFailureSolve == true)
            {
                NewFunctionFailure.Failuremodes = new Dictionary<string, Failuremode>();
                int i = 1;
                foreach (var mode in FailureModeColl)
                {
                    NewFunctionFailure.Failuremodes.Add(String.Concat("Fun",i), mode);
                    i++;
                }
                NewFunctionFailure.Solve();
            }
        }
        #endregion

    }
}
