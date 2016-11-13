using SklepKortowiadaWMiI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKortowiadaWMiI.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public static ProductDTO ToProductDTO(Product p)
        {
            return new ProductDTO()
            {
                Id = p.Id,
                Name = p.Name,
                PictureUrl = p.PictureUrl,
                Price = p.Price,
                Description = p.Description
            };
        }

        public static Product FromProductDTO(ProductDTO p)
        {
            return new Product()
            {
                Id = p.Id,
                Name = p.Name,
                PictureUrl = p.PictureUrl,
                Price = p.Price,
                Description = p.Description
            };
        }
    }
}