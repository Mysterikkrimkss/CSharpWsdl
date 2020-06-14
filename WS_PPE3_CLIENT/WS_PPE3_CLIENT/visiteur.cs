using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace WS_PPE3_CLIENT
{
    public partial class visiteur : Form
    {
        public visiteur()
        {
            InitializeComponent();
        }

        private void visiteur_Load(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            
           
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Show();
            ajoute_frais f2 = new ajoute_frais();
            f2.ShowDialog();
        }
    }
}
