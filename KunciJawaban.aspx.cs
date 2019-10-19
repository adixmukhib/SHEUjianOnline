using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHEUjianOnline
{
    public partial class KunciJawaban : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        private void pv_str_tampil_kuncijawaban()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_SHE"].ConnectionString);

            //s_int_nomor_x = 0;
            //s_int_nomor_x = Convert.ToInt32(LblIdSoal.Text.ToString());

            try
            {
                SqlCommand cmdKunci = new SqlCommand("cusp_Tampil_Kunci_Jawaban", con);
                SqlCommand cmdNilai = new SqlCommand("SELECT * FROM dbo.vw_nilai_evaluasi", con);
                
                cmdKunci.CommandType = CommandType.StoredProcedure;
                //cmdKunci.Parameters.AddWithValue("@generatedID", "lae12135201802280826");
                cmdKunci.Parameters.AddWithValue("@generatedID", Session["i_str_generatedID"].ToString());
                LblGenerateID.Text = Session["i_str_generatedID"].ToString();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                
                //SqlDataReader dr_kunci = cmdKunci.ExecuteReader();
                //while (dr_kunci.Read())
                //{
                //    LblKunci.Text = dr_kunci["deskripsi_jawaban"].ToString();
                //    //LblIdSoal.Text = dr_soal["id_soal"].ToString();

                //}

                SqlDataSource1.DataBind();
                GridView1.DataBind();
                SqlDataSource2.DataBind();
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }



        }

        protected void Btn_Show_Click(object sender, EventArgs e)
        {
            pv_str_tampil_kuncijawaban();
        }


    }
}