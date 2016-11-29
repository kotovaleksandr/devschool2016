using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Margatsni.Model;
using Margatsni.Services;

namespace Margatsni.WebApi.Controllers
{
	public class UsersController : ApiController
	{
		private const string ConnectionString = "Data Source=sql-dv2017-1;Initial Catalog=margatsni;Integrated Security=True";
		private readonly IDataLayer _dataLayer;

		public UsersController()
		{
			_dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
		}

		[HttpPost]
		public User CreateUser(User user)
		{
			return _dataLayer.AddUser(user);
		}

		[HttpGet]
		[Route("api/users/{id}")]
		public User GetUser(Guid id)
		{
			return _dataLayer.GetUser(id);
		}

		[HttpDelete]
		[Route("api/users/{id}")]
		public void DeleteUsers(Guid id)
		{
			//todo: реализация удаления
		}
	}
}
