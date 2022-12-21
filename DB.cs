using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marafon
{
    public static class Util
    {
        private static MarathonSkillsEntities database;

        public static MarathonSkillsEntities Db 
        { get
            {
                if(database ==null)
                    database = new MarathonSkillsEntities();    
                return database;

            }
                
                
                
        }
    }
}
