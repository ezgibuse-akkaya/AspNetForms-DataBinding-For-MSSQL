using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBinding
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(Cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT CityId,CityName,Country FROM City", con);
                    con.Open();
                    DropDownList1.DataSource = cmd.ExecuteReader();
                    //DropDownList1.DataTextField = "CityName";
                    //DropDownList1.DataValueField = "CityId";
                    DropDownList1.DataBind();

                }
            }
        }
    }


}