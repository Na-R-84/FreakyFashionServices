using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 namespace ProductPrice.Models.Domain
{
    public class Product
    {
        public Product( string articleNr)
        {
            ArticleNr = articleNr;
        }

        public int RandomPrice { get; set; }
        public string ArticleNr { get; set; }

    }



}
