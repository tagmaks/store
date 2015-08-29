namespace Spa.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int ShipPrice { get; set; }
        public Product Product { get; set; }
        public OfferList OfferList { get; set; }
    }
}