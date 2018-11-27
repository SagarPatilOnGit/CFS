using System;

namespace CFSClient.OOP
{
	// Dispose() used to release unmanged resource as and when required unlike Object.Finalize() for which
	// GC takes two iteration, 1st for release resource and second is to release actual object
	public class UsingClause : IDisposable
	{
		public void Dispose()
		{
			Console.WriteLine("Inside dispose");
		}
	}

	// client to consume type implemting IDisposable
	public class UsingClauseClient
	{
		public void ExecuteUsing()
		{
			using (var obj = new UsingClause())
			{
				Console.WriteLine("Inside using");
			}
			Console.WriteLine("Outside using");
		}
	}
}
