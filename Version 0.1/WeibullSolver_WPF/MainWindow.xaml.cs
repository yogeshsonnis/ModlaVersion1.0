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
using WeibullSolver_WPF.CommonControls;
using WeibullSolver_WPF.ViewModels;

namespace WeibullSolver_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : CustomWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new HomeVM();
            checkboxAll.IsChecked = true;
            borderFilters.Visibility = Visibility.Collapsed;
            btnHome.IsChecked = true;
            CreateFMTaskTab.IsChecked = true;
        }

        private void btnOverview_Click(object sender, RoutedEventArgs e)
        {
            if (btnHome.IsChecked == true)
            {
                gridOverview.Visibility = Visibility.Collapsed;
                borderFilters.Visibility = Visibility.Collapsed;
                gridModelsettings.Visibility = Visibility.Collapsed;
                gridModelConfiguration.Visibility = Visibility.Collapsed;
                gridBatching.Visibility = Visibility.Collapsed;
                gridHelp.Visibility = Visibility.Collapsed;
                gridHome.Visibility = Visibility.Visible; 
            }
            else if(btnOverview.IsChecked==true)
            {
               
                gridModelsettings.Visibility = Visibility.Collapsed;
                gridModelConfiguration.Visibility = Visibility.Collapsed;
                gridBatching.Visibility = Visibility.Collapsed;
                gridHelp.Visibility = Visibility.Collapsed;
                gridHome.Visibility = Visibility.Collapsed;
                gridOverview.Visibility = Visibility.Visible;
                borderFilters.Visibility = Visibility.Visible;
            }
            else if(btnModelSettings.IsChecked == true)
            {
                gridOverview.Visibility = Visibility.Collapsed;
                borderFilters.Visibility = Visibility.Collapsed;
                gridModelConfiguration.Visibility = Visibility.Collapsed;
                gridBatching.Visibility = Visibility.Collapsed;
                gridHelp.Visibility = Visibility.Collapsed;
                gridHome.Visibility = Visibility.Collapsed;
                gridModelsettings.Visibility = Visibility.Visible;
            }
            else if(btnModelConfiguration.IsChecked == true)
            {
                gridOverview.Visibility = Visibility.Collapsed;
                borderFilters.Visibility = Visibility.Collapsed;
                gridModelsettings.Visibility = Visibility.Collapsed;
                gridBatching.Visibility = Visibility.Collapsed;
                gridHelp.Visibility = Visibility.Collapsed;
                gridHome.Visibility = Visibility.Collapsed;
                gridModelConfiguration.Visibility = Visibility.Visible;
            }
            else if(btnBatching.IsChecked == true)
            {
                gridOverview.Visibility = Visibility.Collapsed;
                borderFilters.Visibility = Visibility.Collapsed;
                gridModelsettings.Visibility = Visibility.Collapsed;
                gridModelConfiguration.Visibility = Visibility.Collapsed;
                gridHelp.Visibility = Visibility.Collapsed;
                gridHome.Visibility = Visibility.Collapsed;
                gridBatching.Visibility = Visibility.Visible;
            }
            else if(btnHelp.IsChecked==true)
            {
                gridOverview.Visibility = Visibility.Collapsed;
                borderFilters.Visibility = Visibility.Collapsed;
                gridModelsettings.Visibility = Visibility.Collapsed;
                gridModelConfiguration.Visibility = Visibility.Collapsed;
                gridBatching.Visibility = Visibility.Collapsed;
                gridHome.Visibility = Visibility.Collapsed;
                gridHelp.Visibility = Visibility.Visible;
            }
        }

        private void CreateFMTaskTab_Click(object sender, RoutedEventArgs e)
        {
            if (CreateFMTaskTab.IsChecked == true)
            {
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                Grid_CreateModel.Visibility = Visibility.Collapsed;
                CreateFMTAsk.Visibility = Visibility.Visible;
            }
            else if (CreateFailuremodeTab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                Grid_CreateModel.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Visible;
            }
            else if (CreateFunctionFailureTab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                Grid_CreateModel.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Visible;
            }
            else if (CreateFunctionTab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                Grid_CreateModel.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Visible;
            }
            else if (CreateLocationtab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                Grid_CreateModel.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Visible;
            }
            else if (CreateModelTab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                Grid_CreateModel.Visibility = Visibility.Visible;
            }
        }
    }
}
