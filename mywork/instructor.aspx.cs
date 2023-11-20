﻿using System;
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
       



        protected void Page_Load(object sender, EventArgs e)
        {
            conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\luke.vanberkom\\Source\\Repos\\vanberkom\\Karate2\\App_Data\\KarateSchool(1) (1).mdf\";Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateDBDataContext(conn);


            var instructors = from net in dbcon.NetUsers
                              join instructor in dbcon.Instructors on net.UserID equals instructor.InstructorID
                              select new { instructor.InstructorFirstName, instructor.InstructorLastName };
            instructorGridView.DataSource = instructors;
            instructorGridView.DataBind();
        }


    }
}