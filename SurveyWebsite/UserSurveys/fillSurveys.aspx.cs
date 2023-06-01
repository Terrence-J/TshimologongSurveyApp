using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SurveyWebsite.UserSurveys
{
    public partial class fillSurveys : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Sur_DB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Btnsubmit_Click(object sender, EventArgs e)
        {
            string checkBoxSelect = "";
            int i;
            for (i = 0; i < CheckBoxListOptions.Items.Count;i++ )
            {
                if (CheckBoxListOptions.Items[i].Selected)
                {
                    if (checkBoxSelect == "")
                    {
                        checkBoxSelect = CheckBoxListOptions.Items[i].Text;
                    }
                    else
                    {
                        checkBoxSelect += ", " + CheckBoxListOptions.Items[i].Text;
                    }
                }

            }

            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO tableSurvey (sur_surname,sur_firstName,sur_cNumber,sur_date,sur_age,sur_faveFood,sur_eatOut,sur_watchMovies,sur_watchTv,sur_listenRadio) values('" + TextBoxSurname.Text + "','" + TextBoxfName.Text + "','" + TextBoxNumber.Text + "','" + TextBoxDate.Text + "','" + TextBoxAge.Text + "','" + checkBoxSelect + "','" + RadioButtonFOOD.SelectedValue + "','" + RadioButtonFilms.SelectedValue + "','" + RadioButtonTelevision.SelectedValue + "','" + RadioButtonFm.SelectedValue + "')";
                cmd.ExecuteNonQuery();
                lbl1.Visible = true;
                lbl1.Text = "Successfully Submitted!";
                
               
            }
            catch (Exception ex)
            {
                conn.Close();
                lblerrorr.Visible = true;
                lblerrorr.Text = "Could Not Submit. Contact with the Database admin";
            }

        }

    }
  }