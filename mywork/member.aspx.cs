using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Karate.mywork
{
    public partial class member : System.Web.UI.Page
    {
        string firstname = ;
        string lastname;

        string conn;
        KarateDBDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {

            conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\austi\\Source\\Repos\\vanberkom\\Karate2\\App_Data\\KarateSchool(1) (1).mdf\";Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateDBDataContext(conn);

            var members = from x in dbcon.NetUsers
                          join y in dbcon.Members on x.UserID equals y.Member_UserID
                          select new { y.MemberFirstName, y.MemberLastName, y.MemberPhoneNumber, y.MemberDateJoined };

            memberGridView.DataSource = members;
            memberGridView.DataBind();

            Label2.Text = firstname;
            Label4.Text = lastname;
        }
    }
}