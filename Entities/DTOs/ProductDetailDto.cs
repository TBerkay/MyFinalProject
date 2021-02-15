using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    // dto tek başına tablo değil birden fazla tabloya karşılık gelebilir
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int UnitsInStock { get; set; }
    }
}
