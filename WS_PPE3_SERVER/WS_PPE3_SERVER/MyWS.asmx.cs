using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace WS_PPE3_SERVER
{
    /// <summary>
    /// Description résumée de MyWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWS : System.Web.Services.WebService
    {
        public class C_Mission
        {
            public int Mission;
            public int Personne;
            public int Note_de_frais;
            public string Nom_Mission;
            public DateTime date_mission;
            public int persone_select;
        }

        public class C_PERSONNEL
        {
            public int id_perso;
            public string MATRICULE;
            public string NOM;
            public string PRENOM;
            public string RUE;
            public int CP;
            public string VILLE;
            public DateTime DATE_D_EMBAUCHE;
            public string email;
            public string password;
            public int isadmin;
        }

        public class C_Note_Frais
        {
            public int id_note_frais;
            public DateTime date_depot;
            public string nom_note;

        }

        public class C_Liste_Frais
        {
            public int id_ligne_frais;
            public string nom_ligne;
            public int total;
            public int donner;
        }



        [WebMethod]
        public List<C_Mission> Liste_Mission()
        {
            List<C_Mission> Les_Mission = new List<C_Mission>();

            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = CommandType.StoredProcedure;
            La_Requete.CommandText = "Liste_Mission_all";
            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            while (La_Reponse.Read())
            {
                C_Mission Une_Mission = new C_Mission();
                Une_Mission.Mission = La_Reponse.GetInt32(0);
                Une_Mission.Personne = La_Reponse.GetInt32(1);
                Une_Mission.Note_de_frais = La_Reponse.GetInt32(2);
                Une_Mission.Nom_Mission = La_Reponse.GetString(3);
                Une_Mission.date_mission = La_Reponse.GetDateTime(4);
                Une_Mission.persone_select = La_Reponse.GetInt32(5);

                Les_Mission.Add(Une_Mission);
            }
            La_Reponse.Close();
            La_Connection.Close();
            return Les_Mission;
        }

        [WebMethod]

        public List<C_PERSONNEL> Liste_Personnel()
        {
            List<C_PERSONNEL> Les_personnes = new List<C_PERSONNEL>();

            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = CommandType.StoredProcedure;
            La_Requete.CommandText = "Liste_Personnel";
            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            while (La_Reponse.Read())
            {
                C_PERSONNEL Une_personne = new C_PERSONNEL();
                Une_personne.id_perso = La_Reponse.GetInt32(0);
                Une_personne.MATRICULE = La_Reponse.GetString(1);
                Une_personne.NOM = La_Reponse.GetString(2);
                Une_personne.PRENOM = La_Reponse.GetString(3);
                Une_personne.RUE = La_Reponse.GetString(4);
                Une_personne.CP = La_Reponse.GetInt32(5);
                Une_personne.VILLE = La_Reponse.GetString(6);
                Une_personne.DATE_D_EMBAUCHE = La_Reponse.GetDateTime(7);
                Une_personne.email = La_Reponse.GetString(8);
                Une_personne.password = La_Reponse.GetString(9);
                Une_personne.isadmin = La_Reponse.GetInt32(10);


                Les_personnes.Add(Une_personne);
            }
            La_Reponse.Close();
            La_Connection.Close();
            return Les_personnes;
        }


        [WebMethod]

        public List<C_Mission> Missions_By_Name_User(string P_NOM)
        {
            List<C_Mission> Les_Missions = new List<C_Mission>();

            SqlConnection LaConnexion = new SqlConnection();
            LaConnexion.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";

            try
            {
                LaConnexion.Open();
                SqlCommand LaRequette = new SqlCommand();
                LaRequette.Connection = LaConnexion;
                LaRequette.CommandType = System.Data.CommandType.StoredProcedure;
                LaRequette.CommandText = "Get_Mission_By_Name";
                LaRequette.Parameters.Add("@P_NOM", SqlDbType.VarChar);
                LaRequette.Parameters["@P_NOM"].Value = P_NOM;

                SqlDataReader LaReponse = LaRequette.ExecuteReader();

                while (LaReponse.Read())
                {
                    C_Mission Une_Mission = new C_Mission();
                    Une_Mission.Mission = LaReponse.GetInt32(0);
                    Une_Mission.Personne = LaReponse.GetInt32(1);
                    Une_Mission.Note_de_frais = LaReponse.GetInt32(2);
                    Une_Mission.Nom_Mission = LaReponse.GetString(3);
                    Une_Mission.date_mission = LaReponse.GetDateTime(4);
                    Une_Mission.persone_select = LaReponse.GetInt32(5);

                    Les_Missions.Add(Une_Mission);




                }
                LaReponse.Close();
                LaConnexion.Close();

            }
            catch (SqlException P_Erreur)
            {
                Console.WriteLine(P_Erreur);
                Console.ReadLine();
                Environment.Exit(-1);

            }


            return Les_Missions;
        }


        [WebMethod]
        public string Insert_Personnel(string P_MATRICULE, string P_NOM, string P_PRENOM, string P_RUE, int P_CP, string P_VILLE, string P_DATE_D_EMBAUCHE, string P_email, string P_password)
        {
            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = System.Data.CommandType.StoredProcedure;
            La_Requete.CommandText = "insert_personnel";

            SqlParameter Parametre = new SqlParameter("@P_MATRICULE", SqlDbType.VarChar);
            Parametre.Direction = ParameterDirection.Input;
            Parametre.Value = P_MATRICULE;
            La_Requete.Parameters.Add(Parametre);

            SqlParameter Parametre2 = new SqlParameter("@P_NOM", SqlDbType.VarChar);
            Parametre2.Direction = ParameterDirection.Input;
            Parametre2.Value = P_NOM;
            La_Requete.Parameters.Add(Parametre2);

            SqlParameter Parametre3 = new SqlParameter("@P_PRENOM", SqlDbType.VarChar);
            Parametre3.Direction = ParameterDirection.Input;
            Parametre3.Value = P_PRENOM;
            La_Requete.Parameters.Add(Parametre3);

            SqlParameter Parametre4 = new SqlParameter("@P_RUE", SqlDbType.VarChar);
            Parametre4.Direction = ParameterDirection.Input;
            Parametre4.Value = P_RUE;
            La_Requete.Parameters.Add(Parametre4);

            SqlParameter Parametre5 = new SqlParameter("@P_CP", SqlDbType.Int);
            Parametre5.Direction = ParameterDirection.Input;
            Parametre5.Value = P_CP;
            La_Requete.Parameters.Add(Parametre5);

            SqlParameter Parametre6 = new SqlParameter("@P_VILLE", SqlDbType.VarChar);
            Parametre6.Direction = ParameterDirection.Input;
            Parametre6.Value = P_VILLE;
            La_Requete.Parameters.Add(Parametre6);

            SqlParameter Parametre7 = new SqlParameter("@P_DATE_D_EMBAUCHE", SqlDbType.Date);
            Parametre7.Direction = ParameterDirection.Input;
            Parametre7.Value = P_DATE_D_EMBAUCHE;
            La_Requete.Parameters.Add(Parametre7);

            SqlParameter Parametre8 = new SqlParameter("@P_email", SqlDbType.VarChar);
            Parametre8.Direction = ParameterDirection.Input;
            Parametre8.Value = P_email;
            La_Requete.Parameters.Add(Parametre8);

            SqlParameter Parametre9 = new SqlParameter("@P_password", SqlDbType.VarChar);
            Parametre9.Direction = ParameterDirection.Input;
            Parametre9.Value = P_password;
            La_Requete.Parameters.Add(Parametre9);

            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            La_Connection.Close();
            return "";
        }

        [WebMethod]

        public List<C_Mission> Missions_By_Id_User(string P_personne)
        {
            List<C_Mission> Les_Missions = new List<C_Mission>();

            SqlConnection LaConnexion = new SqlConnection();
            LaConnexion.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";

            try
            {
                LaConnexion.Open();
                SqlCommand LaRequette = new SqlCommand();
                LaRequette.Connection = LaConnexion;
                LaRequette.CommandType = System.Data.CommandType.StoredProcedure;
                LaRequette.CommandText = "Liste_Mission_By_Id";
                LaRequette.Parameters.Add("@P_personne", SqlDbType.Int);
                LaRequette.Parameters["@P_personne"].Value = P_personne;

                SqlDataReader LaReponse = LaRequette.ExecuteReader();

                while (LaReponse.Read())
                {
                    C_Mission Une_Mission = new C_Mission();
                    Une_Mission.Mission = LaReponse.GetInt32(0);
                    Une_Mission.Personne = LaReponse.GetInt32(1);
                    Une_Mission.Note_de_frais = LaReponse.GetInt32(2);
                    Une_Mission.Nom_Mission = LaReponse.GetString(3);
                    Une_Mission.date_mission = LaReponse.GetDateTime(4);
                    Une_Mission.persone_select = LaReponse.GetInt32(5);

                    Les_Missions.Add(Une_Mission);




                }
                LaReponse.Close();
                LaConnexion.Close();

            }
            catch (SqlException P_Erreur)
            {
                Console.WriteLine(P_Erreur);
                Console.ReadLine();
                Environment.Exit(-1);

            }


            return Les_Missions;
        }

        [WebMethod]
        public bool Je_Me_Connecte()
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

            Console.WriteLine("Identifiant");
            string Rep_ID = "user@user.user";
            Console.WriteLine("Mot de passe");
            string Rep_MDP = "$2y$10$tc3EVaZyBVSyHQmBMDRhzeI.qYS03mk8k7MidzhXQDT41cotNvTia";

            while (La_Reponse.Read())
            {
                string Saisie_ID = La_Reponse.GetString(0);
                string Saisie_MDP = La_Reponse.GetString(1);
                int isAdmin = La_Reponse.GetInt32(2);

                if (Saisie_ID == Rep_ID && Saisie_MDP == Rep_MDP)
                {
                    Console.WriteLine("Vous êtes connectés.");
                    Logged = true;
                    return Logged;
                }
                else
                {
                    Console.WriteLine("Connection échoué, MDP ou ID faux");
                    Logged = false;
                    return Logged;
                }
            }
            La_Reponse.Close();
            La_Connection.Close();
            Logged = false;
            return Logged;
        }

        [WebMethod]
        public string Update_Personnel(string P_MATRICULE, string P_NOM, string P_PRENOM, string P_RUE, int P_CP, string P_VILLE, string P_DATE_D_EMBAUCHE, string P_email, string P_password)
        {
            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = System.Data.CommandType.StoredProcedure;
            La_Requete.CommandText = "insert_personnel";

            SqlParameter Parametre = new SqlParameter("@P_MATRICULE", SqlDbType.VarChar);
            Parametre.Direction = ParameterDirection.Input;
            Parametre.Value = P_MATRICULE;
            La_Requete.Parameters.Add(Parametre);

            SqlParameter Parametre2 = new SqlParameter("@P_NOM", SqlDbType.VarChar);
            Parametre2.Direction = ParameterDirection.Input;
            Parametre2.Value = P_NOM;
            La_Requete.Parameters.Add(Parametre2);

            SqlParameter Parametre3 = new SqlParameter("@P_PRENOM", SqlDbType.VarChar);
            Parametre3.Direction = ParameterDirection.Input;
            Parametre3.Value = P_PRENOM;
            La_Requete.Parameters.Add(Parametre3);

            SqlParameter Parametre4 = new SqlParameter("@P_RUE", SqlDbType.VarChar);
            Parametre4.Direction = ParameterDirection.Input;
            Parametre4.Value = P_RUE;
            La_Requete.Parameters.Add(Parametre4);

            SqlParameter Parametre5 = new SqlParameter("@P_CP", SqlDbType.Int);
            Parametre5.Direction = ParameterDirection.Input;
            Parametre5.Value = P_CP;
            La_Requete.Parameters.Add(Parametre5);

            SqlParameter Parametre6 = new SqlParameter("@P_VILLE", SqlDbType.VarChar);
            Parametre6.Direction = ParameterDirection.Input;
            Parametre6.Value = P_VILLE;
            La_Requete.Parameters.Add(Parametre6);

            SqlParameter Parametre7 = new SqlParameter("@P_DATE_D_EMBAUCHE", SqlDbType.Date);
            Parametre7.Direction = ParameterDirection.Input;
            Parametre7.Value = P_DATE_D_EMBAUCHE;
            La_Requete.Parameters.Add(Parametre7);

            SqlParameter Parametre8 = new SqlParameter("@P_email", SqlDbType.VarChar);
            Parametre8.Direction = ParameterDirection.Input;
            Parametre8.Value = P_email;
            La_Requete.Parameters.Add(Parametre8);

            SqlParameter Parametre9 = new SqlParameter("@P_password", SqlDbType.VarChar);
            Parametre9.Direction = ParameterDirection.Input;
            Parametre9.Value = P_password;
            La_Requete.Parameters.Add(Parametre9);

            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            La_Connection.Close();
            return "";
        }

        [WebMethod]

        public string Delete_user(string P_user)
        {
            SqlConnection LaConnexion = new SqlConnection();
            LaConnexion.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";


            LaConnexion.Open();
            SqlCommand LaRequette = new SqlCommand();
            LaRequette.Connection = LaConnexion;
            LaRequette.CommandType = System.Data.CommandType.StoredProcedure;
            LaRequette.CommandText = "Delete_Personnel";
            LaRequette.Parameters.Add("@P_NOM", SqlDbType.VarChar);
            LaRequette.Parameters["@P_NOM"].Value = P_user;



            SqlDataReader LaReponse = LaRequette.ExecuteReader();
            return "";
        }



        [WebMethod]

        public string insert_mission(int ID_personne, int id_note_de_frais, string nom, string date_mission, int id_per)
        {
            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = System.Data.CommandType.StoredProcedure;
            La_Requete.CommandText = "Insert_Mission";

            SqlParameter Parametre9 = new SqlParameter("@ID_personne", SqlDbType.Int);
            Parametre9.Direction = ParameterDirection.Input;
            Parametre9.Value = ID_personne;
            La_Requete.Parameters.Add(Parametre9);

            SqlParameter Parametre1 = new SqlParameter("@id_note_de_frais", SqlDbType.Int);
            Parametre1.Direction = ParameterDirection.Input;
            Parametre1.Value = id_note_de_frais;
            La_Requete.Parameters.Add(Parametre1);

            SqlParameter Parametre2 = new SqlParameter("@nom", SqlDbType.VarChar);
            Parametre2.Direction = ParameterDirection.Input;
            Parametre2.Value = nom;
            La_Requete.Parameters.Add(Parametre2);

            SqlParameter Parametre3 = new SqlParameter("@date_mission", SqlDbType.Date);
            Parametre3.Direction = ParameterDirection.Input;
            Parametre3.Value = date_mission;
            La_Requete.Parameters.Add(Parametre3);

            SqlParameter Parametre4 = new SqlParameter("@id_per", SqlDbType.Int);
            Parametre4.Direction = ParameterDirection.Input;
            Parametre4.Value = id_per;
            La_Requete.Parameters.Add(Parametre4);

            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            La_Connection.Close();
            return "";

        }

        [WebMethod]

        public string insert_Frais(string DATE_DEPOT, string nom)
        {
            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = System.Data.CommandType.StoredProcedure;
            La_Requete.CommandText = "Insert_Frais";

            SqlParameter Parametre = new SqlParameter("@DATE_DEPOT", SqlDbType.Date);
            Parametre.Direction = ParameterDirection.Input;
            Parametre.Value = DATE_DEPOT;
            La_Requete.Parameters.Add(Parametre);

            SqlParameter Parametre1 = new SqlParameter("@nom", SqlDbType.VarChar);
            Parametre1.Direction = ParameterDirection.Input;
            Parametre1.Value = nom;
            La_Requete.Parameters.Add(Parametre1);

            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            La_Connection.Close();
            return "";

        }

        [WebMethod]

        public string insert_ligne_Frais(int nom_frais, string nom,int total,int donner)
        {
            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = System.Data.CommandType.StoredProcedure;
            La_Requete.CommandText = "insert_ligne_frais";

            SqlParameter Parametre = new SqlParameter("@nom_frais", SqlDbType.Int);
            Parametre.Direction = ParameterDirection.Input;
            Parametre.Value = nom_frais;
            La_Requete.Parameters.Add(Parametre);

            SqlParameter Parametre1 = new SqlParameter("@nom", SqlDbType.VarChar);
            Parametre1.Direction = ParameterDirection.Input;
            Parametre1.Value = nom;
            La_Requete.Parameters.Add(Parametre1);

            SqlParameter Parametre2 = new SqlParameter("@total", SqlDbType.Int);
            Parametre2.Direction = ParameterDirection.Input;
            Parametre2.Value = total;
            La_Requete.Parameters.Add(Parametre2);

            SqlParameter Parametre3 = new SqlParameter("@donner", SqlDbType.Int);
            Parametre3.Direction = ParameterDirection.Input;
            Parametre3.Value = donner;
            La_Requete.Parameters.Add(Parametre3);

            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            La_Connection.Close();
            return "";

        }

        //[WebMethod]
        //public List<C_List_Frais> list_frais()
        //{

        //    List<C_List_Frais> Les_frais = new List<C_List_Frais>();

        //    SqlConnection La_Connection = new SqlConnection();
        //    La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
        //    La_Connection.Open();

        //    SqlCommand La_Requete = new SqlCommand();
        //    La_Requete.Connection = La_Connection;
        //    La_Requete.CommandType = CommandType.StoredProcedure;
        //    La_Requete.CommandText = "liste_frais";
        //    SqlDataReader La_Reponse = La_Requete.ExecuteReader();

        //    while (La_Reponse.Read())
        //    {
        //        C_List_Frais Un_frais = new C_List_Frais();
        //        Un_frais.id_note_frais = La_Reponse.GetInt32(0);
        //        Un_frais.date_depot = La_Reponse.GetDateTime(1);
        //        Un_frais.nom_note = La_Reponse.GetString(2);
        //        Un_frais.id_ligne_frais = La_Reponse.GetInt32(3);
        //        Un_frais.nom_ligne = La_Reponse.GetString(4);
        //        Un_frais.total = La_Reponse.GetInt32(5);
        //        Un_frais.donner = La_Reponse.GetInt32(6);               

        //        Les_frais.Add(Un_frais);
        //    }
        //    La_Reponse.Close();
        //    La_Connection.Close();
        //    return Les_frais;



        [WebMethod]
        public List<C_Note_Frais> List_note_frais()
        {

            List<C_Note_Frais> Les_frais = new List<C_Note_Frais>();

            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = CommandType.StoredProcedure;
            La_Requete.CommandText = "liste_note_frais";
            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            while (La_Reponse.Read())
            {
                C_Note_Frais Un_frais = new C_Note_Frais();
                Un_frais.id_note_frais = La_Reponse.GetInt32(0);
                Un_frais.date_depot = La_Reponse.GetDateTime(1);
                Un_frais.nom_note = La_Reponse.GetString(2);


                Les_frais.Add(Un_frais);
            }
            La_Reponse.Close();
            La_Connection.Close();
            return Les_frais;

        }

        [WebMethod]
        public List<C_Liste_Frais> list_ligne_frais()
        {

            List<C_Liste_Frais> Les_frais = new List<C_Liste_Frais>();

            SqlConnection La_Connection = new SqlConnection();
            La_Connection.ConnectionString = @"Data Source=DESKTOP-KVG156O\SQLEXPRESS;Initial Catalog=PPE3;Integrated Security=True";
            La_Connection.Open();

            SqlCommand La_Requete = new SqlCommand();
            La_Requete.Connection = La_Connection;
            La_Requete.CommandType = CommandType.StoredProcedure;
            La_Requete.CommandText = "liste_list_frais";
            SqlDataReader La_Reponse = La_Requete.ExecuteReader();

            while (La_Reponse.Read())
            {
                C_Liste_Frais Un_frais = new C_Liste_Frais();
                Un_frais.id_ligne_frais = La_Reponse.GetInt32(0);
                Un_frais.nom_ligne = La_Reponse.GetString(1);
                Un_frais.total = La_Reponse.GetInt32(2);
                Un_frais.donner = La_Reponse.GetInt32(3);

                Les_frais.Add(Un_frais);
            }
            La_Reponse.Close();
            La_Connection.Close();
            return Les_frais;

        }


    }
}
