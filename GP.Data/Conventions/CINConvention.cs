using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Conventions
{
    public class CINConvention : Convention
    {
        public CINConvention()
        {
            this.Properties().Where(C => C.Name.Equals("CIN"))
                .Configure(C => C.IsKey());
        }
    }
}
