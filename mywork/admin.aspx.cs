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
            conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\luke.vanberkom\\Source\\Repos\\vanberkom\\Karate2\\App_Data\\KarateSchool(1) (1).mdf\";Integrated Security=True;Connect Timeout=30";
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
                // Gets all the values from the textboxes
                string first = firstNameText.Text;
                string last = lastNameText.Text;
                string username = first + last;
                string type = "Member";
                string password = passwordText.Text;
                // Finds one above the max user id
                int max = 0;
                foreach( var x in dbcon.NetUsers)
                {
                    if(x.UserID > max)
                    {
                        max = x.UserID;
                    }
                }
                max = max + 1;
                string phone = phoneText.Text;
                string email = emailText.Text;
                // Makes a new user in the table
                NetUser addition = new NetUser();
                addition.UserID = max;
                addition.UserName = username;
                addition.UserPassword = password;
                addition.UserType = type;
                dbcon.NetUsers.InsertOnSubmit(addition);
                dbcon.SubmitChanges();
                // Connects the new user to a new member
                Member memAdd = new Member();
                memAdd.Member_UserID = addition.UserID;
                memAdd.MemberFirstName = first;
                memAdd.MemberLastName = last;
                memAdd.MemberEmail = email;
                memAdd.MemberPhoneNumber = phone;
                memAdd.MemberDateJoined = DateTime.Now;
                dbcon.Members.InsertOnSubmit(memAdd);
                dbcon.SubmitChanges();
                // Updates the grid view
                var members = from x in dbcon.NetUsers
                              join y in dbcon.Members on x.UserID equals y.Member_UserID
                              select new { y.MemberFirstName, y.MemberLastName, y.MemberPhoneNumber, y.MemberDateJoined };

                memberGridView.DataSource = members;
                memberGridView.DataBind();
            }
            catch { }
        }

        // Adding a instructor to the table
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Gets all the values from the textboxes
                string first = firstNameText.Text;
                string last = lastNameText.Text;
                string username = first + last;
                string type = "Member";
                string password = passwordText.Text;
                // Finds one above the max user id
                int max = 0;
                foreach (var x in dbcon.NetUsers)
                {
                    if (x.UserID > max)
                    {
                        max = x.UserID;
                    }
                }
                max = max + 1;
                string phone = phoneText.Text;
                // Makes a new user in the table
                NetUser addition = new NetUser();
                addition.UserID = max;
                addition.UserName = username;
                addition.UserPassword = password;
                addition.UserType = type;
                dbcon.NetUsers.InsertOnSubmit(addition);
                dbcon.SubmitChanges();
                // Connects the new user to a new instructor
                Instructor insAdd = new Instructor();
                insAdd.InstructorID = addition.UserID;
                insAdd.InstructorFirstName = first;
                insAdd.InstructorLastName = last;
                insAdd.InstructorPhoneNumber = phone;
                dbcon.Instructors.InsertOnSubmit(insAdd);
                dbcon.SubmitChanges();
                // Updates the instructor grid view
                var instructors = from net in dbcon.NetUsers
                                  join instructor in dbcon.Instructors on net.UserID equals instructor.InstructorID
                                  select new { instructor.InstructorFirstName, instructor.InstructorLastName };

                instructorGridView.DataSource = instructors;
                instructorGridView.DataBind();
            }
            catch { }
        }

        // Will delete a user based on the id given
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int user = Convert.ToInt32(deleteUserIDText.Text);

                string type = "";
                var u = from y in dbcon.NetUsers
                        where y.UserID == user
                        select y;

                // Sets the user type
                foreach (var x in u)
                {
                    type = x.UserType;
                }

                // Deleting sections with the user matching id
                var sections = from x in dbcon.Sections
                               where x.Instructor_ID == user || x.Member_ID == user
                               select x;
                foreach(var x in sections)
                {
                    dbcon.Sections.DeleteOnSubmit(x);
                }

                // Deletes all values in the member table with matching id
                if(type == "Member")
                {
                    var mems = from mem in dbcon.Members
                                  where mem.Member_UserID == user
                                  select mem;
                    foreach(var x in mems)
                    {
                        dbcon.Members.DeleteOnSubmit(x);
                    }
                    // Deletes all selected items
                    dbcon.SubmitChanges();
                } 
                // Deletes all values in instructor table with matching id
                else if (type == "Instructor")
                {
                    var inse = from ins in dbcon.Instructors
                                      where ins.InstructorID == user
                                      select ins;
                    // Deletes all selected instructors
                    foreach(var x in inse)
                    {
                        dbcon.Instructors.DeleteOnSubmit(x);
                    }
                    dbcon.SubmitChanges();
                }

                // Deletes from the user table with matching userID
                var us = from x in dbcon.NetUsers
                         where x.UserID == user
                         select x;
                foreach (var x in us)
                {
                    dbcon.NetUsers.DeleteOnSubmit(x);
                }
                dbcon.SubmitChanges();
                // Updates the member gridview
                var members = from x in dbcon.NetUsers
                              join y in dbcon.Members on x.UserID equals y.Member_UserID
                              select new { y.MemberFirstName, y.MemberLastName, y.MemberPhoneNumber, y.MemberDateJoined };

                memberGridView.DataSource = members;
                memberGridView.DataBind();

                // Updates the instructor grid view
                var instructors = from net in dbcon.NetUsers
                                  join instructor in dbcon.Instructors on net.UserID equals instructor.InstructorID
                                  select new { instructor.InstructorFirstName, instructor.InstructorLastName };

                instructorGridView.DataSource = instructors;
                instructorGridView.DataBind();
            } catch { }
        }

        // Assigns a member to a section
        protected void assignButton_Click(object sender, EventArgs e)
        {
            try
            { 
                int memID = Convert.ToInt32(assignUserIDText.Text);
                int secID = Convert.ToInt32(assignSectionText.Text);

                var sections = from x in dbcon.Sections
                               where x.Member_ID == memID
                               select x;

                foreach(var x in sections)
                {
                    x.SectionID = secID;
                }
            } catch { }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void instructorGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}