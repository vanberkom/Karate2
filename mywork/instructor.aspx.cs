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
<<<<<<< HEAD
        KarateDBDataContext dbcon;
=======
        string dbcon;
>>>>>>> 3cf858d5b528191d0dcf50f590644cf4b370b062
       



        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\luke.vanberkom\\Source\\Repos\\vanberkom\\Karate2\\App_Data\\KarateSchool(1) (1).mdf\";Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateDBDataContext(conn);
=======
            conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\austi\\Source\\Repos\\vanberkom\\Karate2\\App_Data\\KarateSchool(1) (1).mdf\";Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateDBDataContext(conn);


            var instructors = from net in dbcon.NetUsers
                              join instructor in dbcon.Instructors on net.UserID equals instructor.InstructorID
                              select new { instructor.InstructorFirstName, instructor.InstructorLastName };

            GridView1.DataSource = instructors;
            GridView1.DataBind();

>>>>>>> 3cf858d5b528191d0dcf50f590644cf4b370b062


            var instructors = from net in dbcon.NetUsers
                              join instructor in dbcon.Instructors on net.UserID equals instructor.InstructorID
                              select new { instructor.InstructorFirstName, instructor.InstructorLastName };
            instructorGridView.DataSource = instructors;
            instructorGridView.DataBind();
        }


    }
}