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
    public partial class ajoute_mission : Form
    {
        public ajoute_mission()
        {
            InitializeComponent();
        }

        MyWS_Ref.MyWSSoapClient monWS;
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("voulez vous inserer", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //monWS = new MyWS_Ref.MyWSSoapClient();
                //var MaListe = monWS.insert_mission(dateTimePicker1.Value.ToString(), textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));

                //DialogResult dialogResult2 = MessageBox.Show("Nouveau client ajouter!", "", MessageBoxButtons.OK);
                //Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}
