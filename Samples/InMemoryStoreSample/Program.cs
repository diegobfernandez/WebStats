using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;
using WebStats.Owin.Katana;
using WebStats.RequestStore.InMemory;

namespace WebStats.InMemoryStoreSample
{
    class Program
    {
        private const string TableTemplate =
            "<table>" +
                "<thead>" +
                    "<tr>" +
                        "<th>IP</th>" +
                        "<th>Date/Time</th>" +
                        "<th>Device</th>" +
                        "<th>OS</th>" +
                        "<th>Browser</th>" +
                    "</tr>" +
                "</thead>" +
                "<tbody>{0}</tbody>" +
            "</table>";

        private const string TableRowTemplate =
            "<tr>" +
                "<td>{0}</td>" +
                "<td>{1}</td>" +
                "<td>{2}</td>" +
                "<td>{3}</td>" +
                "<td>{4}</td>" +
            "</tr>";


        static void Configuration(IAppBuilder app)
        {
            var requestStore = new InMemoryRequestStore();
            app.UseWebStats(requestStore);

            app.Use((env, next) =>
            {
                env.Response.Write("<h1>Hello World!</h1>");
                env.Response.Write(String.Format("<p>There was {0} requests to this web site so far</p>", InMemoryRequestStore.Requests.Count));

                var tableRows = InMemoryRequestStore.Requests.Aggregate("", (current, request) => current + String.Format(TableRowTemplate, request.RemoteIPEndPoint, request.DateTime, request.ClientInfo.Device, request.ClientInfo.OS, request.ClientInfo.UserAgent));

                env.Response.Write(String.Format(TableTemplate, tableRows));
                return Task.FromResult(0);
            });
        }

        static void Main()
        {
            const string url = "http://localhost:8181";
            WebApp.Start(url, Configuration);
            Console.WriteLine("Listening at " + url);
            Console.ReadLine();
        }
    }
}