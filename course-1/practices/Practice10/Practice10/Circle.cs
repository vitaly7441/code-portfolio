using System;
namespace Practice10
{
	public class Circle:Shape
	{
        public int radius { get; set; }

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
}

