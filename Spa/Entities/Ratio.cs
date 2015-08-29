using System;
using Spa.Infrastructure;

namespace Spa.Entities
{
    public class Ratio
    {
        public int RatioId { get; set; }
        public Enums.RatioGrade ProductRatio { get; set; }
        public DateTime AddDate { get; set; }
        public Product Product { get; set; }
        public User Customer { get; set; }
    }
}