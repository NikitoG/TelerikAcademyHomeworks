using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentsAndCourses
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            var courses = "";
            var isFirst = true;
            foreach (ListItem item in this.Courses.Items)
            {
                if(item.Selected)
                {
                    if (!isFirst)
                    {
                        courses += ", ";
                    }
                    else
                    {
                        isFirst = false;
                    }

                    courses += item.Value;
                }
            }

            sb.Append("<h1>Register User:</h1>");
            sb.Append(string.Format("<p><span>First Name: </span><strong>{0}</strong></p>", this.FirstName.Text));
            sb.Append(string.Format("<p><span>Last Name: </span><strong>{0}</strong></p>", this.LastName.Text));
            sb.Append(string.Format("<p><span>Faculty Number: </span><strong>{0}</strong></p>", this.FacultyNumber.Text));
            sb.Append(string.Format("<p><span>University: </span><strong>{0}</strong></p>", this.University.Text));
            sb.Append(string.Format("<p><span>Specialty: </span><strong>{0}</strong></p>", this.Specialty.Text));
            sb.Append(string.Format("<p><span>Courses: </span><strong>{0}</strong></p>", string.Join(", ", courses)));

            this.PlaceHolder.Controls.Add(new LiteralControl(sb.ToString()));
        }
    }
}