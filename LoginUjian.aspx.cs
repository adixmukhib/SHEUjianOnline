using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Data;
using System.Configuration;



namespace SHEUjianOnline
{
    public partial class LoginUjian : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_SHE"].ConnectionString);
            SqlCommand cmdDel = new SqlCommand("TRUNCATE TABLE dbo.tb_r_nomer_soal", con);
            SqlCommand cmdDel2 = new SqlCommand("TRUNCATE TABLE dbo.tb_evaluasi_ujian", con);

            con.Open();
            cmdDel.ExecuteNonQuery();
            cmdDel2.ExecuteNonQuery();                            
            
            string cekuser = "SELECT COUNT(*) FROM [tb_admin] WHERE nrp ='" + txtUsername.Text + "'";
            SqlCommand query = new SqlCommand(cekuser, con);
            int jumlah = Convert.ToInt32(query.ExecuteScalar().ToString());
            con.Close();
            if (jumlah == 1)
            {
                con.Open();
                string cekpassword = "SELECT password FROM [tb_admin] WHERE nrp ='" + txtUsername.Text + "'";
                SqlCommand passquery = new SqlCommand(cekpassword, con);
                string password = passquery.ExecuteScalar().ToString();
                con.Close();
                if (password == txtPassword.Text)
                {
                    ddlAkses.Enabled = true;
                    ddlAkses.Items.Clear();
                    ddlAkses.Items.Add("Select Profile");
                    ddlAkses.Items.Add("nonom");
                    ddlAkses.Items.Add("operator");
                    ddlAkses.Items.Add("mekanik");
                }
                else
                {
                    Response.Write("Password Salah");
                }
            }
            else
            {

                Response.Write("Username tidak ditemukan");
            }

        }

        protected void ddlAkses_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_SHE"].ConnectionString);
            
            
            if (ddlAkses.SelectedValue == "nonom") 
            {

                try
                {

                    //string i_str_generatedID = "";

                    using (SqlCommand cmd = new SqlCommand("cusp_Generate_Soal_byJabatan", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idJabatan", 1);
                        cmd.Parameters.AddWithValue("@nrp", txtUsername.Text);
                        cmd.Parameters.Add("@generatedID", SqlDbType.VarChar, 100);
                        cmd.Parameters["@generatedID"].Direction = ParameterDirection.Output;
                        
                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();

                        Session["i_str_generatedID"] = cmd.Parameters["@generatedID"].Value.ToString();
                        

                    }


                    Response.Redirect("Tampil.aspx?s_str_generatedID=" + Session["i_str_generatedID"] + "&no=0");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
            else if (ddlAkses.SelectedValue == "operator")
            {

                try
                {
                    //string i_str_generatedID = "";

                    using (SqlCommand cmd = new SqlCommand("cusp_Generate_Soal_byJabatan", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idJabatan", 2);
                        cmd.Parameters.AddWithValue("@nrp", txtUsername.Text);
                        cmd.Parameters.Add("@generatedID", SqlDbType.VarChar, 100);
                        cmd.Parameters["@generatedID"].Direction = ParameterDirection.Output;

                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();

                        Session["i_str_generatedID"] = cmd.Parameters["@generatedID"].Value.ToString();
                       

                    }


                    Response.Redirect("Tampil.aspx?s_str_generatedID=" + Session["i_str_generatedID"] + "&no=0");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }

            else if (ddlAkses.SelectedValue == "mekanik")
            {

                try
                {
                    //string i_str_generatedID = "";

                    using (SqlCommand cmd = new SqlCommand("cusp_Generate_Soal_byJabatan", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idJabatan", 3);
                        cmd.Parameters.AddWithValue("@nrp", txtUsername.Text);
                        cmd.Parameters.Add("@generatedID", SqlDbType.VarChar, 100);
                        cmd.Parameters["@generatedID"].Direction = ParameterDirection.Output;

                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();

                        Session["i_str_generatedID"] = cmd.Parameters["@generatedID"].Value.ToString();
                    }


                    Response.Redirect("Tampil.aspx?s_str_generatedID=" + Session["i_str_generatedID"] + "&no=0");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }

                

        }
        
    }
}