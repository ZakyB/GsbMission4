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
        private string mdp = "root";
        private String id;
        private MySqlCommand oCom;
        private ConnexionSql maConnexion;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetEmploye();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
            {
                string message = "Il manque une ou plusieurs valeurs";
                string caption = "Erreur détecté";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                maConnexion.openConnection();
                String req = "UPDATE `employe` SET `nom`='" + textBox1.Text + "',`prenom`='" + textBox2.Text + "',`salaire`='" + textBox3.Text + "' WHERE id = " + id;
                oCom = maConnexion.reqExec(req);
                oCom.ExecuteNonQuery();
                maConnexion.closeConnection();
                dataGridView1.DataSource = GetEmploye();
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
            {
                string message = "Il manque une ou plusieurs valeurs";
                string caption = "Erreur détecté";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                maConnexion.openConnection();
                String req = "DELETE FROM `employe` WHERE id="+id;
                oCom = maConnexion.reqExec(req);
                oCom.ExecuteNonQuery();
                maConnexion.closeConnection();
                dataGridView1.DataSource = GetEmploye();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
            {
                string message = "Il manque une ou plusieurs valeurs";
                string caption = "Erreur détecté";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                maConnexion.openConnection();
                String req = "INSERT INTO `employe`(`nom`, `prenom`, `salaire`) VALUES('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"');";
                oCom = maConnexion.reqExec(req);
                oCom.ExecuteNonQuery();
                maConnexion.closeConnection();
                dataGridView1.DataSource = GetEmploye();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            id = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
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
