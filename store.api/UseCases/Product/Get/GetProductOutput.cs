namespace store.api.UseCases.Product.Get
{
    public class GetProductOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
