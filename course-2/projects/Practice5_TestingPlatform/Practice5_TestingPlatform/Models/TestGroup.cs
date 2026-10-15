using System;
using System.ComponentModel.DataAnnotations;

namespace Practice5_TestingPlatform.Models
{
    public class TestGroup
    {
        public int TestId { get; set; }
        public Test Test { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}

