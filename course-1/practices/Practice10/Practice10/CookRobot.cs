using System;

namespace Practice10
{
	public class CookRobot:Robot
	{
        public CookRobot(string model)
        {
            Model = model;
        }
        public override void PerformTask()
        {
            Console.WriteLine($"{Model} готовит еду");
        }
    }
}

