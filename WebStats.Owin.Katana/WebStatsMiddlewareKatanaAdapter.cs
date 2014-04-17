using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebStats.Owin.Katana
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class WebStatsMiddlewareKatanaAdapter
	{
        private AppFunc _next;
        private readonly WebStatsMiddleware _middleware;

        public WebStatsMiddlewareKatanaAdapter(IRequestFactory requestFactory, IRegisterRequestCommand handler)
		{
            _middleware = new WebStatsMiddleware(requestFactory, handler);
		}

        public void Initialize(AppFunc next)
		{
			_next = next;
		}

        public async Task Invoke(IDictionary<string, object> environment)
        {
            _middleware.Run(environment);
			await _next(environment);
		}
	}
}
