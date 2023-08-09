

using Microsoft.Data.SqlClient;
using Securities.API.DB;
using Securities.API.Models;
using Securities.API.Services;
using System.Data;

namespace Securities.API.Repositories
{
    public class UserDataAccessLayer : BaseConnection, IUserDataAccessLayer
    {
        public UserDataAccessLayer(IConnectionConfig config) : base(config)
        {
        }

        //List all Users
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            List<User> lstUser = new List<User>();

            using (SqlConnection con = await _config.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("usp_GetAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new();

                    user.UserId = Convert.ToInt32(reader["UserId"]);
                    user.UserName = reader["Name"].ToString();
                    user.Gender = reader["Gender"].ToString();
                    user.City = reader["City"].ToString();

                    lstUser.Add(user);
                }
                con.Close();
            }
            return lstUser;
        }

        //Add a New User
        public async void AddAUser(UserResponse user)
        {
            using (SqlConnection con = await _config.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("usp_AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", user.UserName);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@City", user.City);

                //con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Update details of a user
        public async void UpdateUser(User user)
        {
            using (SqlConnection con = await _config.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@Name", user.UserName);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@City", user.City);

                //con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Get a detail of particular User
        public async Task<User> GetUserData(int id)
        {
            User user = new User();

            using (SqlConnection con = await _config.GetConnection())
            {
                string sqlquery = "SELECT * FROM tblUser WHERE UserId=" + id;
                SqlCommand cmd = new SqlCommand(sqlquery, con);

                //con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user.UserId = Convert.ToInt32(reader["UserId"]);
                    user.UserName = reader["Name"].ToString();
                    user.Gender = reader["Gender"].ToString();
                    user.City = reader["City"].ToString();
                }
            }
            return user;
        }

        //Delete a user
        public async void DeleteAUser(int id)
        {
            using (SqlConnection con = await _config.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", id);

                //con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
