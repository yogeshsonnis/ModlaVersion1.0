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
    /// Interaction logic for Modes.xaml
    /// </summary>
    public partial class Modes : UserControl
    {
        public Modes()
        {
            InitializeComponent();
            List<TicketInfo> ticketsList = new List<TicketInfo>
            {
                new TicketInfo{ Component="DE Bearing",What="Cracked",Due_To="Misalignment"},
                new TicketInfo{ Component="Insulation",What="Deterioration",Due_To="Age"},
                 new TicketInfo{ Component="DE Bearing",What="Cracked",Due_To="Misalignment"},
                new TicketInfo{ Component="Insulation",What="Deterioration",Due_To="Age"},
                 new TicketInfo{ Component="DE Bearing",What="Cracked",Due_To="Misalignment"},
                new TicketInfo{ Component="Insulation",What="Deterioration",Due_To="Age"},
                new TicketInfo{ Component="Insulation",What="Deterioration",Due_To="Age"},
                new TicketInfo{ Component="Insulation",What="Deterioration",Due_To="Age"}
            };
            dgModes.ItemsSource = ticketsList;
        }
        public class TicketInfo
        {
            public string Component { get; set; }
            public string What { get; set; }
            public string Due_To { get; set; }

        }
    }
}
