using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int  Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public bool IsActive { get; set; }
        public IFormFile Picture { get; set; }
    }
}
