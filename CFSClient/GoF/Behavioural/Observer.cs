using System;

namespace CFSClient.GoF.Behavioural
{
	// Also known as pub-sub pattern using multicast delgates

	// step1: Publisher
	public class TrainSignal
	{
		public Action TrainIsComing;

		public void HereComesAtrain()
		{
			Console.WriteLine("Train is coming...\n");
			TrainIsComing();
		}
	}

	// step2: Subscriber
	public class Car
	{
		public Car(TrainSignal trainSignal)
		{
			//register events or create invokation list
			trainSignal.TrainIsComing += StopCar;
		}

		public void StopCar()
		{
			Console.WriteLine("Apply break, stop the car!");
		}
	}

	public class ObserverClient
	{
		public static void PubSubPattern()
		{
			// step3: Create Publisher instance
			var trainSignal = new TrainSignal();

			//step4: add subscribers
			new Car(trainSignal);
			new Car(trainSignal);
			new Car(trainSignal);

			// step5: publish events to subscribers
			trainSignal.HereComesAtrain();

		}
	}
}
