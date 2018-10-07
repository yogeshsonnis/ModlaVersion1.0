using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeibullSolverLibrary.Common_Code;

namespace WeibullSolverLibrary
{
   public class TestCases
    {

        public static double tolerance = 0.01; // <1% error to pass

        public static bool TestCase1() //Completely Random Parameters
        {
            //Set-up Project
            ProjectParameters PRJ1 = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };

            //Add a Failure Mode
            var FM = new Failuremode() { Name = "Test", ID = "FM001", Eta = 70762, Beta = 3.92, Gamma = 14227, Initialage = 0, ProjectParams = PRJ1 };

            //Stopwatch
            var sw = Stopwatch.StartNew();

            //Adding Tasks
            FM.CorrectiveTask = new FMTask() { Description = "CR1", TaskCost = 1819, TaskDuration = 0, Agereductionfactor = 1 };
            FM.PlannedTasks.Add(new FMTask() { Description = "PR1", FixedInterval = true, TaskInterval = 8760, TaskCost = 2385, TaskDuration = 13, Secondary = false, Agereductionfactor = 1 });
            FM.PlannedTasks.Add(new FMTask() { Description = "PR2", TaskInterval = 10000, TaskCost = 110, TaskDuration = 13, Secondary = true, Agereductionfactor = 1 });
            FM.InspectionTasks.Add(new FMTask() { TaskCost = 4430, TaskDuration = 0, TaskInterval = 448, PFInterval = 3130, DetectionProbability = 1 });
            FM.Effects.Add(new Effect() { Name = "Environmental Risk", EffectCost = 7738, EffectProbability = .2, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Solve();

            //Expected Results
            double failures = 0;
            double correctivecosts = 0;
            double plannedcosts = 21465;
            double inspectioncosts = 863850;
            double totalcosts = 885315;
            double effectscosts = 0;

            //Test results vs expectations
            Testresults(FM, failures, correctivecosts, plannedcosts, inspectioncosts, totalcosts, effectscosts);

            Debug.WriteLine("****Solver Execution Time = {0} seconds\n", sw.Elapsed.TotalSeconds);

            return true; //success

        }

        public static bool TestCase2() //Typical Basic Config
        {
            //Set-up Project
            ProjectParameters PRJ1 = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };

            //Add a Failure Mode
            var FM = new Failuremode() { Name = "Test", ID = "FM001", Eta = 8760, Beta = 5, Gamma = 0, Initialage = 0, ProjectParams = PRJ1 };

            //Stopwatch
            var sw = Stopwatch.StartNew();

            //Adding Tasks
            FM.CorrectiveTask = new FMTask() { Description = "CR1", TaskCost = 10000, TaskDuration = 24, Agereductionfactor = 1 };
            FM.PlannedTasks.Add(new FMTask() { Description = "PR1", FixedInterval = true, TaskInterval = 8760, TaskCost = 5000, TaskDuration = 10, Secondary = false, Agereductionfactor = 1 });
            FM.PlannedTasks.Add(new FMTask() { Description = "PR2", TaskInterval = 10000, TaskCost = 100, TaskDuration = 1, Secondary = true, Agereductionfactor = 1 });
            FM.InspectionTasks.Add(new FMTask() { TaskCost = 10, TaskDuration = 1, TaskInterval = 738, PFInterval = 438, DetectionProbability = .3 });
            FM.Effects.Add(new Effect() { Name = "Environmental Risk", EffectCost = 2000, EffectProbability = .11, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Solve();

            //Expected Results
            double failures = 5.188;
            double correctivecosts = 51887.2;
            double plannedcosts = 45112.911;
            double inspectioncosts = 1180;
            double totalcosts = 99321.6294;
            double effectscosts = 1141.5184;

            //Test results vs expectations
            Testresults(FM, failures, correctivecosts, plannedcosts, inspectioncosts, totalcosts, effectscosts);

            Debug.WriteLine("****Solver Execution Time = {0} seconds\n", sw.Elapsed.TotalSeconds);

            return true; //success
        }

        public static bool TestCase3() //Verifying the Secondary Costs from Corrective only
        {
            //Set-up Project
            ProjectParameters PRJ1 = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };

            //Add a Failure Mode
            var FM = new Failuremode() { Name = "Test", ID = "FM001", Eta = 8760, Beta = 5, Gamma = 0, Initialage = 0, ProjectParams = PRJ1 };

            //Stopwatch
            var sw = Stopwatch.StartNew();

            //Adding Tasks
            FM.CorrectiveTask = new FMTask() { Description = "CR1", TaskCost = 2000, TaskDuration = 24, Agereductionfactor = 1 };
            FM.PlannedTasks.Add(new FMTask() { Description = "PR1", FixedInterval = false, TaskInterval = 8760, TaskCost = 1000, TaskDuration = 10, Secondary = false, Agereductionfactor = 1 });
            FM.Effects.Add(new Effect() { Name = "Environmental Risk", EffectCost = 2000, EffectProbability = 1, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Solve();

            //Expected Results
            double failures = 6.999843;
            double correctivecosts = 13999.686;
            double plannedcosts = 3983.109; //This is out by about 1.1% at max AvailabilityWB settings but is attenuating toward this calc.
            double inspectioncosts = 0;
            double totalcosts = 31982.481;
            double effectscosts = 13999.686;

            //Test results vs expectations
            Testresults(FM, failures, correctivecosts, plannedcosts, inspectioncosts, totalcosts, effectscosts);

            Debug.WriteLine("****Solver Execution Time = {0} seconds\n", sw.Elapsed.TotalSeconds);

            return true; //success
        }

        public static bool TestCase4() //Random Test #2
        {
            //Set-up Project
            ProjectParameters PRJ1 = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };

            //Add a Failure Mode
            var FM = new Failuremode() { Name = "Test", ID = "FM001", Eta = 81081, Beta = .56, Gamma = 8898, Initialage = 0, ProjectParams = PRJ1 };

            //Stopwatch
            var sw = Stopwatch.StartNew();

            //Adding Tasks
            FM.CorrectiveTask = new FMTask() { Description = "CR1", TaskCost = 3775, TaskDuration = 23, Agereductionfactor = 1 };
            FM.PlannedTasks.Add(new FMTask() { Description = "PR1", FixedInterval = true, TaskInterval = 1785, TaskCost = 1785, TaskDuration = 4, Secondary = false, Agereductionfactor = 1 });
            FM.PlannedTasks.Add(new FMTask() { Description = "PR2", TaskInterval = 1234, TaskCost = 3346, TaskDuration = 5, Secondary = true, Agereductionfactor = 1 });
            FM.InspectionTasks.Add(new FMTask() { TaskCost = 3422, TaskDuration = 0, TaskInterval = 2290, PFInterval = 4342, DetectionProbability = 1 });
            FM.Effects.Add(new Effect() { Name = "Environmental Risk", EffectCost = 2429, EffectProbability = .1, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Solve();

            //Expected Results
            double failures = 0;
            double correctivecosts = 0;
            double plannedcosts = 87465; //This is out by about 1.1% at max AvailabilityWB settings but is attenuating toward this calc.
            double inspectioncosts = 130036;
            double totalcosts = 217501;
            double effectscosts = 0;

            //Test results vs expectations
            Testresults(FM, failures, correctivecosts, plannedcosts, inspectioncosts, totalcosts, effectscosts);

            Debug.WriteLine("****Solver Execution Time = {0} seconds\n", sw.Elapsed.TotalSeconds);

            return true; //success
        }

        public static bool TestCase5() // Initial Age Offset Test
        {
            //Set-up Project
            ProjectParameters PRJ1 = new ProjectParameters() { Projectinterval = 100, Projectlife = 87600 };

            //Add a Failure Mode
            var FM = new Failuremode() { Name = "Test", ID = "FM001", Eta = 8760, Beta = 3, Gamma = 1000, Initialage = 2000, ProjectParams = PRJ1 };

            //Stopwatch
            var sw = Stopwatch.StartNew();

            //Adding Tasks
            FM.CorrectiveTask = new FMTask() { Description = "CR1", TaskCost = 10000, TaskDuration = 24, Agereductionfactor = 1 };
            FM.PlannedTasks.Add(new FMTask() { Description = "PR1", FixedInterval = true, TaskInterval = 8760, TaskCost = 50, TaskDuration = 10, Secondary = false, Agereductionfactor = 1 });
            FM.PlannedTasks.Add(new FMTask() { Description = "PR2", TaskInterval = 10000, TaskCost = 100, TaskDuration = 1, Secondary = true, Agereductionfactor = 1 });
            FM.InspectionTasks.Add(new FMTask() { TaskCost = 10, TaskDuration = 1, TaskInterval = 738, PFInterval = 438, DetectionProbability = .3 });
            FM.Effects.Add(new Effect() { Name = "Environmental Risk", EffectCost = 2000, EffectProbability = .11, EffectType = "Environmental", ApplyToCorrective = true });
            FM.Solve();

            //Expected Results
            double failures = 4.177676;
            double correctivecosts = 41776.76;
            double plannedcosts = 589.5441;
            double inspectioncosts = 1190;
            double totalcosts = 44475.39;
            double effectscosts = 919.088;

            //Test results vs expectations
            Testresults(FM, failures, correctivecosts, plannedcosts, inspectioncosts, totalcosts, effectscosts);

            Debug.WriteLine("****Solver Execution Time = {0} seconds\n", sw.Elapsed.TotalSeconds);
            return true; //success
        }

        public static void Testresults(Failuremode FM, double failures, double correctivecosts, double plannedcosts, double inspectioncosts, double totalcosts, double effectscosts)
        {
            string errors;
            errors = (Math.Abs(failures - FM.FailureProfileTotal)) <= tolerance * FM.FailureProfileTotal ? "Pass" : ((failures - FM.FailureProfileTotal) / FM.FailureProfileTotal).ToString();
            Debug.WriteLine("{0}-Test Case Failures~{1}/{2}", errors, failures, FM.FailureProfileTotal);
            errors = (Math.Abs(correctivecosts - FM.CorrectiveCostsTotal)) <= tolerance * FM.CorrectiveCostsTotal ? "Pass" : ((correctivecosts - FM.CorrectiveCostsTotal) / FM.CorrectiveCostsTotal).ToString();
            Debug.WriteLine("{0}-Test Case Corrective Costs~{1}/{2}", errors, correctivecosts, FM.CorrectiveCostsTotal);
            errors = (Math.Abs(plannedcosts - FM.PlannedCostsTotal)) <= tolerance * FM.PlannedCostsTotal ? "Pass" : ((plannedcosts - FM.PlannedCostsTotal) / FM.PlannedCostsTotal).ToString();
            Debug.WriteLine("{0}-Test Case Planned Costs~{1}/{2}", errors, plannedcosts, FM.PlannedCostsTotal);
            errors = (Math.Abs(inspectioncosts - FM.InspectionCostsTotal)) <= tolerance * FM.InspectionCostsTotal ? "Pass" : ((inspectioncosts - FM.InspectionCostsTotal) / FM.InspectionCostsTotal).ToString();
            Debug.WriteLine("{0}-Test Case Inspection Costs~{1}/{2}", errors, inspectioncosts, FM.InspectionCostsTotal);
            errors = (Math.Abs(totalcosts - FM.CostsTotal)) <= tolerance * FM.CostsTotal ? "Pass" : ((totalcosts - FM.CostsTotal) / FM.CostsTotal).ToString();
            Debug.WriteLine("{0}-Test Case Total Costs~{1}/{2}", errors, totalcosts, FM.CostsTotal);
            errors = (Math.Abs(effectscosts - FM.EffectsCostsTotal)) <= tolerance * FM.EffectsCostsTotal ? "Pass" : ((effectscosts - FM.EffectsCostsTotal) / FM.EffectsCostsTotal).ToString();
            Debug.WriteLine("{0}-Test Case Effects Costs~{1}/{2}", errors, effectscosts, FM.EffectsCostsTotal);
        }
        public static double GetTotal(double?[] inputarray)
        {
            //Totalises the passed in array
            var sum = 0d;
            for (int i = 0; i < inputarray.Length; i++)
            {
                sum += inputarray[i] ?? 0;
            }
            return sum;
        }
    }
}
