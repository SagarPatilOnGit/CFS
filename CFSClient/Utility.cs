namespace CFSClient
{
	public static class Utility
	{
		private static int Visitor { get; set; }
		static Utility()
		{
			Visitor = 0;
		}

		public static int GetVisitorCount() => Visitor;

		public static int NextVisitor() => ++Visitor;
	}
}
