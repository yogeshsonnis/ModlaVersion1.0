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
using System.Windows.Shapes;
using WeibullSolver_WPF.ViewModels;
using WeibullSolverLibrary.Common_Code;

namespace WeibullSolver_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for ModesInfoPopup.xaml
    /// </summary>
    public partial class ModesInfoPopup : Window
    {
        public ModesInfoPopup(Failuremode selectedmode)
        {
            InitializeComponent();
            this.DataContext = new ModesInfoVM(selectedmode);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
