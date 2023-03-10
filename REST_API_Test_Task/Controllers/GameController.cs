using Microsoft.AspNetCore.Mvc;
using REST_API_Test_Task.Models;
using REST_API_Test_Task.Data;

namespace REST_API_Test_Task.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly ApiContext _context;

        public GameController(ApiContext context)
        {
            _context = context; 
        }

        [HttpPost]
        public async Task<JsonResult> NewGameAsync()
        {
            Game game = new Game();

            game.Field = new GameField().CoonvertToJson();
            game.CurrentSign = Sign.X.ToString();

            await _context.Games.AddAsync(game);

            await _context.SaveChangesAsync();

            return new JsonResult(Ok(game));
        }

        [HttpPost]
        public async Task<JsonResult> MoveAsync(Game game, int i, int j, Sign sign)
        {
            var dbGame = await _context.Games.FindAsync(game.Id);
            if (dbGame == null)
                return new JsonResult(NotFound());

            if (dbGame.CurrentSign != sign.ToString())
                return new JsonResult(Ok(game));

            var gameField = GameField.GetFromJson(dbGame.Field);

            if (gameField.IsCellFree(i, j) == false)
                return new JsonResult(Ok(dbGame));
        
            gameField.EditSign(i, j, sign);
            dbGame.Field = gameField.CoonvertToJson();

            if (gameField.WinCheck())
            {
                Outcome outcome = new Outcome();
                outcome.Winner = sign.ToString();
                outcome.GameId = dbGame.Id;

                await _context.Outcomes.AddAsync(outcome);
            }
        
            if (sign == Sign.X)
                dbGame.CurrentSign = Sign.O.ToString();
            else if(sign == Sign.O)
                dbGame.CurrentSign = Sign.X.ToString();
        
            _context.Games.Update(dbGame);
            await _context.SaveChangesAsync();
        
            return new JsonResult(Ok(dbGame));
        }

        [HttpGet]
        public async Task<JsonResult> GetAsync(int id)
        {
            var result = await _context.Games.FindAsync(id);
            if(result == null) 
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
    }
}
