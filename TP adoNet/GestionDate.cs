using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_adoNet
{
    public class GestionDate
    {
        public String getMois()
        {
            var mois = DateTime.Now;
            var pouet = mois.Date.ToString("yyyyMM");
            return pouet;
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


        public void updateFicheFrais(string etat, string date) {

            date = getMoisPrecedant(date);
            String req = "update ficheFrais set idEtat = '" + etat + "' where mois = '" + date + "'"; 
            if (etat == "RB"){
                req = req + ("AND idEtat = VA");
            }
            return;

        }
    }
}
