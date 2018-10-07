
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
using WeibullSolverLibrary.Common_Code;

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
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            borderPopup.IsOpen = false;
            var v = this.DataContext as ModelSettingsVM;
            v.SettingDetails = new ProjectParameters();
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            borderPopup.IsOpen = true;
        }
    }
}
