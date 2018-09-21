using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeibullSolver_WPF.HelperClasses;
using WeibullSolverLibrary;
using WeibullSolverLibrary.Common_Code;

namespace WeibullSolver_WPF.Model
{
    public class Assets_Information : BaseHandler
    {
        string uniqueID;
        bool isHasFans;
        bool isRequiresLube;
        bool isStatutory;
        string corrosiveEnvironment;
        string people;

        public string UniqueID
        {
            get
            {
                return uniqueID;
            }

            set
            {
                uniqueID = value;
                NotifyPropertyChanged("UniqueID");
            }
        }

        public bool IsHasFans
        {
            get
            {
                return isHasFans;
            }

            set
            {
                isHasFans = value;
                NotifyPropertyChanged("IsHasFans");
            }
        }

        public bool IsRequiresLube
        {
            get
            {
                return isRequiresLube;
            }

            set
            {
                isRequiresLube = value;
                NotifyPropertyChanged("IsRequiresLube");
            }
        }

        public bool IsStatutory
        {
            get
            {
                return isStatutory;
            }

            set
            {
                isStatutory = value;
                NotifyPropertyChanged("IsStatutory");
            }
        }

        public string CorrosiveEnvironment
        {
            get
            {
                return corrosiveEnvironment;
            }

            set
            {
                corrosiveEnvironment = value;
                NotifyPropertyChanged("CorrosiveEnvironment");
            }
        }

        public string People
        {
            get
            {
                return people;
            }

            set
            {
                people = value;
                NotifyPropertyChanged("People");
            }
        }
    }
}
