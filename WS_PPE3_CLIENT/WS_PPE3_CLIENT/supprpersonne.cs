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
    public partial class supprpersonne : Form
    {
        public supprpersonne()
        {
            InitializeComponent();
        }
        MyWS_Ref.MyWSSoapClient monWS;
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("voulez vous supprimer ?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                monWS = new MyWS_Ref.MyWSSoapClient();
                var MaListe = monWS.Delete_user(comboBox1.Text);

                DialogResult dialogResult2 = MessageBox.Show("Client Supprimer!", "", MessageBoxButtons.OK);
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void supprpersonne_Load(object sender, EventArgs e)
        {
            monWS = new MyWS_Ref.MyWSSoapClient();

           

            MyWS_Ref.C_PERSONNEL[] Personnel = monWS.Liste_Personnel();
            

            string[] Nom = new string[Personnel.Length];
            for (int index = 0; index < Personnel.Length; index++)
            {
                Nom[index] = Personnel[index].NOM;
            }


            comboBox1.Items.AddRange(Nom);
        }
    }
}
