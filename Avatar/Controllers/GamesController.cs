using System;
using System.Collections.Generic;
using System.Linq;
using Avatar.Dtos;
using Avatar.Entities;
using Avatar.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Avatar.Controllers
{
    [ApiController]
    [Route("games")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _repository;

        public GamesController(IGamesRepository repository)
        {
            this._repository = repository;
        }

        // Get Items.
        [HttpGet]
        public IEnumerable<GameDto> GetGames()
        {
            var items = _repository.GetGames().Select(game => game.AsDto());
            return items;
        }

        // Get /game/{id}
        [HttpGet("{id}")]
        public ActionResult<GameDto> GetGame(Guid id)
        {
            var item = _repository.GetGame(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<GameDto> CreateGame(CreateGameDto gameDto)
        {
            Game game = new()
            {
                Id = Guid.NewGuid(),
                Name = gameDto.Name,
                Price = gameDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            _repository.CreateGame(game);

            return CreatedAtAction(nameof(GetGame), new {id = game.Id}, game.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGame(Guid id, UpdateGameDto gameDto)
        {
            var existingGame = _repository.GetGame(id);
            if (existingGame is null)
            {
                return NotFound();
            }

            Game updatedGame = existingGame with
            {
                Name = gameDto.Name,
                Price = gameDto.Price
            };
            
            _repository.UpdateGame(updatedGame);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGame(Guid id)
        {
            var existingGame = _repository.GetGame(id);
            if (existingGame is null)
            {
                return NotFound();
            }

            _repository.DeleteGame(id);

            return NoContent();
        }
    }
}