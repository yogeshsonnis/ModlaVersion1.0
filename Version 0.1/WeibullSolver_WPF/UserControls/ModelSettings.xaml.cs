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
using WeibullSolver_WPF.ViewModels;

namespace WeibullSolver_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for ModelSettings.xaml
    /// </summary>
    public partial class ModelSettings : UserControl
    {
        public ModelSettings()
        {
            InitializeComponent();
            this.DataContext = new ModelSettingsVM();

            //List<TicketInfo> ticketsList = new List<TicketInfo>
            //{
            //    new TicketInfo{ Setting="Project Life",Description="Project Life",Value="87600"},
            //    new TicketInfo{ Setting="Apply Inspection at time 0",Description="Apply Inspection at time 0",Value="TRUE"},
            //     new TicketInfo{ Setting="Project Life",Description="Project Life",Value="87600"},
            //    new TicketInfo{ Setting="Apply Inspection at time 0",Description="Apply Inspection at time 0",Value="TRUE"},
            //     new TicketInfo{ Setting="Project Life",Description="Project Life",Value="87600"},
            //    new TicketInfo{ Setting="Apply Inspection at time 0",Description="Apply Inspection at time 0",Value="TRUE"},
            //     new TicketInfo{ Setting="Project Life",Description="Project Life",Value="87600"},
            //    new TicketInfo{ Setting="Apply Inspection at time 0",Description="Apply Inspection at time 0",Value="TRUE"}
            //};
            //dgModelSettings.ItemsSource = ticketsList;
        }
        //public class TicketInfo
        //{
        //    public string Setting { get; set; }
        //    public string Description { get; set; }
        //    public string Value { get; set; }

        //}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            borderPopup.IsOpen = false;
            var v = this.DataContext as ModelSettingsVM;
            v.SettingDetails = new WeibullSolverLibrary.Common_Code.ProjectParameters();
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            borderPopup.IsOpen = true;
        }
    }
}
