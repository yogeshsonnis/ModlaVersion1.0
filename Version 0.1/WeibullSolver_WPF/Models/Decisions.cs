using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeibullSolver_WPF.HelperClasses;
using WeibullSolverLibrary;

namespace WeibullSolver_WPF.Model
{
    public class Decisions : BaseHandler
    {
        public class HasFans : BaseHandler
        {
            string has_Fans;
            string true_Value;

            public string Has_Fans
            {
                get
                {
                    return has_Fans;
                }

                set
                {
                    has_Fans = value;
                    NotifyPropertyChanged("Has_Fans");
                }
            }
            public string True_Value
            {
                get
                {
                    return true_Value;
                }

                set
                {
                    true_Value = value;
                    NotifyPropertyChanged("True_Value");
                }
            }
        }
        public class RequiresLube : BaseHandler
        {
            string requires_Lube;
            string true_Value;

            public string Requires_Lube
            {
                get
                {
                    return requires_Lube;
                }

                set
                {
                    requires_Lube = value;
                    NotifyPropertyChanged("Requires_Lube");
                }
            }

            public string True_Value
            {
                get
                {
                    return true_Value;
                }

                set
                {
                    true_Value = value;
                    NotifyPropertyChanged("True_Value");
                }
            }
        }
        public class Statutory : BaseHandler
        {
            string statutory_;
            string true_Value;

            public string Statutory_
            {
                get
                {
                    return statutory_;
                }

                set
                {
                    statutory_ = value;
                    NotifyPropertyChanged("Statutory_");
                }
            }

            public string True_Value
            {
                get
                {
                    return true_Value;
                }

                set
                {
                    true_Value = value;
                    NotifyPropertyChanged("True_Value");
                }
            }
        }
        public class PeopleExplosure : BaseHandler
        {
            string people_Explosure;
            string true_Value;

            public string People_Explosure
            {
                get
                {
                    return people_Explosure;
                }

                set
                {
                    people_Explosure = value;
                    NotifyPropertyChanged("People_Explosure");
                }
            }

            public string True_Value
            {
                get
                {
                    return true_Value;
                }

                set
                {
                    true_Value = value;
                    NotifyPropertyChanged("True_Value");
                }
            }
        }
    }
}
