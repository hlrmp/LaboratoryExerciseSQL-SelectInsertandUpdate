﻿using System;
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
    public partial class btnRegister : Form
    {
        public btnRegister()
        {
            InitializeComponent();
         
        }

        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName,LastName, Gender, Program;
        private long StudentId;


        private void button1_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmUpdateMember fupdate = new FrmUpdateMember();
            fupdate.Show();




        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtStudentId.Text == "" || txtFirstName.Text == "" || txtMiddlName.Text ==  "" || txtLastName.Text == "" || txtAge.Text == ""
                || string.IsNullOrEmpty(Convert.ToString(cbGender.Text)) || string.IsNullOrEmpty(Convert.ToString(cbProgram.Text)))
            {
                MessageBox.Show("Filup the ff.","Error",MessageBoxButtons.OK);
            }
            else
            {
                RegistrationID();

                StudentId = long.Parse(txtStudentId.Text);
                FirstName = txtFirstName.Text;
                MiddleName = txtMiddlName.Text;
                LastName = txtLastName.Text;
                Age = int.Parse(txtAge.Text);
                Gender = cbGender.Text;
                Program = cbProgram.Text;

                clubRegistrationQuery.RegisterStudent(ID: count, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);
            }
            
        }
      

        private void btnRegister_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
            comboboxes();



            Timer timer = new Timer();
            timer.Interval = (2 * 1000);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

        }


        public void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



        }
        public int RegistrationID()
        {
            clubRegistrationQuery.c();
           count =  clubRegistrationQuery.Count + 1;
            return count;
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



    }
}
