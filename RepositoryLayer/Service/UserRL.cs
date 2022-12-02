using Microsoft.Extensions.Configuration;
using ModelLayer.Service;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL  : IUserRL
    {
        private readonly IConfiguration iconfiguration;

        public UserRL(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }

        //To Add new employee record      
        public EmpModel AddEmployee(EmpModel empModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.iconfiguration.GetConnectionString("EmployeeDBMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpName", empModel.EmpName);
                    cmd.Parameters.AddWithValue("@ProfileImg", empModel.ProfileImg);
                    cmd.Parameters.AddWithValue("@Gender", empModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", empModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", empModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", empModel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", empModel.Notes);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return empModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            
            }
            catch (Exception ex)
            {
                throw;
            }
        }   

        //To View all employees details      
        public IEnumerable<EmpModel> GetAllEmployees()
        {
            try
            {
                List<EmpModel> lstemployee = new List<EmpModel>();

                using (SqlConnection con = new SqlConnection(this.iconfiguration.GetConnectionString("EmployeeDBMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EmpModel empModel = new EmpModel();

                        empModel.EmpID = Convert.ToInt32(rdr["EmpID"]);
                        empModel.EmpName = rdr["EmpName"].ToString();
                        empModel.ProfileImg = rdr["ProfileImg"].ToString();
                        empModel.Gender = rdr["Gender"].ToString();
                        empModel.Department = rdr["Department"].ToString();
                        empModel.Salary = Convert.ToSingle(rdr["Salary"]);
                        empModel.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        empModel.Notes = rdr["Notes"].ToString();

                        lstemployee.Add(empModel);
                    }
                    con.Close();
                }
                return lstemployee;
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }

        //Get the details of a particular employee    
        public EmpModel GetEmployeeData(int? id)
        {
            try
            {
                EmpModel empModel = new EmpModel();
                using (SqlConnection con = new SqlConnection(this.iconfiguration.GetConnectionString("EmployeeDBMVC")))
                {
                    string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        empModel.EmpID = Convert.ToInt32(rdr["EmpID"]);
                        empModel.EmpName = rdr["EmpName"].ToString();
                        empModel.ProfileImg = rdr["ProfileImg"].ToString();
                        empModel.Gender = rdr["Gender"].ToString();
                        empModel.Department = rdr["Department"].ToString();
                        empModel.Salary = Convert.ToSingle(rdr["Salary"]);
                        empModel.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                        empModel.Notes = rdr["Notes"].ToString();
                    }
                }
                return empModel;
            }
            catch (Exception ex)
            {
                throw;
            }
                        
        }

        //To Update the records of a particluar employee    
        public EmpModel UpdateEmployee(EmpModel empModel)
        {
            try 
            {
                using (SqlConnection con = new SqlConnection(this.iconfiguration.GetConnectionString("EmployeeDBMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", empModel.EmpID);
                    cmd.Parameters.AddWithValue("@EmpName", empModel.EmpName);
                    cmd.Parameters.AddWithValue("@ProfileImg", empModel.ProfileImg);
                    cmd.Parameters.AddWithValue("@Gender", empModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", empModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", empModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", empModel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", empModel.Notes);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return empModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        //To Delete the record on a particular employee    
        public bool DeleteEmployee(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.iconfiguration.GetConnectionString("EmployeeDBMVC")))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", id);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
