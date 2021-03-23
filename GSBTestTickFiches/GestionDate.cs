using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBTickFiches
{
    class GestionDate
    {
        public String getMois()
        {
            var mois = DateTime.Now;
            var pouet = mois.Date.ToString("yyyyMM");
            return pouet;
        }
        public int getJour()
        {
            var jour = DateTime.Now;
            var res = Int16.Parse(jour.Date.ToString("dd"));
            return res;
        }
        public String getMoisPrecedant(String date)
        {
            DateTime odate = DateTime.ParseExact(date, "yyyyMM", null);
            String test = odate.Date.AddMonths(-1).ToString("yyyyMM");
            return test;
        }
        public String getMoisSuivant(String date)
        {
            DateTime odate = DateTime.ParseExact(date, "yyyyMM", null);
            String test = odate.Date.AddMonths(1).ToString("yyyyMM");
            return test;
        }
    }
}
