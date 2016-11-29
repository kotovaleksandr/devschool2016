using System;
using Margatsni.Model;

namespace Margatsni.Services
{
	public interface IDataLayer
	{
		User AddUser(User user);
		Post AddPost(Post post);
		User GetUser(Guid id);
		Post GetPost(Guid postId);
	}
}
