using HttpServerLibrary;
using MyHtttpServer.Session;
using MyHttttpServer.Models;
using MyORMLibrary;
using System.Data.SqlClient;
using System.Net;

namespace MyHtttpServer.Endponts
{
    public class AuthEndpoint : BaseEndpoint
    {

        [Get("login")]
        public IHttpResponseResult GetLogin()
        {
            var file = File.ReadAllText(@"Templates/Pages/Auth/login.html");
            if (IsAuthorized(Context)) return Redirect("movies");
            return Html(file);
        }

        [Post("login")]
        public IHttpResponseResult AuthPost(string email, string password)
        {
            string connectionString =
                @"Data Source=localhost;Initial Catalog=usersdb;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=true;";

            string query = "SELECT * FROM Users WHERE Email = @Email and Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int userId = reader.GetInt32(0);
                                string dbEmail = reader.GetString(1); 
                                string dbPassword = reader.GetString(2); 
                                string token = Guid.NewGuid().ToString();
                                Cookie cookie = new Cookie("session-token", token);
                                Context.Response.SetCookie(cookie);
                                SessionStorage.SaveSession(token, userId);
                                return Redirect("AllMovies");
                            }
                        }
                        else
                        {
                            return Redirect("login");
                        }
                    }
                }
            }
            return Redirect("login");
        }
        
        [Get("signup")]
        public IHttpResponseResult GetRegister()
        {
            var file = File.ReadAllText(@"Templates/Pages/Auth/SignUp.html");
            return Html(file);
        }
        
        [Post("signup")]
        public IHttpResponseResult PostRegister(string name, string email, string password)
        {
            string connectionString =
                @"Data Source=localhost;Initial Catalog=usersdb;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=true;";
            string query = "SELECT * FROM Users WHERE Email = @Email";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue(@"Password", password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return Redirect("signup");
                        }
                    }
                }
                string insertUserQuery = "INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)";

                using (SqlCommand insertCommand = new SqlCommand(insertUserQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@Name", name);
                    insertCommand.Parameters.AddWithValue("@Email", email);
                    insertCommand.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Redirect("login");
                        }
                        else
                        {
                            return Redirect("register");
                        }
                    }
                    catch (Exception ex)
                    {
                        return Html(File.ReadAllText("public/404.html"));
                    }
                }
            }
        }
        
        public bool IsAuthorized(HttpRequestContext context)
        {
            if (context.Request.Cookies.Any(c => c.Name == "session-token")) 
            {
                var cookie = context.Request.Cookies["session-token"];
                return SessionStorage.ValidateToken(cookie.Value);
            }
            return false;
        } 
    }
}
