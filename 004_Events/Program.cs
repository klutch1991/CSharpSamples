namespace _004_Events
{
	delegate void BroadcastMessageHandler(string message);

	class Publisher
	{
		// we're getting add/remove methods here under the hood with compiler
		// add { MessageBroadcasted += value; }
		// remove { MessageBroadcasted -= value; }
		public event BroadcastMessageHandler MessageBroadcasted;

		public void SayHello()
		{
			MessageBroadcasted?.Invoke("Hello!");
		}
	}

	class PublisherNoEventPattern
	{
		public BroadcastMessageHandler MessageBroadcasted;

		public void SayHello()
		{
			MessageBroadcasted?.Invoke("Hello!");
		}
	}
	
	class Program
	{
		static void Main(string[] args)
		{
			var evented = new Publisher();
			// can only subscribe/unsibscribe outside of a class
			//var eventedDelegateTarget = evented.MessageBroadcasted.Target; // compilation error cuz it is event!

			var nonEvented = new PublisherNoEventPattern();
			// can do whatever needed with delegate itselt outside of a class
			var nonEventedDelegateTarget = nonEvented.MessageBroadcasted.Target; 
		}
	}
}
