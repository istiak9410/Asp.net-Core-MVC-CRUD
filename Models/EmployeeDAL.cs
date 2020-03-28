using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProjectMvcAspCore.Models
{
    public class EmployeeDAL
    {
        string connectionString = "data source=WIN-ART4IS40OK7;database=EMPLOYEEDB;Integrated Security=SSPI;persist security info=True;";


        //For select query 
        public IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            List<EmployeeInfo> emplist = new List<EmployeeInfo>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    EmployeeInfo emp = new EmployeeInfo();
                    emp.ID = Convert.ToInt32(dr["ID"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Company = dr["Company"].ToString();
                    emp.Designation = dr["Designation"].ToString();

                    emplist.Add(emp);
                }
                con.Close();
            }
            return emplist;
        }


        //For Insert
        public void AddEmployee(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender); 
                cmd.Parameters.AddWithValue("@Company", emp.Company); 
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //For update
        public void UpdateEmployee(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ID", emp.ID);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Company", emp.Company);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //For Delete
        public void DeleteEmployee(int? empId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", empId);
                
                                                                        
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //For Get Employee by id
        public EmployeeInfo GetEmployeeById(int? empId)
        {
            EmployeeInfo emp = new EmployeeInfo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", empId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.ID = Convert.ToInt32(dr["ID"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Company = dr["Company"].ToString();
                    emp.Designation = dr["Designation"].ToString();
                }
                con.Close();
            }
            return emp;
        }
    }
}
