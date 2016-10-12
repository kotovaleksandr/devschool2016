using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margatsni.Model
{
	public interface IDataLayer
	{
		User AddUser(User user);
		Post AddPost(Post post);
		User GetUser(Guid id);
		Post GetPost(Guid postId);
	}
}
