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

        private ClubRegistrationQuery clubRegistrationQuery;

        private void stud()
        {

           txtFirstName.Text = clubRegistrationQuery.search();
          
           /* string sid = clubRegistrationQuery.search();

            ArrayList arr = new ArrayList();
            arr.Add(sid);

          foreach(string id in arr)
            {
                cbStudentId.Items.Add(id);
            }*/
            
        }



    }
}
