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
    /// Interaction logic for ModelConfiguration.xaml
    /// </summary>
    public partial class ModelConfiguration : UserControl
    {
        public ModelConfiguration()
        {
            InitializeComponent();
            this.DataContext = new ModelConfigurationVM();
            CreateFMTaskTab.IsChecked = true;
        }

        private void CreateFMTaskTab_Click(object sender, RoutedEventArgs e)
        {
            if (CreateFMTaskTab.IsChecked == true)
            {
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                CreateModel.Visibility = Visibility.Collapsed;
                CreateFMTAsk.Visibility = Visibility.Visible;
            }
            else if (CreateFailuremodeTab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                CreateModel.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Visible;
            }
            else if (CreateFunctionFailureTab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                CreateModel.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Visible;
            }
            else if (CreateFunctionTab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                CreateModel.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Visible;
            }
            else if (CreateLocationtab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                CreateModel.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Visible;
            }
            else if (CreateModelTab.IsChecked == true)
            {
                CreateFMTAsk.Visibility = Visibility.Collapsed;
                CreateFailuremode.Visibility = Visibility.Collapsed;
                CreateFunctionFailure.Visibility = Visibility.Collapsed;
                CreateFunction.Visibility = Visibility.Collapsed;
                CreateLocation.Visibility = Visibility.Collapsed;
                CreateModel.Visibility = Visibility.Visible;
            }
        }
    }
}
