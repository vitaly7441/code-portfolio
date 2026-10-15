using System;
namespace Practice5_TestingPlatform.Models
{
    public class TestStudent
    {
        public int TestId { get; set; }
        public Test Test { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}

