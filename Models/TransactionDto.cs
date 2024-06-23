
namespace BookStore.Models
{
    public class TransactionDto
    {
        public string UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
