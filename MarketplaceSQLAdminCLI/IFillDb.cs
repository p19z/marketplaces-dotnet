using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSQLAdminCLI
{
    internal interface IFillDb
    {
        internal void CoreDatabase_v0();
        internal void Population_v0();
    }

    internal interface ICleanDb
    {
        internal void CoreDatabase_v0();
        internal void Population_v0();
    }
}
