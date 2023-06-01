using System;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SurveyWebsite.UserSurveys
{
    public partial class SurveyResult : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Sur_DB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Total number of surveys completed/taken
                conn.Open();
                string sumSurveyQuery = "SELECT COUNT(sur_id) FROM tableSurvey";
               SqlCommand surveyTotal = new SqlCommand(sumSurveyQuery, conn);
                int totSurvey = Convert.ToInt32(surveyTotal.ExecuteScalar());
                lblTotsur.Visible = true;
                lblTotsur.Text = " =  " + totSurvey;

                //Average age of people who participated on the surveys
                string avAge = " SELECT SUM(sur_age) FROM tableSurvey";
                SqlCommand ageCom = new SqlCommand(avAge, conn);
                int averAge = Convert.ToInt32(ageCom.ExecuteScalar());
                lblSurage.Visible = true;
                lblSurage.Text = " = " + (averAge / totSurvey);

                //Oldest person who participated in the surveys
                string maxAge = "SELECT sur_firstName, sur_age  FROM tableSurvey WHERE sur_age  =(SELECT MAX(sur_age)  FROM tableSurvey) ";
               SqlCommand ageCommand = new SqlCommand(maxAge, conn);
                string oldestPer = ageCommand.ExecuteScalar().ToString();
                lblSurOld.Visible = true;
                lblSurOld.Text = " = " +  oldestPer;

                //Youngest person who participated in the survey
                string minAge = "SELECT sur_firstName FROM tableSurvey WHERE sur_age  =(SELECT MIN(sur_age)  FROM tableSurvey)";
                SqlCommand minAgeC = new SqlCommand(minAge, conn);
                string youngPer = minAgeC.ExecuteScalar().ToString();
                lblSuryoung.Visible = true;
                lblSuryoung.Text =" = " + youngPer;

                //The Total Percentage of people who like PIZZA
                string pizza = "SELECT COUNT(sur_id) FROM tableSurvey WHERE sur_faveFood = ' Pizza '";
                SqlCommand pizzaSQLC = new SqlCommand(pizza, conn);
                double percentagePizza = Convert.ToDouble(pizzaSQLC.ExecuteScalar());
                lblSurpizza.Visible = true;
                lblSurpizza.Text = (percentagePizza) + " %" ;

                //The Percentage of peolple who like PASTA
                string pasta = "SELECT COUNT(sur_id) FROM tableSurvey WHERE sur_faveFood =' Pasta '";
                SqlCommand pastaSQLC = new SqlCommand(pasta, conn);
                double percentagePasta = Convert.ToDouble(pastaSQLC.ExecuteScalar());
                lblSurpasta.Visible = true;
                lblSurpasta.Text = (percentagePasta / totSurvey) * 100 + " %";

                //The Percentage of peolple who like Pap and wors
                string pap = "SELECT COUNT(sur_id) FROM tableSurvey WHERE sur_faveFood =' Pap and wors '";
                SqlCommand papSQLC = new SqlCommand(pap, conn);
                double percentPap = Convert.ToDouble(papSQLC.ExecuteScalar());
                lblSurpap.Visible = true;
                lblSurpap.Text = (percentPap / totSurvey) * 100 + " %";

                //The Percentage of peolple who like to eat out
                string EatOut = "SELECT COUNT(sur_id) FROM tableSurvey WHERE sur_eatOut =' Strongly Agree'";
                SqlCommand EatOutSQLC = new SqlCommand(EatOut, conn);
                double EatOutPercent = Convert.ToDouble(EatOutSQLC.ExecuteScalar());
                EatOutPercent = (EatOutPercent / overallSurvey) * 100;
                double eatRoundPercent = Math.Round((Double)EatOutPercent, 1);
                lblSureatout.Visible = true;
                lblSureatout.Text = eatRoundPercent + " %";

                //The Percentage of peolple who like to watch movies
                string movies = "SELECT COUNT(sur_id) FROM tableSurvey WHERE sur_watchMovies =' Strongly Agree' OR sur_watchMovies =' Agree' ";
                SqlCommand moviesSQLC = new SqlCommand(movies, conn);
                double moviesPercentage = Convert.ToDouble(moviesSQLC.ExecuteScalar());
                moviesPercentage = (moviesPercentage / overallSurvey) * 100;
                double moviesRoundPercent = Math.Round((Double)moviesPercentage, 1);
                lblSurmovies.Visible = true;
                lblSurmovies.Text = moviesRoundPercent + " %";

                //The Percentage of peolple who like to watch tv
                string tv = "SELECT COUNT(sur_id) FROM tableSurvey WHERE sur_watchTv =' Strongly Agree' OR sur_watchTv =' Agree'";
                SqlCommand tvSQLC = new SqlCommand(tv, conn);
                double tvPercent = Convert.ToDouble(tvSQLC.ExecuteScalar());
                tvPercent = (tvPercent / overallSurvey) * 100;
                double tvRoundPercent = Math.Round((Double)tvPercent, 1);
                lblSurtv.Visible = true;
                lblSurtv.Text = tvRoundPercent + " %";

                //Percentage of peolple who like to listen to radio
                string radio = "SELECT COUNT(sur_id) FROM tableSurvey WHERE sur_listenRadio =' Strongly Agree' OR sur_listenRadio =' Agree'";
                SqlCommand radioSQLC = new SqlCommand(radio, conn);
                double radioPercentage = Convert.ToDouble(radioSQLC.ExecuteScalar());
                radioPercentage = (radioPercentage / totSurvey) * 100;
                double radioRoundPercent = Math.Round((Double)radioPercentage, 1);
                lblSurradio.Visible = true;
                lblSurradio.Text = radioRoundPercent + " %";


            }

            catch (Exception ex)
            {
                lblerror.Visible = true;
                lblerror.Text = "Could Not Retrieve data. Contact Support team";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}