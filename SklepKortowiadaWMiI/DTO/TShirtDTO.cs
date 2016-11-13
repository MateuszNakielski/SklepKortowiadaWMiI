using SklepKortowiadaWMiI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKortowiadaWMiI.DTO
{
    public class TShirtDTO : ProductDTO
    {
        public String Size { get; set; }
        public String Sex { get; set; }

        public static TShirtDTO ToTShirtDTO(TShirt p)
        {
            return new TShirtDTO()
            {
                Id = p.Id,
                Name = p.Name,
                PictureUrl = p.PictureUrl,
                Price = p.Price,
                Description = p.Description,
                Sex = p.Sex,
                Size = p.Size
            };
        }

        public static TShirt FromTShirtDTO(TShirtDTO p)
        {
            return new TShirt()
            {
                Id = p.Id,
                Name = p.Name,
                PictureUrl = p.PictureUrl,
                Price = p.Price,
                Description = p.Description,
                Sex = p.Sex,
                Size = p.Size
            };
        }
    }
}