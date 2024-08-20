using BankApi.DataAccess;
using BankApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankApiFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransController : ControllerBase
    {
        private readonly TransactionDbContext _context;

        public TransController(TransactionDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaction(Transaction transaction)
        {
            // Gerekli alanları kontrol edelim
            if (transaction == null ||
                transaction.SenderAccountNumber == 0 ||
                transaction.ReceiverAccountNumber == 0 ||
                transaction.Amount <= 0)
            {
                return BadRequest("Geçersiz işlem verisi");
            }

            // Yeni transferi veritabanına ekleyin
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }
    }
}
