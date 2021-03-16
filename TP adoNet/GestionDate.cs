using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_adoNet
{
    class GestionDate
    {
        public String getMois()
        {
            var mois = DateTime.Now;
            var pouet = mois.Date.ToString("yyyyMM");
            return pouet;
        }
        public String getMoisPrecedant()
        {
            var mois = DateTime.Now;
            var pouet = mois.AddMonths(-1).ToString("yyyyMM");
            return pouet;
        }
    }
}
