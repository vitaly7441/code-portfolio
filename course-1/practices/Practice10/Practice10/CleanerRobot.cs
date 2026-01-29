using System;
namespace Practice10
{
	public class CleanerRobot:Robot
	{
        public CleanerRobot(string model) {
            Model = model;
        }
        public override void PerformTask()
        {
            Console.WriteLine($"{Model} убирает комнату");
        }
    }
}

