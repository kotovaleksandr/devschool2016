using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Margatsni.Model;
using NLog;
using Logger = Margatsni.Log.Logger;

namespace Margatsni.DataLayer.Sql
{
	public class DataLayer : IDataLayer
	{
		private readonly NLog.Logger _instance = LogManager.GetCurrentClassLogger();
		private readonly string _connectionString;

		public DataLayer(string connectionString)
		{
			if (connectionString == null)
				throw new ArgumentNullException(nameof(connectionString));

			_connectionString = connectionString;
		}

		public User AddUser(User user)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					user.Id = Guid.NewGuid();
					Logger.Instance.Info("Add user, id: {0}, name: {1}", user.Id, user.Name);
					command.CommandText = "insert into users (id, name) values (@id, @name)";
					command.Parameters.AddWithValue("@id", user.Id);
					command.Parameters.AddWithValue("@name", user.Name);
					command.ExecuteNonQuery();
					return user;
				}
			}
		}

		public Post AddPost(Post post)
		{
			throw new NotImplementedException();
		}

		public User GetUser(Guid id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = "select id, name from users where id = @id";
					command.Parameters.AddWithValue("@id", id);
					using (var reader = command.ExecuteReader())
					{
						reader.Read();
						return new User
						{
							Id = reader.GetGuid(0),
							Name = reader.GetString(1)
						};
					}
				}
			}
		}

		public Post GetPost(Guid postId)
		{
			throw new NotImplementedException();
		}
	}
}
