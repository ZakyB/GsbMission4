using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TP_adoNet
{
    public partial class Form1 : Form
    {
        private MySqlCommand oCom;
        private ConnexionSql maConnexion;
        private GestionDate date = new GestionDate();
        private string dateActuel;

        public Form1()
        {
            maConnexion = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
            InitializeComponent();
        }
        private DataTable GetEmploye()
        {
            DataTable dt = new DataTable();

            oCom = maConnexion.reqExec("Select * from fichefrais");
            maConnexion.openConnection();
            MySqlDataReader reader = oCom.ExecuteReader();

            dt.Load(reader);
            /*for (int i = 0; i < reader.FieldCount; i++)
            {
                dt.Columns.Add(reader.GetName(i));
            }
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                for (int i = 0;i< reader.FieldCount; i++)
                {
                    dr[i] = reader.GetValue(i);
                }
                dt.Rows.Add(dr);
            } */
            maConnexion.closeConnection();
            return dt;
        }
        private DataTable GetListeMois()
        {
            DataTable dt = new DataTable();
            maConnexion.openConnection();
            oCom = maConnexion.reqExec("SELECT DISTINCT mois FROM `fichefrais` ORDER BY mois");

            MySqlDataReader reader = oCom.ExecuteReader();
            dt.Load(reader);
            maConnexion.closeConnection();
            return dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetEmploye();
            comboBox1.DataSource = GetListeMois();
            comboBox1.DisplayMember = "mois";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateActuel = date.getMois();
            String req = "SELECT * FROM `fichefrais` WHERE mois like '" + dateActuel + "'";
            DataTable dt = new DataTable();
            maConnexion.openConnection();
            oCom = maConnexion.reqExec(req);
            MySqlDataReader reader = oCom.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            maConnexion.closeConnection();
            label1.Text = dateActuel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateActuel = comboBox1.Text;
            String req = "SELECT * FROM `fichefrais` WHERE mois like '" + dateActuel + "'";
            DataTable dt = new DataTable();
            maConnexion.openConnection();
            oCom = maConnexion.reqExec(req);
            MySqlDataReader reader = oCom.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            maConnexion.closeConnection();
            label1.Text = dateActuel;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button_precedant(object sender, EventArgs e)
        {
            if (!date.Equals(""))
            {
                dateActuel = date.getMoisPrecedant(dateActuel);
                String req = "SELECT * FROM `fichefrais` WHERE mois like '" + dateActuel + "'";
                DataTable dt = new DataTable();
                maConnexion.openConnection();
                oCom = maConnexion.reqExec(req);
                MySqlDataReader reader = oCom.ExecuteReader();

                dt.Load(reader);
                dataGridView1.DataSource = dt;
                maConnexion.closeConnection();
                label1.Text = dateActuel;
            }

        }

        private void button_suivant(object sender, EventArgs e)
        {
            if (!date.Equals(""))
            {
                dateActuel = date.getMoisSuivant(dateActuel);
                String req = "SELECT * FROM `fichefrais` WHERE mois like '" + dateActuel + "'";
                DataTable dt = new DataTable();
                maConnexion.openConnection();
                oCom = maConnexion.reqExec(req);
                MySqlDataReader reader = oCom.ExecuteReader();

                dt.Load(reader);
                dataGridView1.DataSource = dt;
                maConnexion.closeConnection();
                label1.Text = dateActuel;
            }
        }
    }
}
