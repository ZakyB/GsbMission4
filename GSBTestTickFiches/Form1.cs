
using System;
using System.Windows.Forms;
namespace GSBTickFiches
{

    public partial class Form1 : Form
    {
        private GestionDate date = new GestionDate();
        private Methodes methode = new Methodes();
        private Boolean enCours = false;
        private Boolean tickTest = true;
        private int jour;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_start(object sender, EventArgs e)
        {
            if (enCours == true)
            {
                MessageBox.Show("L'opération est deja en cours !");
            }
            else
            {
                enCours = true;
                label2.Text = "L'application est en cours";
                TimerFichesCheck.Enabled = true;
            }
        }

        private void button_end(object sender, EventArgs e)
        {
            if (enCours == false)
            {
                MessageBox.Show("L'opération est deja en arret !");
            }
            else
            {
                enCours = false;
                label2.Text = "L'application est en arret.";
                TimerFichesCheck.Enabled = false;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            notifyIcon1.Icon = Icon;
            notifyIcon1.ShowBalloonTip(2000);

        }
        private void button_exit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_toNotifyIcon(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            jour = date.getJour();
            if (tickTest == true) { methode.updateFicheFrais("CL"); tickTest = false; return; }
            if (tickTest == false) { methode.updateFicheFrais("RB"); return; }
        }
    }

}
