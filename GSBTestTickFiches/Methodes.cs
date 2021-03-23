using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace GSBTickFiches
{
    class Methodes
    {
        private GestionDate Date = new GestionDate();
        private MySqlCommand oCom;
        private ConnexionSql maConnexion = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
        public void updateFicheFrais(string etat)
        {
            String date = Date.getMois();
            date = Date.getMoisPrecedant(date);
            try
            { maConnexion.openConnection(); }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de connexion !");
            }
            String req = "update ficheFrais set idEtat = '" + etat + "' where mois = '" + date + "'";
            if (etat.Equals("CL"))
            {
                req = req + ("AND idEtat = 'CR'");
            }
            if (etat.Equals("RB"))
            {
                req = req + ("AND idEtat = 'VA'");
            }
            oCom = maConnexion.reqExec(req);
            oCom.ExecuteNonQuery();
            try
            { maConnexion.closeConnection(); }
            catch (MySqlException e)
            {
                MessageBox.Show("Erreur de déconnexion !");
            }
            return;
        }
    }
}
