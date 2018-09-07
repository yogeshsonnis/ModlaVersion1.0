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
    /// Interaction logic for AssetsInformation.xaml
    /// </summary>
    public partial class AssetsInformation : UserControl
    {
        public AssetsInformation()
        {
            InitializeComponent(); List<TicketInfo> ticketsList = new List<TicketInfo>
            {
                new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},
                new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},
                 new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},
                new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},
                 new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},
                new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},
                 new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},
                new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},
                 new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},
                new TicketInfo{ Unique_ID="MO12345", Has_Fans=true, Requires_Lube=false,Statutory=true,Corrosive_Environment=0.9,People=0.3},



            };
            dgData.ItemsSource = ticketsList;
        }
        public class TicketInfo
        {
            public string Unique_ID { get; set; }
            public bool Has_Fans { get; set; }
            public bool Requires_Lube { get; set; }
            public bool Statutory { get; set; }
            public double Corrosive_Environment { get; set; }
            public double People { get; set; }

        }
    }
}
