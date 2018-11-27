namespace CFSClient.GoF
{
	// Simple factory which has method to return concrete type instance as per input provided by client
	// Why: No scattered new keywords and concrete types are not exposed to client
	public class InvoiceFactory
	{
		//Consumed by client
		public IInvoice CreateInvoice(int invoiceType)
		{
			switch (invoiceType)
			{
				case 1: return new InterestInvoice();
				case 2: return new PenaltyInvoice();
				default: return new GSTInvoice();
			}
		}
	}

	public interface IInvoice { }

	public class InterestInvoice : IInvoice {}

	public class PenaltyInvoice : IInvoice {}

	public class GSTInvoice : IInvoice {}
}
