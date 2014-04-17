using Owin;

namespace WebStats.Owin.Katana
{
	public static class AppBuilderExtensions
	{
		public static void UseWebStats(this IAppBuilder app, IRequestStore requestStore)
		{
			var registerRequestCommand = new DefaultRegisterRequestCommand(requestStore);
			app.UseWebStats(registerRequestCommand);
		}

		public static void UseWebStats(this IAppBuilder app, IRegisterRequestCommand registerRequestCommand)
		{
            var requestFactory = new OwinRequestFactory();
			app.UseWebStats(registerRequestCommand, requestFactory);
		}

		public static void UseWebStats(this IAppBuilder app, IRegisterRequestCommand registerRequestCommand, IRequestFactory requestFactory)
		{
			var middleware = new WebStatsMiddlewareKatanaAdapter(requestFactory, registerRequestCommand);
			app.Use(middleware);
		}
	}
}