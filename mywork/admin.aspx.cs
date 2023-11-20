using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Karate.mywork
{
    public partial class admin : System.Web.UI.Page
    {
        string conn = "";
        KarateDBDataContext dbcon;

        // Fills both the gridviews with the members and instructors
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\luke.vanberkom\\Source\\Repos\\vanberkom\\Karate2\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateDBDataContext(conn);
            
            // Fills the member gridview
            var members = from x in dbcon.NetUsers
                          join y in dbcon.Members on x.UserID equals y.Member_UserID
                          select new { y.MemberFirstName, y.MemberLastName, y.MemberPhoneNumber, y.MemberDateJoined };

            memberGridView.DataSource = members;
            memberGridView.DataBind();

            // Fills the instructor grid view
            var instructors = from net in dbcon.NetUsers
                              join instructor in dbcon.Instructors on net.UserID equals instructor.InstructorID
                              select new { instructor.InstructorFirstName, instructor.InstructorLastName };

            instructorGridView.DataSource = instructors;
            instructorGridView.DataBind();
        }

        // Adding a member to the table
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                NetUser user = new NetUser();
                user.UserID = 

            }
        }

        // Adding a instructor to the table
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        // Will delete a user based on the id given
        protected void deleteButton_Click(object sender, EventArgs e)
        {

        }

        protected void assignButton_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void instructorGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}