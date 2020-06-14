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
    public partial class Rechercheid : Form
    {
        public Rechercheid()
        {
            InitializeComponent();
        }

        MyWS_Ref.MyWSSoapClient monWS;

        private void button1_Click(object sender, EventArgs e)
        {
            monWS = new MyWS_Ref.MyWSSoapClient();

            var MaListe = monWS.Missions_By_Id_User(textBox1.Text);

            dataGridView1.DataSource = MaListe;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
