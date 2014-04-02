namespace SimpleWebStats.Core
{
	public interface IRegisterRequestCommand
	{
		void Execute(Request command);
	}
}