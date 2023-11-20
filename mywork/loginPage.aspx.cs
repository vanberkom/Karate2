using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Karate.mywork
{
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = Login1.UserName;
            string pass = Login1.Password;

            if (userName == "cat" && pass == "cat")
            {
                Response.Redirect("admin.aspx", true);
            }
            else if (userName == "dog" && pass == "dog")
            {
                Response.Redirect("instructor.aspx", true);
            }
            else
                Response.Redirect("loginPage.aspx", true);

        }
    }
}
