using System;
namespace Practice7
{
	public class Material
	{
		public string Title;

		public Material(string title) {
			Title = title;
		}

        public virtual void Display()
		{
			Console.WriteLine(Title);
		}
	}
}

