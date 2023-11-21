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
        string firstname;
        string lastname;

        string conn;
        KarateDBDataContext dbcon;
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id= Convert.ToInt32((string)Session["user"]);
            conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\luke.vanberkom\\Source\\Repos\\vanberkom\\Karate2\\App_Data\\KarateSchool(1) (1).mdf\";Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateDBDataContext(conn);

            var grid = from x in dbcon.Members
                       where x.Member_UserID == id
                       join y in dbcon.Sections on x.Member_UserID equals y.Member_ID
                       join ins in dbcon.Instructors on y.Instructor_ID equals ins.InstructorID
                       select new { y.SectionName, ins.InstructorFirstName, ins.InstructorLastName, y.SectionFee }; 

            GridView1.DataSource = grid;
            GridView1.DataBind();

            var find = from x in dbcon.Members
                       where x.Member_UserID == id
                       select x;
            foreach (var ran in find)
            {
                firstLabel.Text = ran.MemberFirstName;
                lastLabel.Text = ran.MemberLastName;
            }


        }
    }
}