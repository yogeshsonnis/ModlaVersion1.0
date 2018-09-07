/*
 * Created by SharpDevelop.
 * User: Saint
 * Date: 5/2/2018
 * Time: 10:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeibullSolver.Common_Code;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace WeibullSolver
{
	/// <summary>
	/// Completed Items:
    ///     Project
    ///         Time Windows
    ///         Project Life
    ///         Apply Inspection at time 0
	/// 	Failure Mode
	/// 		3 Parameter Weibull
	/// 		Inital Age
	///  	Corrective Task 
	///			Duration	
	///			Cost
	///		Planned Task 
	/// 		Duration	
	///			Cost	
	/// 		Secondary Task
	/// 	Inspection Task
	/// 		Duration	
	///			Cost
	/// 		Task Interval
	/// 		PF Interval	
	/// 		Detection Probability
	/// 	Effects
	/// 
	/// Description of MainForm.
	//To be included
	//age reduction factor is setting age not adjusting current age.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
            InitializeComponent(); //req
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Set-up Project
            Model TestProject = new Model();
            ProjectParameters PRJ1 = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };
            TestProject.Locations.Add("LOC1", new Location() { LocationName = "LOC1" });
            TestProject.Locations["LOC1"].Functions.Add("FUNC1", new Function() { FunctionName = "FUNC1" });
            TestProject.Locations["LOC1"].Functions["FUNC1"].FunctionalFailures.Add("FF1", new FunctionalFailure() { FunctionName = "FF1" });
            TestProject.Locations["LOC1"].Functions["FUNC1"].FunctionalFailures["FF1"].Failuremodes.Add("FM1", new Failuremode() { Name = "Test", ID = "FM001", Eta = 8760, Beta = 3, Gamma = 1000, Initialage = 2000, ProjectParams = PRJ1 });
            TestProject.Locations["LOC1"].Functions["FUNC1"].FunctionalFailures["FF1"].Identifiers.Add(104);
            var FM = TestProject.Locations["LOC1"].Functions["FUNC1"].FunctionalFailures["FF1"].Failuremodes["FM1"];

            //Adding Tasks to the Failure Mode
            FM.CorrectiveTask = new FMTask() { Description = "CR1", TaskCost = 10000, TaskDuration = 24, Agereductionfactor = 1 };
            FM.PlannedTasks.Add(new FMTask() { Description = "PR1", FixedInterval = true, TaskInterval = 8760, TaskCost = 50, TaskDuration = 10, Secondary = false, Agereductionfactor = 1 });
            FM.PlannedTasks.Add(new FMTask() { Description = "PR2", TaskInterval = 10000, TaskCost = 100, TaskDuration = 1, Secondary = true, Agereductionfactor = 1 });
            FM.InspectionTasks.Add(new FMTask() { TaskCost = 10, TaskDuration = 1, TaskInterval = 738, PFInterval = 438, DetectionProbability = .3 });
            FM.Effects.Add(new Effect() { Name = "Environmental Risk", EffectCost = 2000, EffectProbability = .11, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Effects.Add(new Effect() { Name = "Safety Risk", EffectCost = 50000, EffectProbability = .01, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Effects.Add(new Effect() { Name = "Network Performance Risk", EffectCost = 200, EffectProbability = 1, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Effects.Add(new Effect() { Name = "Reputational Risk", EffectCost = 1000, EffectProbability = .3, EffectType = "Environmental", ApplyToCorrective = true, ApplyToPlanned = true });

            var sw = Stopwatch.StartNew();
            TestProject.Decisions.Add("SPACIAL1", new Decision());
            TestProject.Decisions["SPACIAL1"].Actions.Add(new DecisionActions() { Identifier = 104, Modifier = 0.95, actiontype = 1 });
            TestProject.Decisions["SPACIAL1"].Questions.Add(new DecisionQuestions() {sourcefieldid = "Corrosion", decisiontype =1, stringcomparison = "Costal" });

            var AssetInfo = new Dictionary<string, string>()
            {
                {"ID", "PUMP001"},
                {"ID2", "PUMP00A"},
                {"CITY", "BRISBANE"},
                {"CORROSION", "COSTAL"},
                {"Riff", "RAFF"},
            };

            foreach (var decsion in TestProject.Decisions.Values)
            {
                decsion.ApplyDecision(AssetInfo, TestProject);
            }


            var results = TestProject.Solve();

            Utilities.EncryptandSave(TestProject);
            var Chinky = Utilities.LoadAndDecrypt();
            
            Debug.WriteLine("Solver Execution Time = {0} seconds\n", sw.Elapsed.TotalSeconds);
            var xaxis = PRJ1.GetXaxis();
            
			//Chart Setup
            label1.Text = TestProject.FailureProfileTotal.ToString();
            label4.Text = TestProject.correctiveCostsTotal.ToString();
            label8.Text = TestProject.plannedCostsTotal.ToString();
            label6.Text = TestProject.inspectionCostsTotal.ToString();
            label10.Text = TestProject.costsTotal.ToString();
            label12.Text = TestProject.effectsCostsTotal.ToString();

            //Chart Initialisation
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            //chart1.ChartAreas[0].AxisX.Maximum = PRJ1.Projectlife;
            chart1.ChartAreas[0].AxisX.Title = "Time";
            chart1.ChartAreas[0].AxisY.Title = "PoF";

            //Determine PDF and set to chart 1
            chart1.Series[0].Name = "Corrective HF";
            chart1.Series[0].Points.DataBindXY(xaxis,  FM.CorrectiveTask.TaskHF);

            chart3.ChartAreas[0].AxisX.Minimum = 0;
            //chart3.ChartAreas[0].AxisX.Maximum =  PRJ1.Projectlife;
            chart3.ChartAreas[0].AxisX.Title = "Time";
            chart3.ChartAreas[0].AxisY.Title = "Cost ($)";

            //Chart 3 Effects Series
            foreach (var effect in FM.Effects)
            {
                if (chart3.Series.FindByName(effect.Name) == null) chart3.Series.Add(effect.Name);
                chart3.Series[effect.Name].Points.DataBindXY(xaxis, effect.Costs);
                chart3.Series[effect.Name].ChartType = SeriesChartType.StackedColumn;
            }


            //Chart 3 Corrective Series
            if (chart3.Series.FindByName("Corrective Cost") == null) chart3.Series.Add("Corrective Cost");
            chart3.Series["Corrective Cost"].Points.DataBindXY(xaxis, FM.correctiveCosts);
            chart3.Series["Corrective Cost"].ChartType = SeriesChartType.StackedColumn;

            //Chart 3 Planned Series
            if (chart3.Series.FindByName("Planned Cost") == null) chart3.Series.Add("Planned Cost");
            chart3.Series["Planned Cost"].Points.DataBindXY(xaxis, FM.plannedCosts);
            chart3.Series["Planned Cost"].ChartType = SeriesChartType.StackedColumn;
            
            //Chart 3 Inspection Series
            if (chart3.Series.FindByName("Inspection Cost") == null) chart3.Series.Add("Inspection Cost");
            chart3.Series["Inspection Cost"].Points.DataBindXY(xaxis, FM.inspectionCosts);
            chart3.Series["Inspection Cost"].ChartType = SeriesChartType.StackedColumn;

            chart3.Series.Remove(chart3.Series.FindByName("Series1"));

            chart4.Series[0].Name = "Corrective PDF";
            chart4.Series[0].Points.DataBindXY(xaxis, FM.CorrectiveTask.TaskPDF);
            chart4.ChartAreas[0].AxisX.Minimum = 0;
            //chart4.ChartAreas[0].AxisX.Maximum = PRJ1.Projectlife;
            chart4.ChartAreas[0].AxisX.Title = "Time";
            chart4.ChartAreas[0].AxisY.Title = "PoF";

            chart5.Series[0].Name = "Final Results";
            chart5.Series[0].Points.DataBindXY(xaxis, FM.FailureProfile);
            chart5.ChartAreas[0].AxisX.Minimum = 0;
            //chart5.ChartAreas[0].AxisX.Maximum = PRJ1.Projectlife;
            chart5.ChartAreas[0].AxisX.Title = "Time";
            chart5.ChartAreas[0].AxisY.Title = "PoF";
        }

        private void button2_Click(object sender, EventArgs e)
        {
        	
            TestCases.TestCase1();
            TestCases.TestCase2();
            TestCases.TestCase3();
            TestCases.TestCase4();
            TestCases.TestCase5();
			

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Set-up Project
            ProjectParameters PRJ1 = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };

            //Add a Failure Mode
            var FM = new Failuremode() { Name = "Test", ID = "FM001", Eta = 8760, Beta = 3, Gamma = 1000, Initialage = 2000, ProjectParams = PRJ1 };

            //Adding Tasks to the Failure Mode
            FM.CorrectiveTask = new FMTask() { Description = "CR1", TaskCost = 10000, TaskDuration = 24, Agereductionfactor = 1 };
            FM.PlannedTasks.Add(new FMTask() { Description = "PR1", FixedInterval = true, TaskInterval = 8760, TaskCost = 50, TaskDuration = 10, Secondary = false, Agereductionfactor = 1 });
            FM.PlannedTasks.Add(new FMTask() { Description = "PR2", TaskInterval = 10000, TaskCost = 100, TaskDuration = 1, Secondary = true, Agereductionfactor = 1 });
            FM.InspectionTasks.Add(new FMTask() { Description = "IN1", TaskCost = 10, TaskDuration = 1, TaskInterval = 738, PFInterval = 438, DetectionProbability = .3 });
            FM.Effects.Add(new Effect() { Name = "Environmental Risk", EffectCost = 2000, EffectProbability = .11, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Effects.Add(new Effect() { Name = "Safety Risk", EffectCost = 50000, EffectProbability = .01, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Effects.Add(new Effect() { Name = "Network Performance Risk", EffectCost = 200, EffectProbability = 1, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Effects.Add(new Effect() { Name = "Reputational Risk", EffectCost = 1000, EffectProbability = .3, EffectType = "Environmental", ApplyToCorrective = true, ApplyToPlanned = true });

            FM.OptimiseIntervals(true, 168, 1, 20000);
        }
    }
}
