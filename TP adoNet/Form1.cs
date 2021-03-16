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

namespace TP_adoNet
{
    public partial class Form1 : Form
    {
        private string unProvider = "127.0.0.1";
        private string dataBase = "gsb";
        private string uId = "root";
        private string mdp = "";
        private String id;
        private MySqlCommand oCom;
        private ConnexionSql maConnexion;
        private GestionDate date = new GestionDate();

        public Form1()
        {
            maConnexion = ConnexionSql.getInstance(unProvider, dataBase, uId, mdp);
            InitializeComponent();
        }
        private DataTable GetEmploye()
        {
            DataTable dt = new DataTable();
            maConnexion.openConnection();
            oCom = maConnexion.reqExec("Select * from fichefrais");
            
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
            string tardigrade = date.getMois();
            String req = "SELECT * FROM `fichefrais` WHERE mois like '" + tardigrade+"'";
            DataTable dt = new DataTable();
            maConnexion.openConnection();
            oCom = maConnexion.reqExec(req);
            MySqlDataReader reader = oCom.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            maConnexion.closeConnection();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tardigrade = date.getMois();
            String req = "SELECT * FROM `fichefrais` WHERE mois like '" + comboBox1.Text + "'";
            DataTable dt = new DataTable();
            maConnexion.openConnection();
            oCom = maConnexion.reqExec(req);
            MySqlDataReader reader = oCom.ExecuteReader();

            dt.Load(reader);
            dataGridView1.DataSource = dt;
            maConnexion.closeConnection();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
