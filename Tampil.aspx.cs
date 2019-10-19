using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace SHEUjianOnline
{
    public partial class Tampil : System.Web.UI.Page
    {
        //int s_int_nomor = 0;
        int s_int_nomor_x;
        String nosoal;
        String tekssoal;
        String nomorsoal;
        String imagename;
        //String img;
        //String strBase64;
        protected void Page_Load(object sender, EventArgs e)
        {
            LblIdSoal.Text = Request.QueryString["no"];
            Lbl_Soal.Text = Request.QueryString["soalnya"];
            Lbl_nomor.Text = Request.QueryString["nomornya"];
            LblURL.Text = Request.QueryString["gambarnya"];
            Image1.ImageUrl = Request.QueryString["gambarnya"];
            
            if (LblURL.Text != "")
                {
                    Image1.Visible = true;
                }
            else
                {
                    Image1.Visible = false;
                }

          
                               
        }

        // ------------------------ timer --------------------------
        static int ss = 2;
        public void my_timer_tick(object sender, EventArgs e)
        {
            
            ss--;
          
            if (ss < 0)
            {

                ss = 0;
                if (ss == 0)
                {

                    if (Lbl_nomor.Text == "7")
                    {
                        Response.Redirect("KunciJawaban.aspx?s_str_generatedID=" + Session["i_str_generatedID"]);

                    }
                    tSoal();
                  
                    Response.Redirect("Tampil.aspx?s_str_generatedID=" + Session["i_str_generatedID"] + "&no=" + nosoal + "&soalnya=" + tekssoal + "&nomornya=" + nomorsoal + "&gambarnya=" + imagename);

                }
                else 
                {
                    Response.Redirect("KunciJawaban.aspx?s_str_generatedID=" + Session["i_str_generatedID"]);
                }
            }
            else
            {
                Lbl_timer.Text = "00 : " + "00 : " + ss.ToString();
            }

        }

        //-----------------------------Looping SOAL-------------------------------
        public void tSoal()
        {
            ss = 5;
                    
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_SHE"].ConnectionString);

            Btn_Submit.Visible = false;
            s_int_nomor_x = Convert.ToInt32(LblIdSoal.Text);

            try
            {
                SqlCommand cmdSoal = new SqlCommand("cusp_Tampil_Soal_ByNomor", con);
                cmdSoal.CommandType = CommandType.StoredProcedure;
                cmdSoal.Parameters.AddWithValue("@nomor", s_int_nomor_x);
                cmdSoal.Parameters.AddWithValue("@generatedID", Session["i_str_generatedID"].ToString());
                LblGenerateID.Text = Session["i_str_generatedID"].ToString();

                
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataReader dr_soal = cmdSoal.ExecuteReader();
                while (dr_soal.Read())
                {

                    nosoal = dr_soal["id_soal"].ToString();
                    tekssoal = dr_soal["deskripsi_soal"].ToString();
                    LblIdSoal.Text = dr_soal["id_soal"].ToString();
                    imagename = dr_soal["image_url"].ToString();

                }

        
                Image1.DataBind();
                
                con.Close();
                Lbl_Soal.Text = tekssoal;
                LblURL.Text = imagename;

                SqlDataSource1.DataBind();
                Rbl_jawabanA.DataBind();

                
                //------------ mengambil nomor urut ----------------------------------------------------------------------

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmdNomorSoal = new SqlCommand("dbo.cusp_Tampil_Soal_Row_Number", con);
                cmdNomorSoal.CommandType = CommandType.StoredProcedure;
                cmdNomorSoal.Parameters.AddWithValue("@id_soal", nosoal);

                SqlDataReader dr_nomor = cmdNomorSoal.ExecuteReader();

                while (dr_nomor.Read())
                {

                  nomorsoal = dr_nomor["nomor"].ToString();

                }
                con.Close();

                
           

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            Btn_AnswerKey.Visible = true;

        }



        

        public void Btn_Submit_Click(object sender, EventArgs e)
        {
          
                    ss = 10;
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_SHE"].ConnectionString);

                     s_int_nomor_x = 0;
                     s_int_nomor_x = Convert.ToInt32(LblIdSoal.Text.ToString());
                                      
                        try
                        {
                            SqlCommand cmdSoal = new SqlCommand("cusp_Tampil_Soal_ByNomor", con);
                            cmdSoal.CommandType = CommandType.StoredProcedure;
                            cmdSoal.Parameters.AddWithValue("@nomor", s_int_nomor_x);
                            cmdSoal.Parameters.AddWithValue("@generatedID", Session["i_str_generatedID"].ToString());
                            LblGenerateID.Text = Session["i_str_generatedID"].ToString();

                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }

                            SqlDataReader dr_soal = cmdSoal.ExecuteReader();
                            
                                while (dr_soal.Read())
                                {                                    
                                    nosoal = dr_soal["id_soal"].ToString();
                                    tekssoal = dr_soal["deskripsi_soal"].ToString();
                                    LblIdSoal.Text = dr_soal["id_soal"].ToString();
                                }
                          
                        
                            con.Close();
                            Lbl_Soal.Text = tekssoal;

                            SqlDataSource1.DataBind();
                            Rbl_jawabanA.DataBind();

       //------------ mengambil nomor urut ----------------------------------------------------------------------

                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }

                            SqlCommand cmdNomorSoal = new SqlCommand("dbo.cusp_Tampil_Soal_Row_Number",con);
                            cmdNomorSoal.CommandType = CommandType.StoredProcedure;
                            cmdNomorSoal.Parameters.AddWithValue("@id_soal", nosoal);

                            SqlDataReader dr_nomor = cmdNomorSoal.ExecuteReader();

                            while (dr_nomor.Read())
                            {
                                nomorsoal = dr_nomor["nomor"].ToString();
                                            
                            
                            }
                            con.Close();

       //---------------- menampilkan gambar soal -------------------------------------------------------------
                            
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            SqlCommand cmdGambarSoal = new SqlCommand("dbo.cusp_Tampil_SoalGambar_ByIdSoal", con);
                            cmdGambarSoal.CommandType = CommandType.StoredProcedure;
                            cmdGambarSoal.Parameters.AddWithValue("@id_soal", nosoal);

                            con.Open();
                            SqlDataAdapter sda = new SqlDataAdapter();
                            sda.SelectCommand = cmdGambarSoal;
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            Image1.DataBind();
                            SqlDataReader drGambar = cmdGambarSoal.ExecuteReader();
                            while (drGambar.Read())
                            {
                                imagename = drGambar["name"].ToString();

                            }
                            con.Close();

                            LblURL.Text = imagename.ToString();
                            

                            Btn_AnswerKey.Visible = true;

                            Response.Redirect("Tampil.aspx?s_str_generatedID=" + Session["i_str_generatedID"] + "&no=" + nosoal + "&soalnya=" + tekssoal + "&nomornya=" + nomorsoal + "&gambarnya=" + imagename);                            
                            
                        }
                        
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }

            }
                     
        protected void Btn_AnswerKey_Click(object sender, EventArgs e)
        {
            Response.Redirect("KunciJawaban.aspx?s_str_generatedID=" + Session["i_str_generatedID"]);
                      
        }

  
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Btn_Pilih_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_SHE"].ConnectionString);
                string selectValue1 = this.Rbl_jawabanA.SelectedValue.ToString();
                int s_int_id_soal_x = Convert.ToInt32(LblIdSoal.Text.ToString());
                int s_int_id_jawaban_x = Convert.ToInt32(selectValue1.ToString());
                
            

                using (SqlCommand cmdEvaluasi = new SqlCommand("cusp_insert_data_evaluasi", con))
                {

                    cmdEvaluasi.CommandType = CommandType.StoredProcedure;
                    cmdEvaluasi.Parameters.AddWithValue("@id_soal", s_int_id_soal_x);
                    cmdEvaluasi.Parameters.AddWithValue("@id_jawaban", s_int_id_jawaban_x);
                    cmdEvaluasi.Parameters.AddWithValue("@generatedID", Session["i_str_generatedID"].ToString());


                    cmdEvaluasi.Connection = con;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmdEvaluasi.ExecuteNonQuery();
                    con.Close();
                    //Response.Redirect("Tampil.aspx?s_str_generatedID=" + Session["i_str_generatedID"] + "&no=" + nosoal + "&soalnya=" + tekssoal + "&nomornya=" + nomorsoal + "&gambarnya=" + imagename);                            
                    
                }
            }
         

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }




        }

      
        
    
}