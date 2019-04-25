using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using UnibetInterfaces;
using UnibetDAL.DTO;

namespace UnibetDAL
{
    public class UserContext : IUserContext
    {
        private readonly DatabaseConnection _connection;

        public UserContext(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public void Add(IUser person)
        {
            _connection.SqlConnection.Open();

            String query = "INSERT INTO Users (Username, Password, Email, BankBalance) VALUES(@Username, @Password, @Email, @BankBalance)";
            using (SqlCommand command = new SqlCommand(query, _connection.SqlConnection))
            {
                command.Parameters.AddWithValue("@Username", person.Username);
                command.Parameters.AddWithValue("@Password", person.Password);
                command.Parameters.AddWithValue("@Email", person.Email);
                command.Parameters.AddWithValue("@BankBalance", person.BankBalance);

                command.ExecuteNonQuery();
            }
        }

        public void AddMoney(IUser person)
        {
            _connection.SqlConnection.Open();
            String query = "UPDATE Users SET BankBalance = @BankBalance WHERE UserID = @Id";

            using (SqlCommand command = new SqlCommand(query, _connection.SqlConnection))
            {
                command.Parameters.AddWithValue("@Id", person.Id);
                command.Parameters.AddWithValue("@BankBalance", person.BankBalance);

                command.ExecuteNonQuery();
            }
        }

        public void Edit(IUser person)
        {
            _connection.SqlConnection.Open();
            String query = "UPDATE Users SET Username = @Username, Email = @Email, WHERE UserID = @Id";

            using (SqlCommand command = new SqlCommand(query, _connection.SqlConnection))
            {
                command.Parameters.AddWithValue("@Id", person.Id);
                command.Parameters.AddWithValue("@Username", person.Username);
                command.Parameters.AddWithValue("@Email", person.Email);

                command.ExecuteNonQuery();
            }
        }

        IEnumerable<IUser> IUserContext.GetAll()
        {
            _connection.SqlConnection.Open();

            var cmd = new SqlCommand("SELECT * FROM Users", _connection.SqlConnection);
            var reader = cmd.ExecuteReader();

            var userRecords = new List<IUser>();

            while (reader.Read())
            {
                var user = new UserDto
                {
                    Id = Convert.ToInt32(reader["UserID"]),
                    Username = reader["Username"]?.ToString(),
                    Password = reader["Password"]?.ToString(),
                    Email = reader["Email"]?.ToString(),
                    BankBalance = Convert.ToDecimal(reader["BankBalance"])
                };

                userRecords.Add(user);
            }

            return userRecords;
        }

        public IUser GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
