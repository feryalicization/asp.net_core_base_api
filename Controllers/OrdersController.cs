using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var orderId = Guid.NewGuid().ToString();
                var order = new Order
                {
                    OrderId = orderId,
                    CreatedAt = DateTime.UtcNow,
                    UserId = model.UserId,
                    OrderItems = model.Items.Select(i => new OrderItem
                    {
                        BookId = i.BookId,
                        Quantity = i.Quantity
                    }).ToList()
                };

                foreach (var item in order.OrderItems)
                {
                    var book = await _context.Books.FindAsync(item.BookId);
                    if (book == null)
                    {
                        return NotFound($"Book with ID {item.BookId} not found");
                    }

                    if (book.Qty < item.Quantity)
                    {
                        return BadRequest($"Not enough quantity available for book {book.Name}");
                    }

                    book.Qty -= item.Quantity;
                }

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { OrderId = orderId });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


    }
}
