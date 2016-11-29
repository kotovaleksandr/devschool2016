using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Margatsni.Model;

namespace Margatsni.Wpf
{
	public class HttpClientWrapper
	{
		private readonly string _connectionString;
		private readonly HttpClient _client;

		public HttpClientWrapper(string connectionString)
		{
			_connectionString = connectionString;
			_client = new HttpClient
			{
				BaseAddress = new Uri(connectionString)
			};
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public User GetUserById(Guid id)
		{
			var result = _client.GetAsync(string.Format("{0}/api/users/{1}", _connectionString, id)).Result;
			return result.Content.ReadAsAsync<User>().Result;
		}
	}
}
