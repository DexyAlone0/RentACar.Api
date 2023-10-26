using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Common.Enums
{
    public enum EngineCapacityType
    {
        [Description("1300cc ve altı")]
        cc1300 = 0,
        [Description("1301cc ve 1600cc arası")]
        cc1301and1600 = 1,
        [Description("1601cc ve 1800cc arası")]
        cc1601and1800 = 2,
        [Description("1801cc ve 2000cc arası")]
        cc1801and2000 = 3,
        [Description("2000cc ve üstü")]
        cc2001 = 4,
    }
}
