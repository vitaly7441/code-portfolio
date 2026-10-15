using System;
namespace Practice5_TestingPlatform.Models
{
    public class TestCourse
    {
        public int TestId { get; set; }
        public Test Test { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

