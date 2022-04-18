using ALSM.DataManager.Data;
using ALSM.DataManager.Library.DataAccess;
using ALSM.DataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;

namespace ALSM.DataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IUserData _userData;

        public UserController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IConfiguration config,
            IUserData userData)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
            _userData = userData;
        }

        [HttpGet]
        public UserModel GetById()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            

            return _userData.GetUserById(userId).First();
        }

        

    }
}
