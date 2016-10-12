using System;
using Margatsni.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Margatsni.Tests
{
	[TestClass]
	public class DataLayerSqlTests
	{
		private const string ConnectionString = "Data Source=sql-dv2017-1;Initial Catalog=margatsni;Integrated Security=True";

		[TestMethod]
		public void ShouldAddUser()
		{
			//arrange
			var user = new User
			{
				Name = Guid.NewGuid().ToString().Substring(10)
			};
			var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
			//act
			user = dataLayer.AddUser(user);
			//asserts
			var resultUser = dataLayer.GetUser(user.Id);
			Assert.AreEqual(user.Name, resultUser.Name);
		}

		[TestMethod]
		public void ShouldAddPost()
		{
			//arrange
			var post = new Post
			{
				UserId = Guid.NewGuid(),
			};
			//act
			var dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
			post = dataLayer.AddPost(post);
			//asserts
			var resultPost = dataLayer.GetPost(post.Id);
			Assert.AreEqual(post.UserId, resultPost.UserId);
		}
	}
}
