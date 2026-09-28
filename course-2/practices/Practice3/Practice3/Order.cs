namespace Practice3;

class Order
{
    public int Id { get; set; }
    public string Customer { get; set; } = "";
    public string City { get; set; } = "";
    public decimal Price { get; set; }
    public bool Completed { get; set; }
}
