using System.Data;
using Dapper;
using MySqlConnector;
using UserInfosApi.Model;

namespace UserInfosApi.Repository;

public class MovieRepository
{
    private readonly string _connectionString;

    public MovieRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private IDbConnection Connection => new MySqlConnection(_connectionString);

    public IEnumerable<Movie> GetAllMovies()
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "SELECT * FROM movies";
            dbConnection.Open();
            return dbConnection.Query<Movie>(query);
        }
    }

    public Movie GetMovieById(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "SELECT * FROM movies WHERE Id = @Id";
            dbConnection.Open();
            return dbConnection.QueryFirstOrDefault<Movie>(query, new { Id = id });
        }
    }

    public void AddMovie(Movie movie)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "INSERT INTO movies (Title, Description, Category) VALUES (@Title, @Description, @Category)";
            dbConnection.Open();
            dbConnection.Execute(query, movie);
        }
    }

    public void UpdateMovie(Movie movie)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "UPDATE movies SET Title = @Title, Description = @Description, Category = @Category WHERE Id = @Id";
            dbConnection.Open();
            dbConnection.Execute(query, movie);
        }
    }

    public void DeleteMovie(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = "DELETE FROM movies WHERE Id = @Id";
            dbConnection.Open();
            dbConnection.Execute(query, new { Id = id });
        }
    }
}