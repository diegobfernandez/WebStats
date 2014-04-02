using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleWebStats.Core;

namespace SimpleWebStats.Owin
{
    public class SimpleWebStatsMiddleware
	{
		private Func<IDictionary<string, object>, Task> _next;
		private readonly IRequestFactory _requestFactory;
		private readonly IRegisterRequestCommand _handler;

		public SimpleWebStatsMiddleware(IRequestFactory requestFactory, IRegisterRequestCommand handler)
		{
			_requestFactory = requestFactory;
			_handler = handler;
		}

		public void Initialize(Func<IDictionary<string, object>, Task> next)
		{
			_next = next;
		}

		public async Task Invoke(IDictionary<string, object> environment)
		{
			var request = _requestFactory.GetInstance(environment);
			_handler.Execute(request);

			await _next(environment);
		}
	}
}