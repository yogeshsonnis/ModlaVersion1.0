using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeibullSolver_WPF.HelperClasses;
using WeibullSolver_WPF.Model;
using static WeibullSolver_WPF.Model.Decisions;

namespace WeibullSolver_WPF.ViewModels
{
    public class OverviewVM : BaseHandler
    {
        #region privateFields
        ObservableCollection<Assets_Information> collAssets_Informatoin;
        ObservableCollection<Modes> collModes;
        ObservableCollection<Primary_Tasks> collPrimary_Task;
        ObservableCollection<HasFans> hasFansRecord;
        ObservableCollection<RequiresLube> requiresLubeRecord;
        ObservableCollection<Statutory> statutoryRecord;
        ObservableCollection<PeopleExplosure> peopleExplosureRecord;
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

        public ObservableCollection<Modes> CollModes
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
        #endregion

        #region Constructor
        public OverviewVM()
        {
            LoadAsset_Information();
            LoadDecisions();
            LoadModes();
            LoadPrimary_Task();
        }
        #endregion

        #region Methods
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
            CollModes = new ObservableCollection<Modes>();
            CollModes.Add(new Modes {Component = "DE Bearing",What="Cracked",Due_To="Misalignment" });
            CollModes.Add(new Modes { Component = "Insulation", What = "Deterioration", Due_To = "Age" });
            CollModes.Add(new Modes { Component = "Insulation", What = "Deterioration", Due_To = "Age" });
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
