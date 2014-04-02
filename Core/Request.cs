using System;
using System.Net;

namespace SimpleWebStats.Core
{
	public class Request
	{
	    public DateTime DateTime { get; private set; }
		public IPEndPoint RemoteIPEndPoint { get; private set; }
		public ClientInfo ClientInfo { get; private set; }

		public Request(IPEndPoint ipEndPoint, ClientInfo clientInfo, DateTime dateTime)
		{
			RemoteIPEndPoint = ipEndPoint;
			ClientInfo = clientInfo;
		    DateTime = dateTime;
		}
	}
}