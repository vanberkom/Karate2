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
        public int overallID;

       
        string conn;
        KarateDBDataContext dbcon;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\austi\\Source\\Repos\\vanberkom\\Karate2\\App_Data\\KarateSchool(1) (1).mdf\";Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateDBDataContext(conn);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                // Sets the strings from the login control
                string userName = Login1.UserName;
                string pass = Login1.Password;
                string type = "";
                // Getting userID from user name and password
                var selectID = from x in dbcon.NetUsers
                               where x.UserName == userName && x.UserPassword == pass
                               select x;
                // Sets the id
                foreach (var x in selectID)
                {
                    overallID = x.UserID;
                    type = x.UserType;
                }

                if (type == "Member")
                {
                    Response.Redirect("member.aspx", true);
                }
                else if (type == "Administrator")
                {
                    Response.Redirect("admin.aspx", true);
                } 
                else if (type == "Instructor")
                {
                    Response.Redirect("instructor.aspx", true);
                }
                else
                    Response.Redirect("loginPage.aspx", true);
            } catch
            {
                
            }
        }
    }
}
