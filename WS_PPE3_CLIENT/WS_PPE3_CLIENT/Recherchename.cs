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
    public partial class Recherchename : Form
    {
        public Recherchename()
        {
            InitializeComponent();
        }

        MyWS_Ref.MyWSSoapClient monWS;

        

        private void button1_Click(object sender, EventArgs e)
        {
            monWS = new MyWS_Ref.MyWSSoapClient();

            var MaListe = monWS.Missions_By_Name_User(textBox1.Text);

            dataGridView1.DataSource = MaListe;
        }
    }
}
