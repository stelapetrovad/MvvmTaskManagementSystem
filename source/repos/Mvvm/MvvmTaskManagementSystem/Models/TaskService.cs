using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace MvvmTaskManagementSystem.Models
{
    public class TaskService
    {
        SqlConnection ObjSqlConnection;
        SqlCommand ObjSqlCommand;

        public TaskService()
        {
            ObjSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["MvvmTMSConnection"].ConnectionString);
            ObjSqlCommand = new SqlCommand();
            ObjSqlCommand.Connection = ObjSqlConnection;
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;
        }

        public List<UserTask> GetAll()
        {
            List<UserTask> ObjUserTasksList = new List<UserTask>();
            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "udp_SelectAllTasks";

                ObjSqlConnection.Open();
                var ObjSqlDataReader = ObjSqlCommand.ExecuteReader();
                if (ObjSqlDataReader.HasRows)
                {
                    UserTask ObjUserTask = null;
                    while (ObjSqlDataReader.Read())
                    {
                        ObjUserTask = new UserTask();
                        ObjUserTask.Id = ObjSqlDataReader.GetInt32(0);
                        ObjUserTask.Name = ObjSqlDataReader.GetString(1);
                        ObjUserTask.CreatedDateTask = ObjSqlDataReader.GetDateTime(2);
                        ObjUserTask.RequiredByDateTask = ObjSqlDataReader.GetDateTime(3);
                        ObjUserTask.TaskDescription = ObjSqlDataReader.GetString(4);
                        ObjUserTask.TaskStatus = ObjSqlDataReader.GetString(5);
                        ObjUserTask.TaskType = ObjSqlDataReader.GetString(6);
                        ObjUserTask.UsersTask = ObjSqlDataReader.GetString(7);

                        ObjUserTasksList.Add(ObjUserTask);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();

            }
            return ObjUserTasksList;
        }
        
        public bool Add(UserTask objNewTask)
        {
            bool IsAdded = false;

            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "udp_InsertTask";
                ObjSqlCommand.Parameters.AddWithValue("@Id", objNewTask.Id);
                ObjSqlCommand.Parameters.AddWithValue("@Name", objNewTask.Name);
                ObjSqlCommand.Parameters.AddWithValue("@CreatedDateTask", objNewTask.CreatedDateTask.ToString("yyyy-MM-dd"));
                ObjSqlCommand.Parameters.AddWithValue("@RequiredByDateTask", objNewTask.RequiredByDateTask.ToString("yyyy-MM-dd"));
                ObjSqlCommand.Parameters.AddWithValue("@TaskDescription", objNewTask.TaskDescription);
                ObjSqlCommand.Parameters.AddWithValue("@TaskStatus", objNewTask.TaskStatus);
                ObjSqlCommand.Parameters.AddWithValue("@TaskType", objNewTask.TaskType);
                ObjSqlCommand.Parameters.AddWithValue("@UsersTask", objNewTask.UsersTask);

                ObjSqlConnection.Open();
                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsAdded = NoOfRowsAffected > 0;

                int i = 0;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return IsAdded;
        }

        public bool Update(UserTask objTaskToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "udp_UpdateTask";
                ObjSqlCommand.Parameters.AddWithValue("@Id", objTaskToUpdate.Id);
                ObjSqlCommand.Parameters.AddWithValue("@Name", objTaskToUpdate.Name);
                ObjSqlCommand.Parameters.AddWithValue("@CreatedDateTask", objTaskToUpdate.CreatedDateTask.ToString("yyyy-MM-dd"));
                ObjSqlCommand.Parameters.AddWithValue("@RequiredByDateTask", objTaskToUpdate.RequiredByDateTask.ToString("yyyy-MM-dd"));
                ObjSqlCommand.Parameters.AddWithValue("@TaskDescription", objTaskToUpdate.TaskDescription);
                ObjSqlCommand.Parameters.AddWithValue("@TaskStatus", objTaskToUpdate.TaskStatus);
                ObjSqlCommand.Parameters.AddWithValue("@TaskType", objTaskToUpdate.TaskType);
                ObjSqlCommand.Parameters.AddWithValue("@UsersTask", objTaskToUpdate.UsersTask);

                ObjSqlConnection.Open();
                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;

            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "udp_DeleteTask";
                ObjSqlCommand.Parameters.AddWithValue("@Id", id);            

                ObjSqlConnection.Open();
                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return IsDeleted;
        }

    }
}
