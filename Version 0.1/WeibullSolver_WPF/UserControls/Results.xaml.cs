using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : UserControl
    {
        public Results()
        {
            InitializeComponent();

            var converter = new System.Windows.Media.BrushConverter();
            Brush blue = (Brush)converter.ConvertFromString("#3ba3d2");
            Brush orange = (Brush)converter.ConvertFromString("#e56e25");
            Brush yellow = (Brush)converter.ConvertFromString("#efb119");
            Brush green = (Brush)converter.ConvertFromString("#4eb966");

            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Corrective",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                    DataLabels = true,
                    Fill = blue
                },
                new PieSeries
                {
                    Title = "Planned",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(6) },
                    DataLabels = true,
                    Fill = green
                },
                new PieSeries
                {
                    Title = "Inspection",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                    DataLabels = true,
                    Fill = yellow
                },
                new PieSeries
                {
                    Title = "Effects",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(10) },
                    DataLabels = true,
                    Fill = orange
                }
            };

            //adding values or series will update and animate the chart automatically
            //SeriesCollection.Add(new PieSeries());
            //SeriesCollection[0].Values.Add(5);

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
    }
}
