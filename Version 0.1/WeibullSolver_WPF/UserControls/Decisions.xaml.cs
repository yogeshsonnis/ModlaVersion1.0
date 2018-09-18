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
using WeibullSolver_WPF.ViewModels;

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
            this.DataContext = new OverviewVM();
        }
    }
}
