namespace CFSClient.GoF
{
	public class Singleton
	{
		// Implement double check locking pattern to support for multi threading environment
		// Use lazy loading
		private static Singleton _instance;
		private static object _lock = new object();
		private Singleton() {}

		public static Singleton GetInstance()
		{
			//First check
			if (_instance == null)
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new Singleton();
					}
				}				
			}
			return _instance;
		}
	}
}
