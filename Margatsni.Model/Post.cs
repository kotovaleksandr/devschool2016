using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margatsni.Model
{
	public class Post
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public byte[] Photo { get; set; }
		public DateTime Date { get; set; }
		public string[] Hashtag { get; set; }
	}
}
