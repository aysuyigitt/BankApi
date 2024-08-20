using BankApi.DataAccess;
using BankApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankApiFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserDbContext _context; // DbContext sınıfınızın adını uygun şekilde güncelleyin

        public RegisterController(UserDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {

            // Veritabanında kullanıcı adına göre bir kontrol yapabilirsiniz
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.username == user.username);
            if (existingUser != null)
            {
                return Conflict("Kullanıcı veritabanında mevcut");
            }

            // Yeni kullanıcıyı veritabanına ekleyin
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}