using SklepKortowiadaWMiI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SklepKortowiadaWMiI.WebModels
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            lines.Add(new CartLine()
            {
                Product = product,
                Quantity = quantity
            });
        }

        public void RemoveItem(int number)
        {
            lines.Remove(lines[number]);
        }

        public decimal TotalValue()
        {
            return lines.Sum(l => l.Product.Price * l.Quantity);
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lines;
            }
        }

        public class CartLine
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}