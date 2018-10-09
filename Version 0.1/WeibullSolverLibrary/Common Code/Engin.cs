using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeibullSolverLibrary.Common_Code
{
    /// <summary>
    /// Description of Functions.
    /// 
    /// </summary>
    /// 
    public class ProjectParameters: BaseHandler1
    { 
        //Storage for Project Parameters
        string projectName;
        int projectinterval;
        //  public string ProjectName { get; set; }
        // public int Projectinterval { get; set; }
        public int Projectlife { get; set; }
        public int TimeWindows { get; set; }
        public bool ApplyInspectionAtTimeZero { get; set; }

        public string ProjectName
        {
            get
            {
                return projectName;
            }

            set
            {
                projectName = value;
                NotifyPropertyChanged("ProjectName");
            }
        }

        public int Projectinterval
        {
            get
            {
                return projectinterval;
            }

            set
            {
                projectinterval = value;
                NotifyPropertyChanged("Projectinterval");
            }
        }

        public double[] GetXaxis()
        {
            int timewindows = Projectlife / Projectinterval;
            double[] xaxis = new double[timewindows];
            for (int i = 0; i < timewindows; i++)
            {
                xaxis[i] = i * Projectinterval;
            }
            return xaxis;
        }

    }
    /// <summary>
    /// 
    /// </summary>


    public class Model
    {
        //Arrays to be returned by the solver
        public double?[] correctiveCosts;
        public double?[] plannedCosts;
        public double?[] inspectionCosts;
        public double?[] effectsCosts;
        public double?[] FailureProfile;

        //Totals to be returned by the solver
        public double correctiveCostsTotal;
        public double plannedCostsTotal;
        public double inspectionCostsTotal;
        public double effectsCostsTotal;
        public double FailureProfileTotal;
        public double costsTotal;

        public string ModelName { get; set; }
        public string ModelDescription { get; set; }
        public Dictionary<string, Location> Locations = new Dictionary<string, Location>();
        public Dictionary<string, Decision> Decisions = new Dictionary<string, Decision>();
        public bool Solve()
        {
            foreach (var L in Locations.Values)
            {
                L.Solve();
                correctiveCostsTotal += L.correctiveCostsTotal;
                plannedCostsTotal += L.plannedCostsTotal;
                inspectionCostsTotal += L.inspectionCostsTotal;
                effectsCostsTotal += L.effectsCostsTotal;
                FailureProfileTotal += L.FailureProfileTotal;
                costsTotal += L.costsTotal;
                correctiveCosts = Utilities.AddArrays(correctiveCosts, L.correctiveCosts);
                plannedCosts = Utilities.AddArrays(plannedCosts, L.plannedCosts);
                inspectionCosts = Utilities.AddArrays(inspectionCosts, L.inspectionCosts);
                effectsCosts = Utilities.AddArrays(effectsCosts, L.effectsCosts);
                FailureProfile = Utilities.AddArrays(FailureProfile, L.FailureProfile);
            }
            return true;
        }
    }

    public class Location
    {
        //Arrays to be returned by the solver
        public double?[] correctiveCosts;
        public double?[] plannedCosts;
        public double?[] inspectionCosts;
        public double?[] effectsCosts;
        public double?[] FailureProfile;

        //Totals to be returned by the solver
        public double correctiveCostsTotal;
        public double plannedCostsTotal;
        public double inspectionCostsTotal;
        public double effectsCostsTotal;
        public double FailureProfileTotal;
        public double costsTotal;

        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public bool Disabled { get; set; } = true;
        public List<int> Identifiers = new List<int>();
        public Dictionary<string, Function> Functions = new Dictionary<string, Function>();
        public bool Solve()
        {
            foreach (var F in Functions.Values)
            {
                F.Solve();
                correctiveCostsTotal += F.correctiveCostsTotal;
                plannedCostsTotal += F.plannedCostsTotal;
                inspectionCostsTotal += F.inspectionCostsTotal;
                effectsCostsTotal += F.effectsCostsTotal;
                FailureProfileTotal += F.FailureProfileTotal;
                costsTotal += F.costsTotal;
                correctiveCosts = Utilities.AddArrays(correctiveCosts, F.correctiveCosts);
                plannedCosts = Utilities.AddArrays(plannedCosts, F.plannedCosts);
                inspectionCosts = Utilities.AddArrays(inspectionCosts, F.inspectionCosts);
                effectsCosts = Utilities.AddArrays(effectsCosts, F.effectsCosts);
                FailureProfile = Utilities.AddArrays(FailureProfile, F.FailureProfile);
            }
            return true;
        }
    }

    public class Function
    {
        //Arrays to be returned by the solver
        public double?[] correctiveCosts;
        public double?[] plannedCosts;
        public double?[] inspectionCosts;


        public double?[] effectsCosts;
        public double?[] FailureProfile;

        //Totals to be returned by the solver
        public double correctiveCostsTotal;
        public double plannedCostsTotal;
        public double inspectionCostsTotal;
        public double effectsCostsTotal;
        public double FailureProfileTotal;
        public double costsTotal;

        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
        public bool Disabled { get; set; } = true;
        public List<int> Identifiers = new List<int>();
        public Dictionary<string, FunctionalFailure> FunctionalFailures = new Dictionary<string, FunctionalFailure>();
        public bool Solve()
        {
            foreach (var FF in FunctionalFailures.Values)
            {
                FF.Solve();
                correctiveCostsTotal += FF. CorrectiveCostsTotal;
                plannedCostsTotal += FF.PlannedCostsTotal;
                inspectionCostsTotal += FF.InspectionCostsTotal;
                effectsCostsTotal += FF.EffectsCostsTotal;
                FailureProfileTotal += FF.FailureProfileTotal;
                costsTotal += FF.CostsTotal;
                correctiveCosts = Utilities.AddArrays(correctiveCosts, FF.correctiveCosts);
                plannedCosts = Utilities.AddArrays(plannedCosts, FF.plannedCosts);
                inspectionCosts = Utilities.AddArrays(inspectionCosts, FF.inspectionCosts);
                effectsCosts = Utilities.AddArrays(effectsCosts, FF.effectsCosts);
                FailureProfile = Utilities.AddArrays(FailureProfile, FF.FailureProfile);
            }
            return true;
        }
    }

    public class FunctionalFailure : BaseHandler1
    {
        //Arrays to be returned by the solver
        public double?[] correctiveCosts;
        public double?[] plannedCosts;
        public double?[] inspectionCosts;
        public double?[] effectsCosts;
        public double?[] FailureProfile;

        //Totals to be returned by the solver
         double correctiveCostsTotal;
         double plannedCostsTotal;
         double inspectionCostsTotal;
         double effectsCostsTotal;
         double failureProfileTotal;
         double costsTotal;

        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
        public bool Disabled { get; set; } = true;

        public double CorrectiveCostsTotal
        {
            get
            {
                return correctiveCostsTotal;
            }

            set
            {
                correctiveCostsTotal = value;
                NotifyPropertyChanged("CorrectiveCostsTotal");
                
            }
        }

        public double PlannedCostsTotal
        {
            get
            {
                return plannedCostsTotal;
            }

            set
            {
                plannedCostsTotal = value;
                NotifyPropertyChanged("PlannedCostsTotal");
            }
        }

        public double InspectionCostsTotal
        {
            get
            {
                return inspectionCostsTotal;
            }

            set
            {
                inspectionCostsTotal = value;
                NotifyPropertyChanged("InspectionCostsTotal");
            }
        }

        public double EffectsCostsTotal
        {
            get
            {
                return effectsCostsTotal;
            }

            set
            {
                effectsCostsTotal = value;
                NotifyPropertyChanged("EffectsCostsTotal");
            }
        }

        public double FailureProfileTotal
        {
            get
            {
                return failureProfileTotal;
            }

            set
            {
                failureProfileTotal = value;
                NotifyPropertyChanged("FailureProfileTotal");
            }
        }

        public double CostsTotal
        {
            get
            {
                return costsTotal;
            }

            set
            {
                costsTotal = value;
                NotifyPropertyChanged("CostsTotal");
            }
        }

        public List<int> Identifiers = new List<int>();
        public Dictionary<string, Failuremode> Failuremodes = new Dictionary<string, Failuremode>();
        public bool Solve()
        {
            foreach (var FM in Failuremodes.Values)
            {
                FM.Solve();
                CorrectiveCostsTotal += FM.CorrectiveCostsTotal;
                PlannedCostsTotal += FM.PlannedCostsTotal;
                InspectionCostsTotal += FM.InspectionCostsTotal;
                EffectsCostsTotal += FM.EffectsCostsTotal;
                FailureProfileTotal += FM.FailureProfileTotal;
                CostsTotal += FM.CostsTotal;
                correctiveCosts = Utilities.AddArrays(correctiveCosts, FM.correctiveCosts);
                plannedCosts = Utilities.AddArrays(plannedCosts, FM.plannedCosts);
                inspectionCosts = Utilities.AddArrays(inspectionCosts, FM.inspectionCosts);
                effectsCosts = Utilities.AddArrays(effectsCosts, FM.effectsCosts);
                FailureProfile = Utilities.AddArrays(FailureProfile, FM.FailureProfile);
            }
            return true;
        }
    }

    public class Failuremode : BaseHandler1
    {
        string component;
        string what;
        string due_To;
        bool isCheckedFailuremode;
        public string Component
        {
            get
            {
                return component;
            }

            set
            {
                component = value;

            }
        }
        public string What
        {
            get
            {
                return what;
            }

            set
            {
                what = value;

            }
        }
        public string Due_To
        {
            get
            {
                return due_To;
            }

            set
            {
                due_To = value;

            }
        }
        //Storage for Project Parameters
        int timeWindows;
        public int TimeWindows
        {
            get { return timeWindows; }
            set { timeWindows = value; NotifyPropertyChanged("TimeWindows"); }
        }

        int projectinterval;
        public int Projectinterval
        {
            get { return projectinterval; }
            set { projectinterval = value; NotifyPropertyChanged("Projectinterval"); }
        }

        int projectlife;
        public int Projectlife
        {
            get { return projectlife; }
            set { projectlife = value; NotifyPropertyChanged("Projectlife"); }
        }

        bool applyInspectionAtTimeZero;
        public bool ApplyInspectionAtTimeZero
        {
            get { return applyInspectionAtTimeZero; }
            set { applyInspectionAtTimeZero = value; NotifyPropertyChanged("ApplyInspectionAtTimeZero"); }
        }

        bool disabled = true;
        public bool Disabled
        {
            get { return disabled; }
            set { disabled = value; NotifyPropertyChanged("Disabled"); }
        }
        ProjectParameters projectParams;
        public ProjectParameters ProjectParams
        {
            get
            {
                return projectParams;
            }

            set
            {
                projectParams = value;
                NotifyPropertyChanged("ProjectParams");
            }
        }


        //Public Failuremode Info
        public string ID { get; set; }
        public string Name { get; set; }
        public string ModeDescription { get; set; }
        public double Eta { get; set; } //= 8760;
        public double Beta { get; set; } // = 1;
        public double Gamma { get; set; } //= 0;
        public int Initialage { get; set; } //= 0;

        public List<int> Identifiers = new List<int>();
        public FMTask CorrectiveTask;
        public List<FMTask> PlannedTasks = new List<FMTask>();
        public List<FMTask> InspectionTasks = new List<FMTask>();
        public List<Effect> Effects = new List<Effect>();

        //Arrays to be returned by the solver
        public double?[] correctiveCosts;
        public double?[] plannedCosts;
        public double?[] inspectionCosts;
        public double?[] effectsCosts;
        public double?[] FailureProfile;

        //Totals to be returned by the solver
        double correctiveCostsTotal;
        public double CorrectiveCostsTotal
        {
            get
            {
                return correctiveCostsTotal;
            }

            set
            {
                correctiveCostsTotal = value;
                NotifyPropertyChanged("CorrectiveCostsTotal");
            }
        }
        double plannedCostsTotal;
        public double PlannedCostsTotal
        {
            get
            {
                return plannedCostsTotal;
            }

            set
            {
                plannedCostsTotal = value;
                NotifyPropertyChanged("PlannedCostsTotal");
            }
        }
        double inspectionCostsTotal;
        public double InspectionCostsTotal
        {
            get
            {
                return inspectionCostsTotal;
            }

            set
            {
                inspectionCostsTotal = value;
                NotifyPropertyChanged("InspectionCostsTotal");
            }
        }
        double effectsCostsTotal;
        public double EffectsCostsTotal
        {
            get
            {
                return effectsCostsTotal;
            }

            set
            {
                effectsCostsTotal = value;
                NotifyPropertyChanged("EffectsCostsTotal");
            }
        }
        double failureProfileTotal;
        public double FailureProfileTotal
        {
            get
            {
                return failureProfileTotal;
            }

            set
            {
                failureProfileTotal = value;
                NotifyPropertyChanged("FailureProfileTotal");
            }
        }
        double costsTotal;
        public double CostsTotal
        {
            get
            {
                return costsTotal;
            }

            set
            {
                costsTotal = value;
                NotifyPropertyChanged("CostsTotal");
            }
        }

        public bool IsCheckedFailuremode
        {
            get
            {
                return isCheckedFailuremode;
            }

            set
            {
                isCheckedFailuremode = value;
                NotifyPropertyChanged("IsCheckedFailuremode");
            }
        }

        //Private Functions
        bool SolverInitialisations()
        {
            //Initialisations
            Projectinterval = ProjectParams.Projectinterval;
            Projectlife = ProjectParams.Projectlife;
            TimeWindows = ProjectParams.TimeWindows;
            CorrectiveCostsTotal = 0;
            PlannedCostsTotal = 0;
            InspectionCostsTotal = 0;
            EffectsCostsTotal = 0;
            FailureProfileTotal = 0;
            CostsTotal = 0;
            TimeWindows = Projectlife / Projectinterval;
            correctiveCosts = new double?[TimeWindows];
            plannedCosts = new double?[TimeWindows];
            inspectionCosts = new double?[TimeWindows];
            effectsCosts = new double?[TimeWindows];
            FailureProfile = new double?[TimeWindows];

            if (CorrectiveTask != null)
            {
                CorrectiveTask.Occurances = new double?[TimeWindows];
                CorrectiveTask.Costs = new double?[TimeWindows];
                CorrectiveTask.TaskHF = new double?[TimeWindows];
                CorrectiveTask.AdjustedTaskHF = new double?[TimeWindows];
                CorrectiveTask.TaskPDF = new double?[TimeWindows];
                CorrectiveTask.HFPlannedCosts = new double?[TimeWindows];
                CorrectiveTask.AdjustedHFPlannedCosts = new double?[TimeWindows];
                CorrectiveTask.PDFPlannedCosts = new double?[TimeWindows];

                foreach (var resource in CorrectiveTask.Resources)
                {
                    resource.Occurances = new double?[TimeWindows];
                    resource.Costs = new double?[TimeWindows];
                }
            }

            foreach (var task in PlannedTasks)
            {
                //Initialise
                task.Occurances = new double?[TimeWindows];
                task.Costs = new double?[TimeWindows];
                if (task.Disabled == false)
                {
                    task.TaskHF = new double?[TimeWindows];
                    task.AdjustedTaskHF = new double?[TimeWindows];
                    task.TaskPDF = new double?[TimeWindows];
                    task.HFPlannedCosts = new double?[TimeWindows];
                    task.AdjustedHFPlannedCosts = new double?[TimeWindows];
                    task.PDFPlannedCosts = new double?[TimeWindows];

                    foreach (var resource in task.Resources)
                    {
                        resource.Occurances = new double?[TimeWindows];
                        resource.Costs = new double?[TimeWindows];
                    }
                }
            }

            foreach (var task in InspectionTasks)
            {
                //Initialise
                if (task.Disabled == false)
                {
                    task.Occurances = new double?[TimeWindows];
                    task.Costs = new double?[TimeWindows];
                    foreach (var resource in task.Resources)
                    {
                        resource.Occurances = new double?[TimeWindows];
                        resource.Costs = new double?[TimeWindows];
                    }
                }
            }

            foreach (var effect in Effects)
            {
                //Initialise
                effect.Occurances = new double?[TimeWindows];
                effect.Costs = new double?[TimeWindows];
            }

            return true;
        }
        bool BuildHazardFunctions()
        {
            //Build the inital Hazard Function from the Initial Age and store in the corrective task holder
            GetHF(CorrectiveTask, 0).CopyTo(CorrectiveTask.TaskHF, 0);

            foreach (var task in PlannedTasks)
            {
                //Initialise
                if (task.Disabled == false)
                {
                    //Build the HF from new
                    task.TaskHF = GetHF(task, 0); // need to convert this eta using the GammaFunction? STORE task PDF in itself.
                }
            }
            return true;
        }
        bool OverlayPlannedTasksOnHFs()
        {
            //Maybe move these to global
            double?[] fplan = new double?[TimeWindows];
            double?[] fplancosts = new double?[TimeWindows];

            //Generate the Forward Plan
            for (int window = 1; window < TimeWindows; window++)
            {
                bool replacedalready = false;

                foreach (var task in PlannedTasks)
                {
                    //if task falls within the window
                    if (task.Disabled == false && task.FixedInterval == false && task.Secondary == false)
                    {
                        if (((((window) * Projectinterval) % task.TaskInterval) < Projectinterval) && !replacedalready)
                        {
                            if (task.Agereductionfactor > 0) //only apply if age reduction factor affects
                            {
                                for (int j = 0; j < (task.TaskInterval / Projectinterval) + 1 && (window + j) < TimeWindows; j++)
                                {
                                    fplan[window + j] = task.TaskHF[j];
                                }
                            }
                            //AND apply its costs
                            fplancosts[window] = task.TaskCost + (fplancosts[window] ?? 0);
                        }
                        // because the planned tasks are sorted, then this picks up the first replacement. disabling subseuqent longer interval replacments in the same window.
                        if (task.Agereductionfactor >= 1)
                        {
                            replacedalready = true;
                        }
                    }
                }
            }
            //Add Forward Plan to Corrective Task
            CorrectiveTask.TaskHF = Overlay(CorrectiveTask.TaskHF, fplan);
            CorrectiveTask.HFPlannedCosts = Overlay(CorrectiveTask.HFPlannedCosts, fplancosts);

            //Add Forward Plan to Planned Tasks
            foreach (var task in PlannedTasks)
            {
                if (task.Disabled == false)
                {
                    task.TaskHF = Overlay(task.TaskHF, fplan);
                    task.HFPlannedCosts = Overlay(task.HFPlannedCosts, fplancosts);
                }

            }
            return true;
        }
        double?[] Overlay(double?[] primary, double?[] secondary)
        {
            for (int i = 0; i < primary.Length; i++)
            {
                primary[i] = secondary[i] ?? primary[i];
            }
            return primary;
        }
        bool MakeInitialAgeAdjustments()
        {
            //CorrectiveTask
            Array.Copy(CorrectiveTask.TaskHF, Initialage / Projectinterval, CorrectiveTask.AdjustedTaskHF, 0, CorrectiveTask.TaskHF.Length - (Initialage / Projectinterval));
            Array.Copy(CorrectiveTask.HFPlannedCosts, Initialage / Projectinterval, CorrectiveTask.AdjustedHFPlannedCosts, 0, CorrectiveTask.HFPlannedCosts.Length - (Initialage / Projectinterval));
            //PlannedTasks
            foreach (var task in PlannedTasks)
            {
                if (task.Disabled == false)
                {
                    //Here we can apply the replacement age in the future
                    Array.Copy(task.TaskHF, 0, task.AdjustedTaskHF, 0, task.TaskHF.Length - (Initialage / Projectinterval));
                    Array.Copy(task.HFPlannedCosts, 0, task.AdjustedHFPlannedCosts, 0, task.HFPlannedCosts.Length - (Initialage / Projectinterval));
                }
            }
            return true;
        }
        bool BuildPDFs()
        {
            //Corrective Task PDF
            CorrectiveTask.TaskPDF = GetPDFFromHF(CorrectiveTask.TaskHF, true);
            //Apply the Costs via CDF to the PDF
            CorrectiveTask.PDFPlannedCosts = MultiplyArrays(GetPDFFromHF(CorrectiveTask.TaskHF, false), CorrectiveTask.HFPlannedCosts);

            //Planned Tasks
            foreach (var task in PlannedTasks)
            {
                if (task.Disabled == false)
                {
                    //Generate PDF
                    task.TaskPDF = GetPDFFromHF(task.TaskHF, true);
                    //Apply the Costs via CDF to the PDF
                    task.PDFPlannedCosts = MultiplyArrays(GetPDFFromHF(task.TaskHF, false), task.HFPlannedCosts);
                }
            }
            return true;
        } //Probability Density Functions
        double?[] GetHF(FMTask task, int taskoffset)
        {
            double?[] failurearray = new double?[Projectlife]; //Hazard Function
            double?[] Windowedfailurearray = new double?[TimeWindows]; //Hazard Function
            //build replacement hazard function
            for (int i = 0; (i + taskoffset + task.TaskDuration) < Projectlife; i++)
            {
                //3 Parameter Weibull Integrated over the intervals
                failurearray[i + taskoffset + task.TaskDuration] = (Beta / Eta) * (Math.Max((i - Gamma), 0) == 0 ? 0 : Math.Pow(((Math.Max((i - Gamma), 0)) / Eta), (Beta - 1)));
                //failurearray[i + taskoffset + task.TaskDuration] *= (1 - inspectionEffectiveness) * task.Agereductionfactor;
            }

            for (int i = 0; i < TimeWindows; i++)
            {
                for (int j = 0; j < Projectinterval; j++)
                {
                    //Put them in buckets
                    Windowedfailurearray[i] = (failurearray[(i * Projectinterval) + j] ?? 0) + (Windowedfailurearray[i] ?? 0);
                }
            }

            return Windowedfailurearray;
        }
        bool ApplyFixedPlannedTasksToWindow(int window)
        {
            bool replacedalready = false;
            foreach (var task in PlannedTasks)
            {
                //if task falls within the window, is enabled, primary and fixed interval
                if (task.Disabled == false && task.Secondary == false && task.FixedInterval == true)
                {
                    if ((((((window) * Projectinterval) + Initialage) % task.TaskInterval) < Projectinterval) && !replacedalready)
                    {
                        if (task.Agereductionfactor > 0)
                        {
                            for (int j = 0; j < (task.TaskInterval / Projectinterval) + 1 && (window + j) < FailureProfile.Length; j++)
                            {
                                FailureProfile[window + j] = task.TaskPDF[j];
                            }
                        }
                        //Clear the Forecast Costs
                        for (int i = window; i < TimeWindows; i++)
                        {
                            task.Costs[i] = 0;
                            //Remove Later
                            plannedCosts[i] = 0;
                        }
                        //AND apply its costs (Planned fixed)
                        task.Costs[window] = task.TaskCost + (plannedCosts[window] ?? 0);
                        //Remove Later
                        plannedCosts[window] = task.TaskCost + (plannedCosts[window] ?? 0);

                        //Apply Effects Costs
                        foreach (var effect in Effects)
                        {
                            effect.Costs[window] = (effect.ApplyToPlanned) ? effect.EffectCost * effect.EffectProbability + (effect.Costs[window] ?? 0) : (effect.Costs[window] ?? 0);
                        }

                        effectsCosts[window] = task.EffectCost + effectsCosts[window] ?? 0;
                    }

                    if (task.Agereductionfactor >= 1) // because the planned tasks are sorted, then this picks up the first replacement. disabling subseuqent longer interval replacments in the same window.
                    {
                        replacedalready = true;
                    }
                }
            }
            return true;
        }
        bool ApplyInspectionTasksToWindow(int window)
        {
            //Check and Apply Inspections
            foreach (var task in InspectionTasks)
            {
                if ((((window * Projectinterval) % task.TaskInterval) < Projectinterval) && task.Disabled == false)
                {
                    //Add Occurance
                    task.Occurances[window] = task.Occurances[window] ?? 0 + 1;
                    //apply inspection costs
                    task.Costs[window] = task.Costs[window] ?? 0 + task.TaskCost;

                    //Remove Later
                    inspectionCosts[window] = inspectionCosts[window] ?? 0 + task.TaskCost;

                    //Apply Effects Costs
                    foreach (var effect in Effects)
                    {
                        effect.Costs[window] = (effect.ApplyToInspection) ? effect.EffectCost * effect.EffectProbability + (effect.Costs[window] ?? 0) : (effect.Costs[window] ?? 0);
                    }

                    effectsCosts[window] = effectsCosts[window] ?? 0 + task.EffectCost;

                    //then apply the associated enabled planned secondary tasks and costs
                    foreach (var ptask in PlannedTasks)
                    {
                        if (ptask.Disabled == false && ptask.Secondary)
                        {
                            double mitigatedfailures = 0;
                            for (int j = 0; (j < task.TaskInterval / Projectinterval) && j + window < TimeWindows; j++)
                            {
                                if (j < task.PFInterval / Projectinterval)
                                {
                                    mitigatedfailures += (FailureProfile[window + j] ?? 0) * task.DetectionProbability;
                                    FailureProfile[window + j] *= (1 - task.DetectionProbability);
                                }
                            }
                            for (int j = 0; j + window < TimeWindows; j++)
                            {
                                FailureProfile[window + j] += mitigatedfailures * ptask.TaskPDF[j]; //apply pdf
                            }

                            //Apply Planned Costs
                            ptask.Costs[window] = ptask.TaskCost * mitigatedfailures + (ptask.Costs[window] ?? 0);

                            //remove later
                            plannedCosts[window] = ptask.TaskCost * mitigatedfailures + (plannedCosts[window] ?? 0);

                            //Apply Effects Costs
                            foreach (var effect in Effects)
                            {
                                effect.Costs[window] = (effect.ApplyToPlanned) ? effect.EffectCost * effect.EffectProbability * mitigatedfailures + (effect.Costs[window] ?? 0) : (effect.Costs[window] ?? 0);
                            }

                            effectsCosts[window] = ptask.EffectCost * mitigatedfailures + effectsCosts[window] ?? 0;
                        }
                    }
                }
            }
            return true;
        }
        bool ApplyCorrectiveNFPTasksToWindow(int window)
        {
            //Apply corrective Costs
            if (CorrectiveTask != null) // if at least 1 corrective task exists
            {
                //Add one to the occurances
                CorrectiveTask.Occurances[window] = FailureProfile[window];
                CorrectiveTask.Costs[window] = FailureProfile[window] * CorrectiveTask.TaskCost ?? 0;

                //Remove this later
                correctiveCosts[window] = FailureProfile[window] * CorrectiveTask.TaskCost ?? 0;

                //Apply Effects Costs
                foreach (var effect in Effects)
                {
                    effect.Costs[window] = (effect.ApplyToCorrective) ? effect.EffectCost * effect.EffectProbability * FailureProfile[window] + (effect.Costs[window] ?? 0) : (effect.Costs[window] ?? 0);
                }
                effectsCosts[window] = (effectsCosts[window] ?? 0) + (FailureProfile[window] * CorrectiveTask.EffectCost);

                //then continue expansion -- Corrective Task Application
                for (int j = 0; (j + window) < TimeWindows; j++)
                {
                    FailureProfile[window + j] = FailureProfile[window + j] + (CorrectiveTask.TaskPDF[j] * FailureProfile[window]);
                    plannedCosts[window + j] = (plannedCosts[window + j] ?? 0) + ((CorrectiveTask.PDFPlannedCosts[j] ?? 0) * (FailureProfile[window] ?? 0));
                }
            }
            return true;
        }
        double?[] GetPDFFromHF(double?[] hazardfunction, bool returnPDF)
        {
            double?[] CDF = new double?[hazardfunction.Length];
            double?[] PDF = new double?[hazardfunction.Length];

            CDF[0] = hazardfunction[0] ?? 0;
            for (int i = 1; i < hazardfunction.Length; i++)
            {
                //
                CDF[i] = (hazardfunction[i] == null) ? CDF[i - 1] : ((hazardfunction[i] ?? 0) * (1 - CDF[i - 1])) + (CDF[i - 1]);
            }
            if (!returnPDF) return CDF;
            //build PDF off CDF
            PDF[0] = CDF[0];
            for (int i = 1; i < hazardfunction.Length; i++)
            {
                //3
                PDF[i] = CDF[i] - CDF[i - 1];
            }
            return PDF;
        }
        double?[] MultiplyArrays(double?[] CDF, double?[] Costs)
        {
            double?[] returned = new double?[Costs.Length];
            for (int i = 0; i < CDF.Length; i++)
            {
                returned[i] = Costs[i] * (1 - CDF[i]); //multiplies every element in Array 1 with Array 2
            }
            return returned;
        }
        double GetTotal(double?[] inputarray)
        {
            //Totalises the passed in array
            var sum = 0d;
            for (int i = 0; i < inputarray.Length; i++)
            {
                sum += inputarray[i] ?? 0;
            }
            return sum;
        }
        bool MainExpansionLoop()
        {
            if (ApplyInspectionAtTimeZero) ApplyInspectionTasksToWindow(0);

            //This loop expands the PDF over the lifetime

            for (int i = 1; i < TimeWindows; i++)
            {
                //Apply Inspections
                ApplyInspectionTasksToWindow(i);

                //Apply Fixed Planned
                ApplyFixedPlannedTasksToWindow(i);

                //Apply the Corrective and NonFixed Planned
                ApplyCorrectiveNFPTasksToWindow(i);

                //Check for errors
                /*if (FailureProfile[i] * CorrectiveTask.EffectCost != effectsCosts[i])
                {
                    int errror = 1;
                }*/

            }
            return true;
        }

        //Public Functions
        public bool Solve()
        {
            //Initialisations
            SolverInitialisations();

            //Sort the planned tasks by interval, this is to eliminate multiple replacements later. May have to sort by secondary for Agre reduction etc.
            PlannedTasks.Sort((x, y) => x.TaskInterval.CompareTo(y.TaskInterval));

            //Generate the Hazard Functions for all Tasks
            BuildHazardFunctions();

            //Add planned tasks to Hazard Functions for all Tasks
            OverlayPlannedTasksOnHFs();

            //Make Adjustments for initial Age
            MakeInitialAgeAdjustments();

            //Create the PDFs from HFs
            BuildPDFs();

            //Calculate Effects Costs
            //CalculateEffects();

            //Copy the PDF and store in the Output Failure Profile as the Initial Condition
            GetPDFFromHF(CorrectiveTask.AdjustedTaskHF, true).CopyTo(FailureProfile, 0);
            MultiplyArrays(GetPDFFromHF(CorrectiveTask.AdjustedTaskHF, false), CorrectiveTask.AdjustedHFPlannedCosts).CopyTo(plannedCosts, 0);
            //CorrectiveTask.TaskPDF.CopyTo(FailureProfile, 0);
            //CorrectiveTask.PDFPlannedCosts.CopyTo(plannedCosts, 0);

            //Apply all tasks and expand the failure and cost arrays
            MainExpansionLoop();

            //Totalise
            PlannedCostsTotal = GetTotal(plannedCosts);
            InspectionCostsTotal = GetTotal(inspectionCosts);
            foreach (var effect in Effects) //Sums up the split effects
            {
                EffectsCostsTotal += GetTotal(effect.Costs);
            }
            CorrectiveCostsTotal = GetTotal(correctiveCosts);
            CostsTotal = EffectsCostsTotal + InspectionCostsTotal + PlannedCostsTotal + CorrectiveCostsTotal;
            FailureProfileTotal = GetTotal(FailureProfile);

            return true; //Success
                         //Need to add a false capture
        }

        public double[] GetXaxis()
        {
            int timewindows = Projectlife / Projectinterval;
            double[] xaxis = new double[timewindows];
            for (int i = 0; i < timewindows; i++)
            {
                xaxis[i] = i * Projectinterval;
            }
            return xaxis;
        }
        public double[][] OptimiseIntervals(bool apply, int step, int start, int finish)
        {
            double[][] results = new double[PlannedTasks.Count + InspectionTasks.Count][];

            for (int k = 0; k < 2; k++)
            {
                int resultcounter = 0;
                foreach (var task in InspectionTasks)
                {
                    int BeforeInterval = task.TaskInterval;
                    Solve();
                    double LowestCost = CostsTotal;
                    int LowestCostInterval = BeforeInterval;
                    results[resultcounter] = new double[((finish - start) / step) + 1];

                    if (!task.Disabled)
                    {
                        Debug.WriteLine("Optimisation of {0} - Before Interval {1} - Before Cost {2}", task.Description, BeforeInterval, LowestCost);
                        for (int i = start; i < finish; i = i + step) //i is the task interval
                        {
                            task.TaskInterval = i;
                            Solve();
                            results[resultcounter][(i - start) / step] = CostsTotal;
                            if (CostsTotal < LowestCost)
                            {
                                LowestCost = CostsTotal;
                                LowestCostInterval = i;
                            }
                            //Debug.WriteLine("Optimisation of {0} - Testing Interval {1} - Testing Cost {2}", task.Description, task.TaskInterval, costsTotal);
                        }
                        Debug.WriteLine("Optimisation of {0} - After Interval {1} - After Cost {2}", task.Description, LowestCostInterval, LowestCost);
                    }
                    //Apply here if required
                    task.TaskInterval = (apply) ? LowestCostInterval : BeforeInterval;
                    resultcounter++;
                }

                foreach (var task in PlannedTasks)
                {
                    int BeforeInterval = task.TaskInterval;
                    Solve();
                    double LowestCost = CostsTotal;
                    int LowestCostInterval = BeforeInterval;
                    results[resultcounter] = new double[((finish - start) / step) + 1];

                    if (!task.Disabled && task.Secondary == false)
                    {
                        Debug.WriteLine("Optimization of {0} - Before Interval {1} - Before Cost {2}", task.Description, BeforeInterval, LowestCost);
                        for (int i = start; i < finish; i = i + step) //i is the task interval
                        {
                            task.TaskInterval = i;
                            Solve();
                            results[resultcounter][(i - start) / step] = CostsTotal;
                            if (CostsTotal < LowestCost)
                            {
                                LowestCost = CostsTotal;
                                LowestCostInterval = i;
                            }
                            //Debug.WriteLine("Optimisation of {0} - Testing Interval {1} - Testing Cost {2}", task.Description, task.TaskInterval, costsTotal);
                        }
                        Debug.WriteLine("Optimisation of {0} - After Interval {1} - After Cost {2}", task.Description, LowestCostInterval, LowestCost);
                    }
                    //Apply here if required
                    task.TaskInterval = (apply) ? LowestCostInterval : BeforeInterval;
                    resultcounter++;

                    //Sort the planned tasks by interval, this is to eliminate multiple replacements later. May have to sort by secondary for Agre reduction etc.
                    PlannedTasks.Sort((x, y) => x.TaskInterval.CompareTo(y.TaskInterval));
                }
            }



            Solve();
            Debug.WriteLine("Final Result : {0}", CostsTotal);
            return results;
        }
    }


    public class FMTask : BaseHandler1
    {
        public string Description { get; set; } //Stores the Description of the task
        public bool Disabled { get; set; } = false; //Is the task enabled or not
        public bool Secondary { get; set; } = false; //Is the task completed on a inspection that identifies a defect
        public bool FixedInterval { get; set; } = false; //Does this task occur on calander year (true) or age (false)
        public int TaskDuration { get; set; } = 0; //Duration of the task 
        public int TaskCost { get; set; } = 0;//Operational Cost of the task
        public int TaskInterval { get; set; } = 0;//Determines the Frequency
        public int PFInterval { get; set; } = 0; //Used for Inspection Tasks
        public double?[] Occurances { get; set; } //Holds the number of occurance results for each task
        public double?[] Costs { get; set; } //Holds the cost results for each task
        public double DetectionProbability { get; set; } = 1; //Used for Inspection Tasks
        public double Agereductionfactor { get; set; } = 1; //Used to determine the amound of reduction achieved (1 = back to brand new, 0 = does not affect)
        public double EffectCost { get; set; } = 0;
        public double?[] TaskPDF { get; set; }
        public double?[] TaskHF { get; set; }
        public double?[] AdjustedTaskHF { get; set; }
        public double?[] HFPlannedCosts { get; set; }
        public double?[] AdjustedHFPlannedCosts { get; set; }
        public double?[] PDFPlannedCosts { get; set; }

        bool isCheckedPlannedTasks;

        bool isCheckedInspectionTasks;

        

        public bool IsCheckedPlannedTasks
        {
            get
            {
                return isCheckedPlannedTasks;
            }

            set
            {
                isCheckedPlannedTasks = value;
                NotifyPropertyChanged("IsCheckedPlannedTasks");
            }
        }

        public bool IsCheckedInspectionTasks
        {
            get
            {
                return isCheckedInspectionTasks;
            }

            set
            {
                isCheckedInspectionTasks = value;
                NotifyPropertyChanged("IsCheckedInspectionTasks");
            }
        }
        

        //public bool OfflineWork { get; set; } 

        public List<Resource> Resources = new List<Resource>();
    }

    public class Effect : BaseHandler1
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string EffectType { get; set; }
        public double EffectCost { get; set; } = 0;
        public double EffectProbability { get; set; } = 0;
        public bool ApplyToCorrective { get; set; } = false;
        public bool ApplyToPlanned { get; set; } = false;
        public bool ApplyToInspection { get; set; } = false;
        public double?[] Occurances { get; set; }
        public double?[] Costs { get; set; }
        public bool IsCheckedEffect { get; set; } = false;

        bool isEffect;
        public bool IsEffect
        {
            get
            {
                return isEffect;
            }

            set
            {
                isEffect = value;
                NotifyPropertyChanged("IsEffect");
            }
        }
    }

    public class Resource
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string ResourceType { get; set; }
        public double ResourceCostOnce { get; set; }
        public double ResourceCostRate { get; set; }
        public double?[] Occurances { get; set; }
        public double?[] Costs { get; set; }
    }

    public class Decision
    {
        public string Description;
        public List<DecisionQuestions> Questions = new List<DecisionQuestions>();
        public List<DecisionActions> Actions = new List<DecisionActions>();
        public void ApplyDecision(Dictionary<string, string> AssetInfo, Model Mod)
        {
            bool AllQuestionsTrue = true;
            foreach (var Question in Questions)
            {
                switch (Question.decisiontype)
                {
                    case 1: //Stringcompare
                        if (AssetInfo[Question.sourcefieldid.ToUpper()].ToUpper() != Question.stringcomparison.ToUpper())
                        {
                            AllQuestionsTrue = false;
                        }
                        break;
                    case 2:
                        if (!((System.Convert.ToDouble(AssetInfo[Question.sourcefieldid]) <= Question.doublemax)
                            && (System.Convert.ToDouble(AssetInfo[Question.sourcefieldid]) >= Question.doublemin)))
                        {
                            AllQuestionsTrue = false;
                        }
                        break;
                    case 3:
                        if (System.Convert.ToBoolean(AssetInfo[Question.sourcefieldid]) != Question.expectedboolvalue)
                        {
                            AllQuestionsTrue = false;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (AllQuestionsTrue) //Apply Action
            {
                foreach (var Action in Actions)
                {
                    foreach (var location in Mod.Locations.Values)
                    {
                        if (location.Identifiers.Contains(Action.Identifier) && Action.actiontype == 1) location.Disabled = false;
                        foreach (var function in location.Functions.Values)
                        {
                            if (function.Identifiers.Contains(Action.Identifier) && Action.actiontype == 1) function.Disabled = false;
                            foreach (var ffailure in function.FunctionalFailures.Values)
                            {
                                if (ffailure.Identifiers.Contains(Action.Identifier) && Action.actiontype == 1) ffailure.Disabled = false;
                                foreach (var FM in ffailure.Failuremodes.Values)
                                {
                                    if (FM.Identifiers.Contains(Action.Identifier))
                                    {
                                        switch (Action.actiontype)
                                        {
                                            case 1:
                                                FM.Disabled = false;
                                                break;
                                            case 2:
                                                FM.Eta *= Action.Modifier;
                                                break;
                                            case 3:
                                                FM.Beta *= Action.Modifier;
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public class DecisionQuestions
    {
        public string stringcomparison;
        public double doublemin;
        public double doublemax;
        public string sourcefieldid;
        public bool expectedboolvalue;
        public int decisiontype; //public enum decisiontype { STRCMP,VALRNG,BOOL };
    }

    public class DecisionActions
    {
        public int Identifier;
        public double Modifier;
        public int actiontype;//public enum actiontype { ENABLE, ETAX, BETAX };

    }

    public class BaseHandler1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));


            }
        }

    }
}
