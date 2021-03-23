using System;

namespace GSBTickFiches
{
    class GestionDate
    {
        public String getMois()
        {
            //recupere le mois actuel
            var mois = DateTime.Now;
            var pouet = mois.Date.ToString("yyyyMM");
            return pouet;
        }
        public int getJour()
        {
            //Recupere le jour du mois actuel
            var jour = DateTime.Now;
            var res = Int16.Parse(jour.Date.ToString("dd"));
            return res;
        }
        public String getMoisPrecedant(String date)
        {
            //Recupere le mois précédant de celui entré en parametre
            DateTime odate = DateTime.ParseExact(date, "yyyyMM", null);
            String test = odate.Date.AddMonths(-1).ToString("yyyyMM");
            return test;
        }
        public String getMoisSuivant(String date)
        {
            //Recupere le mois suivant de celui entré en parametre
            DateTime odate = DateTime.ParseExact(date, "yyyyMM", null);
            String test = odate.Date.AddMonths(1).ToString("yyyyMM");
            return test;
        }
    }
}
