using System;
using System.Collections.Generic;
using System.Net;
using UAParser;

namespace WebStats.Owin
{
    public class OwinRequestFactory : IRequestFactory
    {
        private readonly Parser _parser;

        public OwinRequestFactory()
        {
            _parser = Parser.GetDefault();
        }

        public Request GetInstance(object environment)
        {
            var owinEnvironment = environment as IDictionary<string, object>;
            if (owinEnvironment == null)
            {
                var message = String.Format("The enviroment variable type must be '{0}'",
                    typeof (IDictionary<string, object>).AssemblyQualifiedName);

                throw new ArgumentException(message, "environment");
            }

            var dateTime = DateTime.Now;
            var headers = owinEnvironment["owin.RequestHeaders"] as IDictionary<string, string[]>;
            if (headers == null)
                throw new InvalidOperationException("The enviroment does not have \"owin.RequestHeaders\" property.");
            var userAgentString = headers["User-Agent"][0];

            var clientInfo = _parser.Parse(userAgentString);

            IPEndPoint remoteIPEndPoint = null;
            var remoteIPAddressString = owinEnvironment["server.RemoteIpAddress"] as string;
            if (remoteIPAddressString != null)
            {
                IPAddress remoteIpAddress;
                IPAddress.TryParse(remoteIPAddressString, out remoteIpAddress);

                var portString = owinEnvironment["server.RemotePort"] as string;
                Int32 port;
                Int32.TryParse(portString, out port);

                remoteIPEndPoint = new IPEndPoint(remoteIpAddress, port);
            }

            var os = new OS(clientInfo.OS.Family, clientInfo.OS.Major, clientInfo.OS.Minor, clientInfo.OS.Patch, clientInfo.OS.PatchMinor);
            var device = new Device(clientInfo.Device.Family, clientInfo.Device.IsSpider);
            var userAgent = new UserAgent(clientInfo.UserAgent.Family, clientInfo.UserAgent.Major, clientInfo.UserAgent.Minor, clientInfo.UserAgent.Patch);
            var swsClientInfo = new ClientInfo(os, device, userAgent);

            return new Request(remoteIPEndPoint, swsClientInfo, dateTime);
        }
    }
}