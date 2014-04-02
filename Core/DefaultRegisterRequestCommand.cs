namespace SimpleWebStats.Core
{
	public class DefaultRegisterRequestCommand : IRegisterRequestCommand
	{
		private readonly IRequestStore _requestStore;

		public DefaultRegisterRequestCommand(IRequestStore requestStore)
		{
			_requestStore = requestStore;
		}

		public void Execute(Request request)
		{
			_requestStore.Add(request);
		}
	}
}