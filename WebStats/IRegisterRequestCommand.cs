namespace WebStats
{
	public interface IRegisterRequestCommand
	{
		void Execute(Request command);
	}
}