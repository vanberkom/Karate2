using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Karate.mywork
{
    public partial class instructor : System.Web.UI.Page
    {

        string firstname;
        string lastname;

        string conn;
        KarateDBDataContext dbcon;
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\luke.vanberkom\\Source\\Repos\\vanberkom\\Karate2\\App_Data\\KarateSchool(1) (1).mdf\";Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateDBDataContext(conn);

            id = Convert.ToInt32((string)Session["user"]);

            var grid = from x in dbcon.Instructors
                       where x.InstructorID == id
                       join y in dbcon.Sections on x.InstructorID equals y.Instructor_ID
                       join mem in dbcon.Members on y.Member_ID equals mem.Member_UserID
                       select new { y.SectionName, mem.MemberFirstName, mem.MemberLastName };
            instructorGridView.DataSource = grid;
            instructorGridView.DataBind();

            var find = from x in dbcon.Instructors
                       where x.InstructorID == id
                       select x;
            foreach(var ran in find)
            {
                firstLabel.Text = ran.InstructorFirstName;
                lastLabel.Text = ran.InstructorLastName;
            }
            
            
        }
    }
}
