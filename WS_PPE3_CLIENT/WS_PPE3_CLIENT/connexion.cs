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
    public partial class connexion : Form
    {
        public connexion()
        {
            InitializeComponent();
        }
        MyWS_Ref.MyWSSoapClient monWS;

        public void button1_Click(object sender, EventArgs e)
        {

            bool Logged = false;
            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = System.Data.CommandType.StoredProcedure;
            La_Requete.CommandText = "Me_connecte";
            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            
            string Rep_ID = textBox1.Text;           
            string Rep_MDP = textBox2.Text;

            while (La_Reponse.Read())
            {
                string Saisie_ID = La_Reponse.GetString(0);
                string Saisie_MDP = La_Reponse.GetString(1);
                int isAdmin = La_Reponse.GetInt32(2);
                string non = La_Reponse.GetString(3);

                if (Saisie_ID == Rep_ID && Saisie_MDP == Rep_MDP)
                {
                    
                    
                    if (isAdmin == 1)
                    {

                        Form1 f2 = new Form1();
                        f2.Show();
                        
                    }
                    else
                    {
                        
                        visiteur f2 = new visiteur();
                        f2.Show();
                        
                    }                   
                    Logged = true;
                    
                }
                
            }
            La_Reponse.Close();
            La_Connection.Close();

            
            
        }
        
       
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
