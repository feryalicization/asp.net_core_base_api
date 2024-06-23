using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string OrderId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
