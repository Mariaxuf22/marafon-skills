using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marafon
{
    public class RunnerInfo
    {
        public Runner runner { get; set; }
        public Registration registration { get; set; }
        public string info
        { 
        
            get
            {
                return string.Format("{0} {1} - {2} {{3}}", runner.User.LastName, runner.Country.CountryName);
            }
        
        
        
        }
    }
}
