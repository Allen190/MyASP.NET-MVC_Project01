using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Allen190Prj01.Models
{
    public class DBmanager
    {
        private readonly string ConnStr = "Data Source=.;Initial Catalog=dbPrj01;Integrated Security=True";

        public List<AdoMember> GetAdoMembers()
        {
            List<AdoMember> members = new List<AdoMember>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("select * from tMember");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AdoMember member = new AdoMember
                    {
                        MemId = reader.GetInt32(reader.GetOrdinal("MemId")),
                        MemName = reader.GetString(reader.GetOrdinal("MemName")),
                        MemGender = reader.GetString(reader.GetOrdinal("MemGender")),
                        MemPhone = reader.GetString(reader.GetOrdinal("MemPhone")),
                        MemEmail = reader.GetString(reader.GetOrdinal("MemEmail")),
                        MemBirthaay = reader.GetString(reader.GetOrdinal("MemBirthaay")),
                        MemAccount = reader.GetString(reader.GetOrdinal("MemAccount")),
                        //MemPassword = reader.GetString(reader.GetOrdinal("MemPassword"))
                    };
                    members.Add(member);
                }
            }
            else
            {
                Console.WriteLine("資料為空!");
            }
            sqlConnection.Close();
            return members;
        }

        public void NewMember(AdoMember member)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand(
            @"Insert into tMember(MemName,MemGender,MemPhone,MemEmail,MemBirthaay,MemAccount,,MemPassword)values(@MemName,@MemGender,@MemPhone,@MemEmail,@MemBirthaay,@MemAccount,@MemPassword)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@MemName", member.MemName));
            sqlCommand.Parameters.Add(new SqlParameter("@MemGender", member.MemGender));
            sqlCommand.Parameters.Add(new SqlParameter("@MemPhone", member.MemPhone));
            sqlCommand.Parameters.Add(new SqlParameter("@MemEmail", member.MemEmail));
            sqlCommand.Parameters.Add(new SqlParameter("@MemBirthaay", member.MemBirthaay));
            sqlCommand.Parameters.Add(new SqlParameter("@MemAccount", member.MemAccount));
            sqlCommand.Parameters.Add(new SqlParameter("@MemPassword", member.MemPassword));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        //public void ChengeTxt(ChangeString txt)
        //{
        //    SqlConnection sqlConnection = new SqlConnection(ConnStr);
        //    SqlCommand sqlCommand = new SqlCommand(
        //    @"Insert into tChangeString(fChar,fNewChar,fUpDateTime)values(@fChar,@fNewChar,@fUpDateTime)");
        //    sqlCommand.Connection = sqlConnection;
        //    sqlCommand.Parameters.Add(new SqlParameter("@fChar", txt.fChar));
        //    sqlCommand.Parameters.Add(new SqlParameter("@fNewChar", txt.fNewChar));
        //    sqlCommand.Parameters.Add(new SqlParameter("@fUpDateTime", txt.fUpDateTime));
        //    sqlConnection.Open();
        //    sqlCommand.ExecuteNonQuery();
        //    sqlConnection.Close();
        //}
    }
}