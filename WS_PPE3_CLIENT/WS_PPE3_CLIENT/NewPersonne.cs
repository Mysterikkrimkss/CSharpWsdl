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
    public partial class NewPersonne : Form
    {
        public NewPersonne()
        {
            InitializeComponent();
        }
        MyWS_Ref.MyWSSoapClient monWS;
        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("voulez vous inserer","", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                monWS = new MyWS_Ref.MyWSSoapClient();
                var MaListe = monWS.Insert_Personnel(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text), textBox6.Text, dateTimePicker1.Value.ToString(), textBox8.Text, textBox9.PasswordChar.ToString());

                DialogResult dialogResult2 = MessageBox.Show("Nouveau client ajouter!", "", MessageBoxButtons.OK);
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.PasswordChar = '*';
        }
    }
}
