using System;
namespace Practice_9
{
	public class Lesson
	{
		private string subject, time, teacher;

		public Lesson(string subject, string time, string teacher) {
			this.subject = subject;
			this.time = time;
			this.teacher = teacher;
		}

		public void GetInfo() {
			Console.WriteLine($"Урок {subject}, в {time}, проводит {teacher}");
		}

		public string Teacher{
			get {
				return teacher;
			}
		}

    }
}

