using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LaboratoryExerciseSQL_SelectInsertandUpdate
{
    public partial class FrmUpdateMember : Form
    {
        public FrmUpdateMember()
        {
            InitializeComponent();
         

        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            comboboxes();
            stud();
            // textboxes();
            clubRegistrationQuery.sId = cbStudentId.Text;  // something wrong



        }



        public void comboboxes()
        {

            string[] ListOfProgram = new string[]
            {
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS in Accountancy",
            "BS in Hospitality Management",
            "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i].ToString());
            }


            string[] genders = new string[]
          {
            "Female",
            "Male"

          };

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(genders[i].ToString());
            }


        }

        protected override void OnPaint(PaintEventArgs e)    // border color 
        {
            //  base.OnPaint(e);

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                  Color.Teal, 10, ButtonBorderStyle.Solid,
                  Color.Teal, 10, ButtonBorderStyle.Solid,
                  Color.Teal, 10, ButtonBorderStyle.Solid,
                  Color.Teal, 10, ButtonBorderStyle.Solid);
        }  // border color

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        ClubRegistrationQuery clubRegistrationQuery = new ClubRegistrationQuery(); 

        public void textboxes()
        {
            clubRegistrationQuery.DisplayText();

             

            txtFirstName.Text = clubRegistrationQuery._FirstName;
            txtMiddlName.Text = clubRegistrationQuery._MiddleName;
            txtLastName.Text = clubRegistrationQuery._LastName;
            txtAge.Text = Convert.ToString(clubRegistrationQuery._Age);
            cbGender.Text = clubRegistrationQuery._Gender;
            cbProgram.Text = clubRegistrationQuery._Program;

           

        }

        private void stud()
        {

            clubRegistrationQuery.DisplayList();
            cbStudentId.DataSource = clubRegistrationQuery.bindingSource;
            cbStudentId.DisplayMember = "Student_Id";

           

        }

        private int ID, Age;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void cbStudentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            clubRegistrationQuery.sId = cbStudentId.Text;  // something wrong
            // stud();
        }

        private void cbStudentId_SelectedValueChanged(object sender, EventArgs e)
        {

            clubRegistrationQuery.sId = cbStudentId.Text;  // something wrong
            
        }

        private void cbStudentId_MouseClick(object sender, MouseEventArgs e)
        {
           
           
             textboxes();
          

        } 

        private long StudentId;

        private void btnConfirm_Click(object sender, EventArgs e)
        {
          

            if (cbStudentId.Text == "" || txtFirstName.Text == "" || txtMiddlName.Text == "" || txtLastName.Text == "" || txtAge.Text == ""
               || string.IsNullOrEmpty(Convert.ToString(cbGender.Text)) || string.IsNullOrEmpty(Convert.ToString(cbProgram.Text)))
            {
                MessageBox.Show("Filup the ff.", "Error", MessageBoxButtons.OK);
            }
            else
            {
              
                StudentId = long.Parse(cbStudentId.Text);
                FirstName = txtFirstName.Text;
                MiddleName = txtMiddlName.Text;
                LastName = txtLastName.Text;
                Age = int.Parse(txtAge.Text);
                Gender = cbGender.Text;
                Program = cbProgram.Text;

                clubRegistrationQuery.updateStudents(StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);
            }

        }
    }
}
