namespace Spa.Entities
{
    public class ProductVideo
    {
        public int ProductVideoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}