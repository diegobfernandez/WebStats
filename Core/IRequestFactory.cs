using System.Collections.Generic;

namespace SimpleWebStats.Core
{
	public interface IRequestFactory
	{
		Request GetInstance(IDictionary<string, object> environment);
	}
}