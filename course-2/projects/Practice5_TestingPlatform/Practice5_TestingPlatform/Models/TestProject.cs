using System;
namespace Practice5_TestingPlatform.Models
{
    public class TestProject
    {
        public int TestId { get; set; }
        public Test Test { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

