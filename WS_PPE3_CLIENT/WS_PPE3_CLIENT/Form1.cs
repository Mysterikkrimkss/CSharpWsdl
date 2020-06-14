using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WS_PPE3_CLIENT
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
      );
        public Form1()
        {
            InitializeComponent();
           
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Show();
            Recherchename f2 = new Recherchename();
            f2.ShowDialog();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Show();
            listeMissions f2 = new listeMissions();
            f2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Show();
            Rechercheid f2 = new Rechercheid();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Show();
            NewPersonne f2 = new NewPersonne();
            f2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Show();
            supprpersonne f2 = new supprpersonne();
            f2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Show();
            ajoute_mission f2 = new ajoute_mission();
            f2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Show();
            connexion f2 = new connexion();
            f2.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            
           
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
