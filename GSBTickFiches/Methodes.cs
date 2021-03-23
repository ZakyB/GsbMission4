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
        /// <summary>
        /// Methode qui fait la mise a jour des fiches
        /// </summary>
        /// <param name="etat"></param>
        public void updateFicheFrais(string etat)
        {
            //Récupération du mois précédant
            String date = Date.getMois();
            date = Date.getMoisPrecedant(date);
            //Ouverture de la BDD
            try
            { maConnexion.openConnection(); }
            catch (MySqlException e)
            {
                MessageBox.Show("Erreur de connexion !");
            }
            //Requete UPDATE
            String req = "update ficheFrais set idEtat = '" + etat + "' where mois = '" + date + "'";
            //Condition supplémentaire en fonction du parametre
            if (etat.Equals("CL"))
            {
                req = req + ("AND idEtat = 'CR'");
            }
            if (etat.Equals("RB"))
            {
                req = req + ("AND idEtat = 'VA'");
            }
            //Execution de la requete
            oCom = maConnexion.reqExec(req);
            oCom.ExecuteNonQuery();
            //Fermeture de la BDD
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
