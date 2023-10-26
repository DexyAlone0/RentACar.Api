using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Common.Enums
{
    public enum CountOfSeat
    {
        [Description("İki Koltuk")]
        Two = 2,
        [Description("Üç Koltuk")]
        Three = 3,
        [Description("Dört Koltuk")]
        Four = 4,
        [Description("Beş Koltuk")]
        Five = 5,
        [Description("Altı Koltuk")] 
        Six = 6,
        [Description("Yedi Koltuk")] 
        Seven = 7,
    }
}
