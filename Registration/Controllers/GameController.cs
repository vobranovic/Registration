using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Registration.Data;
using Registration.Models;

namespace Registration.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public GameController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var games = _dbContext.Game.OrderByDescending(g => g.Time).ToList();
            var userId = _userManager.GetUserId(HttpContext.User);

            foreach (var game in games)
            {
                game.PlayersRegistered = _dbContext.GameApplicationUser.Count(g => g.GameId == game.Id);

                var check = _dbContext.GameApplicationUser.FirstOrDefault(gau => gau.UserId == userId && gau.GameId == game.Id);
                if (check == null)
                {
                    game.LoggedUserRegistered = false;
                }
                else
                {
                    game.LoggedUserRegistered = true;
                }
            }

            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _dbContext.Game.Find(id);

            ViewBag.GameTime = game.Time;
            ViewBag.GameId = game.Id;

            var userId = _userManager.GetUserId(HttpContext.User);

            var gameApplicationUser = (from gau in _dbContext.GameApplicationUser
                                       where gau.GameId == id
                                       select new GameApplicationUser
                                       {
                                           Id = gau.Id,
                                           GameId = gau.GameId,
                                           UserId = gau.UserId,
                                           UserName = (from u in _dbContext.Users where u.Id == gau.UserId select u.UserName).FirstOrDefault()
                                       }).ToList();

            var check = gameApplicationUser.FirstOrDefault(gau => gau.UserId == userId);

            if (check == null)
            {
                ViewBag.Check = 0;
            }
            else
            {
                ViewBag.Check = 1;
            }


            return View(gameApplicationUser);
        }

        
        public IActionResult Register(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);            

            GameApplicationUser gameApplicationUser = new GameApplicationUser()
            {
                GameId = id,
                UserId = userId
            };

            _dbContext.GameApplicationUser.Add(gameApplicationUser);
            _dbContext.SaveChanges();

            return RedirectToAction("Details", new { id = id});
        }

        public IActionResult Unregister(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            _dbContext.GameApplicationUser.Remove(_dbContext.GameApplicationUser.FirstOrDefault(u => u.UserId == userId && u.GameId == id));
            _dbContext.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }

        
    }
}
