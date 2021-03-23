using System;
using System.Windows.Forms;
namespace GSBTickFiches
{

    public partial class Form1 : Form
    {
        private GestionDate date = new GestionDate();
        private Methodes methode = new Methodes();
        private Boolean enCours = false;
        private int jour;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_start(object sender, EventArgs e)
        {
            if (enCours == true)
            {
                //S'affiche si l'opération est deja en cours
                MessageBox.Show("L'opération est deja en cours !");
            }
            else
            {
                //Activation de l'application
                enCours = true;
                label2.Text = "L'application est en cours";
                TimerFichesCheck.Enabled = true;
            }
        }

        private void button_end(object sender, EventArgs e)
        {
            if (enCours == false)
            {
                //S'affiche si l'opération est deja en arret
                MessageBox.Show("L'opération est deja en arret !");
            }
            else
            {
                //Arret de l'application
                enCours = false;
                label2.Text = "L'application est en arret.";
                TimerFichesCheck.Enabled = false;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //Transforme le bouton de fermeture de la fenetre en passage en tache de fond
            e.Cancel = true;
            this.Hide();
            notifyIcon1.Icon = Icon;
            notifyIcon1.ShowBalloonTip(2000);

        }
        private void button_exit(object sender, EventArgs e)
        {//Bouton de fermeture de l'application
            Environment.Exit(0);
        }

        private void button_toNotifyIcon(object sender, EventArgs e)
        {
            //Passage notification
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Refait passer l'application devant
            this.Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Vérification de la date du jour pour savoir dans quelle intervalle on est
            jour = date.getJour();
            if (jour <= 10) { methode.updateFicheFrais("CL"); }
            if (jour >= 20) { methode.updateFicheFrais("RB"); }
        }
    }

}
