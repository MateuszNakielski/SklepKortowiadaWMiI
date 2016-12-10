using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepKortowiadaWMiI.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }             //Identyfikator produktu
        [Required]
        public string Name { get; set; }        //Nazwa Produktu
        public string Description { get; set; } //Opis Produktu
        public decimal Price { get; set; }      //Cena Produktu
        public string PictureUrl { get; set; }  //Adres URL Obrazka produktu
        public string Category { get; set; }    //Kategoria Produktu
    }
}