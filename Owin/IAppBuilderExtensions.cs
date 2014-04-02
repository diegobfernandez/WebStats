using Owin;
using SimpleWebStats.Core;
using UAParser;

namespace SimpleWebStats.Owin
{
	public static class AppBuilderExtensions
	{
		public static void UseSimpleWebStats(this IAppBuilder app, IRequestStore requestStore)
		{
			var registerRequestCommand = new DefaultRegisterRequestCommand(requestStore);
			app.UseSimpleWebStats(registerRequestCommand);
		}

		public static void UseSimpleWebStats(this IAppBuilder app, IRegisterRequestCommand registerRequestCommand)
		{
            var requestFactory = new OwinRequestFactory(Parser.GetDefault());
			app.UseSimpleWebStats(registerRequestCommand, requestFactory);
		}

		public static void UseSimpleWebStats(this IAppBuilder app, IRegisterRequestCommand registerRequestCommand, IRequestFactory requestFactory)
		{
			var middleware = new SimpleWebStatsMiddleware(requestFactory, registerRequestCommand);
			app.Use(middleware);
		}
	}
}