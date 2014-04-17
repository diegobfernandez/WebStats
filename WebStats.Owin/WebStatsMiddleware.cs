using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebStats.Owin
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class WebStatsMiddleware
    {
        private readonly IRequestFactory _requestFactory;
        private readonly IRegisterRequestCommand _handler;

        public WebStatsMiddleware(IRequestFactory requestFactory, IRegisterRequestCommand handler)
        {
            _requestFactory = requestFactory;
            _handler = handler;
        }

        public void Run(IDictionary<string, object> environment)
        {
            var request = _requestFactory.GetInstance(environment);
            _handler.Execute(request);
        }
    }
}