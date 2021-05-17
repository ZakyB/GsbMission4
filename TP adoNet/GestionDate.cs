
using System;

namespace TP_adoNet
{
    public class GestionDate
    {
        /// <summary>
        /// récupére le mois actuel
        /// </summary>
        /// <returns>retourne la date sous le format "yyyyMM"</returns>
        public String getMois()
        {
            var mois = DateTime.Now;
            var pouet = mois.Date.ToString("yyyyMM");
            return pouet;
        }

        /// <summary>
        /// récupére le mois précedent
        /// </summary>
        /// <param name="date"></param>
        /// <returns>retourne le mois précédent le mois sélectionner</returns>
        public String getMoisPrecedant(String date)
        {
            DateTime odate = DateTime.ParseExact(date, "yyyyMM", null);
            String test = odate.Date.AddMonths(-1).ToString("yyyyMM");
            return test;
        }

        /// <summary>
        /// récupére le mois suivant
        /// </summary>
        /// <param name="date"></param>
        /// <returns>retourne le mois suivant le mois sélectionner</returns>
        public String getMoisSuivant(String date)
        {
            DateTime odate = DateTime.ParseExact(date, "yyyyMM", null);
            String test = odate.Date.AddMonths(1).ToString("yyyyMM");
            return test;
        }


        /// <summary>
        /// récupére le jour actuel
        /// </summary>
        /// <returns>retourne le jour actuel sous le format suivant : "dd"</returns>
        public int getJour()
        {
            var jour = DateTime.Now;
            var res = Int16.Parse(jour.Date.ToString("dd"));
            return res;
        }
    }
}
