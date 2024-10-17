using FoodEx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodEx.Domain
{
    public class User : BaseEntity
    {
        [MaxLength(30), Required]
        public string? Login { get; set; }

        [MaxLength(30), Required]
        public string? Password { get; set; }

        [MaxLength(30), Required]
        public string? FirstName { get; set; }

        [MaxLength(30), Required]
        public string? LastName { get; set; }

        [MaxLength(30), Required]
        public string? Phone { get; set; }

        [MaxLength(30), Required]
        public string? Address { get; set; }

        public Role? Role { get; set; }
    }
}
