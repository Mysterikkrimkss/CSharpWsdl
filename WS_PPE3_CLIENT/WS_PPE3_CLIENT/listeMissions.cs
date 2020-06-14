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
    public partial class listeMissions : Form
    {
        public listeMissions()
        {
            InitializeComponent();
        }
        MyWS_Ref.MyWSSoapClient monWS;
        private void listeMissions_Load(object sender, EventArgs e)
        {
            monWS = new MyWS_Ref.MyWSSoapClient();

            var MaListe = monWS.Liste_Mission();

            dataGridView1.DataSource = MaListe;
        }


    }
}
