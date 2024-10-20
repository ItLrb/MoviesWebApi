using System.Data;
using Dapper;
using MySqlConnector;
using UserInfosApi.Model;

namespace UserInfosApi.Repository;

public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private IDbConnection Connection => new MySqlConnection(_connectionString);

    public IEnumerable<User> GetAllUser()
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "SELECT * FROM Users";
            dbConnection.Open();
            return dbConnection.Query<User>(query);
        }
    }

    public User GetUserById(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "SELECT * FROM Users WHERE Id = @Id";
            dbConnection.Open();
            return dbConnection.QueryFirstOrDefault<User>(query, new { Id = id });
        }
    }

    public void AddUser(User user)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "INSERT INTO Users (Nome, Email, Role) VALUES (@Nome, @Email, @Role)";
            dbConnection.Open();
            dbConnection.Execute(query, user);
        }
    }

    public void UpdateUser(User user)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "UPDATE Users SET Nome = @Nome, Email = @Email, Role = @Role WHERE Id = @Id";
            dbConnection.Open();
            dbConnection.Execute(query, user);
        }
    }

    public void DeleteUser(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "DELETE FROM Users WHERE Id = @Id";
            dbConnection.Open();
            dbConnection.Execute(query, new { Id = id });
        }
    }
}