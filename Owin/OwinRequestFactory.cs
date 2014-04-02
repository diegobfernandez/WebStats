using System;
using System.Collections.Generic;
using System.Net;
using SimpleWebStats.Core;
using UAParser;
using ClientInfo = SimpleWebStats.Core.ClientInfo;
using Device = SimpleWebStats.Core.Device;
using OS = SimpleWebStats.Core.OS;
using UserAgent = SimpleWebStats.Core.UserAgent;

namespace SimpleWebStats.Owin
{
    public class OwinRequestFactory : IRequestFactory
    {
        private readonly Parser _parser;

        public OwinRequestFactory(Parser parser)
        {
            _parser = parser;
        }

        public Request GetInstance(IDictionary<string, object> environment)
        {
            var dateTime = DateTime.Now;
            var headers = environment["owin.RequestHeaders"] as IDictionary<string, string[]>;
            if (headers == null)
                throw new InvalidOperationException("The enviroment does not have \"owin.RequestHeaders\" property.");
            var userAgentString = headers["User-Agent"][0];

            var clientInfo = _parser.Parse(userAgentString);

            IPEndPoint remoteIPEndPoint = null;
            var remoteIPAddressString = environment["server.RemoteIpAddress"] as string;
            if (remoteIPAddressString != null)
            {
                IPAddress remoteIpAddress;
                IPAddress.TryParse(remoteIPAddressString, out remoteIpAddress);

                var portString = environment["server.RemotePort"] as string;
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