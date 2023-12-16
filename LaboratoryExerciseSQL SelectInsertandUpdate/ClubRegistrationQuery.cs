﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Text;
using System.Collections;

namespace LaboratoryExerciseSQL_SelectInsertandUpdate
{
    internal class ClubRegistrationQuery
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private SqlDataReader sqlReader;

        public DataTable dataTable;
        public BindingSource bindingSource;

        private string connectionString;

        public string _FirstName, _MiddleName, _LastName, _Gender, _Program;
        public int _Age;


        public ClubRegistrationQuery()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\reichel domingo\Source\Repos\LaboratoryExerciseSQL SelectInsertandUpdate\LaboratoryExerciseSQL SelectInsertandUpdate\ClubDB.mdf"";Integrated Security=True";
          
            sqlConnect = new SqlConnection(connectionString);

            dataTable = new DataTable();
            bindingSource = new BindingSource();

        }
        public bool DisplayList()
        {
            string ViewClubMembers = "select Student_Id , FirstName , MiddleName , LastName , Age, Gender , Program from ClubMembers";
            sqlAdapter = new SqlDataAdapter(ViewClubMembers, sqlConnect);

            dataTable.Clear();
            sqlAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;


            sqlConnect.Open();

            SqlCommand command;
            command = new SqlCommand(ViewClubMembers, sqlConnect);
            sqlReader = command.ExecuteReader();
            sqlReader.Read();

            sqlConnect.Close();

            return true;

        }

        public string search()
        {
            string ViewClubMembers = "select Student_Id from ClubMembers";

            sqlConnect.Open();

            SqlCommand command;
            command = new SqlCommand(ViewClubMembers, sqlConnect);
            sqlReader = command.ExecuteReader();
            sqlReader.Read();
            string re;

              sqlAdapter = new SqlDataAdapter(ViewClubMembers , sqlConnect);
              DataTable dt = new DataTable();

            sqlConnect.Close();

            re = Convert.ToString( sqlAdapter.Fill(dt) );
    
                      



             return re;
        }

        public bool RegisterStudent(int ID, long StudentID, string FirstName, string
                                    MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand("INSERT INTO ClubMembers (ID, Student_ID, FirstName, MiddleName, LastName, Age, Gender, Program)  VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)", sqlConnect);
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentID;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;
            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
            return true;
        }

    }
}
