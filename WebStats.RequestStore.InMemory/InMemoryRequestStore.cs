using System.Collections.Generic;

namespace WebStats.RequestStore.InMemory
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