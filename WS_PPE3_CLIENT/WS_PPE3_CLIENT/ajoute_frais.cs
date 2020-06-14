using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WS_PPE3_CLIENT
{
    public partial class ajoute_frais : Form
    {
        public ajoute_frais()
        {
            InitializeComponent();
        }

        MyWS_Ref.MyWSSoapClient monWS;

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("voulez vous inserer", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                monWS = new MyWS_Ref.MyWSSoapClient();
                var MaListe = monWS.insert_Frais(dateTimePicker1.Value.ToString(), textBox1.Text);

                DialogResult dialogResult2 = MessageBox.Show("frais ajouter!", "", MessageBoxButtons.OK);
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void ajoute_frais_Load(object sender, EventArgs e)
        {
            monWS = new MyWS_Ref.MyWSSoapClient();

            var MaListe = monWS.List_note_frais();

            dataGridView1.DataSource = MaListe;

            monWS = new MyWS_Ref.MyWSSoapClient();

            var MaListe2 = monWS.list_ligne_frais();

            dataGridView2.DataSource = MaListe2;

            monWS = new MyWS_Ref.MyWSSoapClient();



            MyWS_Ref.C_Note_Frais[] Frais = monWS.List_note_frais();


            string[] nom_note = new string[Frais.Length];
            for (int index = 0; index < Frais.Length; index++)
            {
                nom_note[index] = Frais[index].nom_note;
            }


            comboBox1.Items.AddRange(nom_note);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("voulez vous inserer", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                monWS = new MyWS_Ref.MyWSSoapClient();
                var MaListe = monWS.insert_ligne_Frais(Convert.ToInt32(textBox5.Text), textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));

                DialogResult dialogResult2 = MessageBox.Show("frais ajouter!", "", MessageBoxButtons.OK);
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    //MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
                    textBox5.Text = dataGridView1.CurrentCell.Value.ToString();
                }
            }
        }
    }
}
