using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_adoNet;
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
                MessageBox.Show("L'opération est deja en cours !");
            }
            else
            {
                enCours = true;
                label2.Text = "L'application est en cours";
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
            if (jour <= 10) { methode.updateFicheFrais("CL"); }
            if (jour >= 20) { methode.updateFicheFrais("RB"); }
        }
    }
    
}
