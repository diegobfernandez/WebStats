using System.Collections.Generic;
using SimpleWebStats.Core;

namespace SimpleWebStats.InMemoryStoreSample
{
	public class InMemoryRequestStore : IRequestStore
	{
		public static ICollection<Request> Requests;

		static InMemoryRequestStore()
		{
			Requests = new List<Request>();
		}

		public void Add(Request request)
		{
			Requests.Add(request);
		}
	}
}