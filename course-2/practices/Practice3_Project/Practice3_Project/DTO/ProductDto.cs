using System;
namespace Practice3_Project.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public decimal Price { get; set; }

        public ProductDto(int id, string name, decimal price) {

        }
    }
}

