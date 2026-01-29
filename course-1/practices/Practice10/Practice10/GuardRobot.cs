using System;
namespace Practice10
{
	public class GuardRobot:Robot
	{
        public GuardRobot(string model)
        {
            Model = model;
        }
        public override void PerformTask()
        {
            Console.WriteLine($"{Model} охраняет помещение");
        }
    }
}

