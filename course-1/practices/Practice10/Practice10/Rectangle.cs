using System;
namespace Practice10
{
	public class Rectangle:Shape
	{
		public int width { get; set; }
        public int height { get; set; }

		public Rectangle(int width, int height) {
			this.width = width;
			this.height = height;
		}

		public override double GetArea() {
			return width * height;
		}

		public override double GetPerimeter() {
			return 2 * (width + height);
		}
    }
}

