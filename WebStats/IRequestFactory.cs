namespace WebStats
{
	public interface IRequestFactory
	{
		Request GetInstance(object owinEnvironment);
	}
}