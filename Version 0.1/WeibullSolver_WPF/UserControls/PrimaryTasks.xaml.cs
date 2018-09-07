using System;
using System.Collections.Generic;
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
    /// Interaction logic for PrimaryTasks.xaml
    /// </summary>
    public partial class PrimaryTasks : UserControl
    {
        public PrimaryTasks()
        {
            InitializeComponent(); List<TicketInfo> ticketsList = new List<TicketInfo>
            {
                new TicketInfo{ Task="Vibration Analysis",Task_Type="Planned",Optimised_Frequency="Monthly"},
                new TicketInfo{ Task="Statutory Test",Task_Type="Inspection",Optimised_Frequency="Yearly"},
                 new TicketInfo{ Task="Vibration Analysis",Task_Type="Planned",Optimised_Frequency="Monthly"},
                new TicketInfo{ Task="Statutory Test",Task_Type="Inspection",Optimised_Frequency="Yearly"},

                 new TicketInfo{ Task="Vibration Analysis",Task_Type="Planned",Optimised_Frequency="Monthly"},
                new TicketInfo{ Task="Statutory Test",Task_Type="Inspection",Optimised_Frequency="Yearly"},

                 new TicketInfo{ Task="Vibration Analysis",Task_Type="Planned",Optimised_Frequency="Monthly"},
                new TicketInfo{ Task="Statutory Test",Task_Type="Inspection",Optimised_Frequency="Yearly"},


            };
            dgPrimaryTasks.ItemsSource = ticketsList;
        }
        public class TicketInfo
        {
            public string Task { get; set; }
            public string Task_Type { get; set; }
            public string Optimised_Frequency { get; set; }

        }
    }
}
