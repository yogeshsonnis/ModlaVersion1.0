using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeibullSolver_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for Decisions.xaml
    /// </summary>
    public partial class Decisions : UserControl
    {
        public Decisions()
        {
            InitializeComponent();
            ObservableCollection<HasFans> HasFansRecord = new ObservableCollection<HasFans>();
            {
                HasFansRecord.Add(new HasFans { Has_Fans = "Questions", True = "1" });
                HasFansRecord.Add(new HasFans { Has_Fans = "Actions", True = "7" });
            };
            ObservableCollection<RequiresLube> RequiresLubeRecord = new ObservableCollection<RequiresLube>();
            {
                RequiresLubeRecord.Add(new RequiresLube { Requires_Lube = "Questions", True = "1" });
                RequiresLubeRecord.Add(new RequiresLube { Requires_Lube = "Actions", True = "3" });
            }
            ObservableCollection<Statutory> StatutoryRecord = new ObservableCollection<Statutory>();
            {
                StatutoryRecord.Add(new Statutory { Statutory_ = "Questions", True = "1" });
                StatutoryRecord.Add(new Statutory { Statutory_ = "Actions", True = "3" });
            }
            ObservableCollection<PeopleExplosure> PeopleExplosureRecord = new ObservableCollection<PeopleExplosure>();
            {
                PeopleExplosureRecord.Add(new PeopleExplosure { People_Explosure = "Questions", Value = "2" });
                PeopleExplosureRecord.Add(new PeopleExplosure { People_Explosure = "Actions", Value = "15" });
            }
            dgDecisions.ItemsSource = HasFansRecord;
            dgDecisions2.ItemsSource = RequiresLubeRecord;
            dgDecisions3.ItemsSource = StatutoryRecord;
            dgDecisions4.ItemsSource = PeopleExplosureRecord;
        }
        public class HasFans
        {
            public string Has_Fans { get; set; }
            public string True { get; set; }
        }
        public class RequiresLube
        {
            public string Requires_Lube { get; set; }
            public string True { get; set; }
        }
        public class Statutory
        {
            public string Statutory_ { get; set; }
            public string True { get; set; }
        }
        public class PeopleExplosure
        {
            public string People_Explosure { get; set; }
            public string Value { get; set; }
        }
    }
}
