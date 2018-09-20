using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeibullSolver_WPF.HelperClasses;
using WeibullSolver_WPF.Model;
using WeibullSolver_WPF.UserControls;
using WeibullSolverLibrary;
using WeibullSolverLibrary.Common_Code;
using static WeibullSolver_WPF.Model.Decisions;

namespace WeibullSolver_WPF.ViewModels
{
    public class OverviewVM : BaseHandler
    {
        #region privateFields
        ObservableCollection<Assets_Information> collAssets_Informatoin;
        ObservableCollection<Failuremode> collModes;
        ObservableCollection<Primary_Tasks> collPrimary_Task;
        ObservableCollection<HasFans> hasFansRecord;
        ObservableCollection<RequiresLube> requiresLubeRecord;
        ObservableCollection<Statutory> statutoryRecord;
        ObservableCollection<PeopleExplosure> peopleExplosureRecord;
        bool isInfoPopup;
        Failuremode selectedMode;
        #endregion

        #region Properties
        public ObservableCollection<Assets_Information> CollAssets_Informatoin
        {
            get
            {
                return collAssets_Informatoin;
            }

            set
            {
                collAssets_Informatoin = value;
                NotifyPropertyChanged("CollAssets_Informatoin");
            }
        }

        public ObservableCollection<Failuremode> CollModes
        {
            get
            {
                return collModes;
            }

            set
            {
                collModes = value;
                NotifyPropertyChanged("CollModes");
            }
        }

        public ObservableCollection<Primary_Tasks> CollPrimary_Task
        {
            get
            {
                return collPrimary_Task;
            }

            set
            {
                collPrimary_Task = value;
                NotifyPropertyChanged("CollPrimary_Task");
            }
        }

        public ObservableCollection<HasFans> HasFansRecord
        {
            get
            {
                return hasFansRecord;
            }

            set
            {
                hasFansRecord = value;
                NotifyPropertyChanged("HasFansRecord");
            }
        }

        public ObservableCollection<RequiresLube> RequiresLubeRecord
        {
            get
            {
                return requiresLubeRecord;
            }

            set
            {
                requiresLubeRecord = value;
                NotifyPropertyChanged("RequiresLubeRecord");
            }
        }

        public ObservableCollection<Statutory> StatutoryRecord
        {
            get
            {
                return statutoryRecord;
            }

            set
            {
                statutoryRecord = value;
                NotifyPropertyChanged("StatutoryRecord");
            }
        }

        public ObservableCollection<PeopleExplosure> PeopleExplosureRecord
        {
            get
            {
                return peopleExplosureRecord;
            }

            set
            {
                peopleExplosureRecord = value;
            }
        }

        public bool IsInfoPopup
        {
            get
            {
                return isInfoPopup;
            }

            set
            {
                isInfoPopup = value;
                NotifyPropertyChanged("IsInfoPopup");
            }
        }

        public ICommand CommandModesInfo { get; set; }

        public Failuremode SelectedMode
        {
            get
            {
                return selectedMode;
            }

            set
            {
                selectedMode = value;
                NotifyPropertyChanged("SelectedMode");
            }
        }

        #endregion

        #region Constructor
        public OverviewVM()
        {
            LoadAsset_Information();
            LoadDecisions();
            LoadModes();
            LoadPrimary_Task();
            CommandModesInfo = new RelayCommand(ShowModesInfo);
        }


        #endregion

        #region Methods
        private void ShowModesInfo()
        {
            if (SelectedMode != null)
            {
                ModesInfoPopup w = new ModesInfoPopup(SelectedMode);
                w.ShowDialog();
            }
        }
        private void LoadPrimary_Task()
        {
            CollPrimary_Task = new ObservableCollection<Primary_Tasks>();
            CollPrimary_Task.Add(new Primary_Tasks { Task = "Vibration Analysis", Task_Type = "Planned", Optimised_Frequency = "Monthly" });
            CollPrimary_Task.Add(new Primary_Tasks { Task = "Replace Motor", Task_Type = "Planned", Optimised_Frequency = "Never" });
            CollPrimary_Task.Add(new Primary_Tasks { Task = "Statutory Test", Task_Type = "Inspection", Optimised_Frequency = "Yearly" });
        }
        private void LoadDecisions()
        {
            HasFansRecord = new ObservableCollection<HasFans>();
            HasFansRecord.Add(new HasFans { Has_Fans = "Questions", True_Value = "1" });
            HasFansRecord.Add(new HasFans { Has_Fans = "Actions", True_Value = "7" });
            RequiresLubeRecord = new ObservableCollection<RequiresLube>();
            RequiresLubeRecord.Add(new RequiresLube { Requires_Lube = "Questions", True_Value = "1" });
            RequiresLubeRecord.Add(new RequiresLube { Requires_Lube = "Actions", True_Value = "3" });
            StatutoryRecord = new ObservableCollection<Statutory>();
            StatutoryRecord.Add(new Statutory { Statutory_ = "Questions", True_Value = "1" });
            StatutoryRecord.Add(new Statutory { Statutory_ = "Actions", True_Value = "3" });
            PeopleExplosureRecord = new ObservableCollection<PeopleExplosure>();
            PeopleExplosureRecord.Add(new PeopleExplosure { People_Explosure = "Questions", True_Value = "2" });
            PeopleExplosureRecord.Add(new PeopleExplosure { People_Explosure = "Actions", True_Value = "15" });
        }
        private void LoadModes()
        {
            CollModes = new ObservableCollection<Failuremode>();
            CollModes.Add(new Failuremode { Component = "DE Bearing",What="Cracked",Due_To="Misalignment",ID="1",Name="ABC",ModeDescription="Mode Description 1",Eta = 2.5,Beta=1.5,Gamma=1.5,Initialage=2,Disabled=true});
            CollModes.Add(new Failuremode { Component = "Insulation", What = "Deterioration", Due_To = "Age", ID = "2", Name = "XYZ", ModeDescription = "Mode Description 2", Eta = 2.5, Beta = 2.5, Gamma = 2.5, Initialage = 2, Disabled = false });
            CollModes.Add(new Failuremode { Component = "Insulation 1", What = "Deterioration 1", Due_To = "Age", ID = "3", Name = "PQR", ModeDescription = "Mode Description 3", Eta = 3.5, Beta = 3.5, Gamma = 3.5, Initialage = 3, Disabled = true });
        }
        private void LoadAsset_Information()
        {
            CollAssets_Informatoin = new ObservableCollection<Assets_Information>();
            CollAssets_Informatoin.Add(new Assets_Information { UniqueID = "MO12345", IsHasFans = true, IsRequiresLube = true, IsStatutory = true, CorrosiveEnvironment = "0.9", People = "0.3" });
            CollAssets_Informatoin.Add(new Assets_Information { UniqueID = "MO12345", IsHasFans = true, IsRequiresLube = true, IsStatutory = true, CorrosiveEnvironment = "0.9", People = "0.3" });
            CollAssets_Informatoin.Add(new Assets_Information { UniqueID = "MO12345", IsHasFans = true, IsRequiresLube = true, IsStatutory = true, CorrosiveEnvironment = "0.9", People = "0.3" });
            CollAssets_Informatoin.Add(new Assets_Information { UniqueID = "MO12345", IsHasFans = true, IsRequiresLube = true, IsStatutory = true, CorrosiveEnvironment = "0.9", People = "0.3" });
            CollAssets_Informatoin.Add(new Assets_Information { UniqueID = "MO12345", IsHasFans = true, IsRequiresLube = true, IsStatutory = true, CorrosiveEnvironment = "0.9", People = "0.3" });
        }
        #endregion
    }
    
}
