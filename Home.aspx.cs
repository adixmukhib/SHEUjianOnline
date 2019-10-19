using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHEUjianOnline
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSoal_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_SHEConnectionString"].ConnectionString);
            try {
                    string s = "Truncate Table tb_soal_generate";
                    SqlCommand Com = new SqlCommand(s, con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    Com.ExecuteNonQuery();
              
                    using (SqlCommand cmd = new SqlCommand("cusp_Generate_Soal_byJabatan", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idJabatan", 1);
                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                

                Response.Redirect("Soal.aspx");         
                }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }


        }


        protected void ButtonOperator_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_SHEConnectionString"].ConnectionString);
            try
            {
                string s = "Truncate Table tb_soal_generate";
                SqlCommand Com = new SqlCommand(s, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                Com.ExecuteNonQuery();

                using (SqlCommand cmd = new SqlCommand("cusp_Generate_Soal_byJabatan", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idJabatan",2);
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                }


                Response.Redirect("Soal.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ButtonMekanik_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_SHEConnectionString"].ConnectionString);
            try
            {
                string s = "Truncate Table tb_soal_generate";
                SqlCommand Com = new SqlCommand(s, con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                Com.ExecuteNonQuery();

                using (SqlCommand cmd = new SqlCommand("cusp_Generate_Soal_byJabatan", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idJabatan", 3);
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                }


                Response.Redirect("Soal.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        
    }
}