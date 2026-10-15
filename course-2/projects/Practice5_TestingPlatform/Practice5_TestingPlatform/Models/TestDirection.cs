using System;
namespace Practice5_TestingPlatform.Models
{
    public class TestDirection
    {
        public int TestId { get; set; }
        public Test Test { get; set; }

        public int DirectionId { get; set; }
        public Direction Direction { get; set; }
    }
}

