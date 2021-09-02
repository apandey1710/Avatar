using System;
using System.Collections.Generic;
using System.Linq;
using Avatar.Entities;

namespace Avatar.Repositories
{
    public class InMemGamesRepository : IGamesRepository
    {
        private readonly List<Game> items = new()
        {
            new Game
            {
                Id = Guid.NewGuid(), Name = "The Witcher 3: Wild Hunt.", Price = 45, CreatedDate = DateTimeOffset.UtcNow
            },
            new Game
            {
                Id = Guid.NewGuid(), Name = "Cyberpunk 2077", Price = 22, CreatedDate = DateTimeOffset.UtcNow
            },
            new Game
            {
                Id = Guid.NewGuid(), Name = "Bloatware 2021", Price = 13, CreatedDate = DateTimeOffset.UtcNow
            },
            new Game
            {
                Id = Guid.NewGuid(), Name = "Mass Effect 2 ", Price = 85, CreatedDate = DateTimeOffset.UtcNow
            },
        };

        public IEnumerable<Game> GetGames()
        {
            return this.items;
        }

        public Game GetGame(Guid id)
        {
            return items.SingleOrDefault(game => game.Id == id);
        }

        public void CreateGame(Game game)
        {
            items.Add(game);
        }

        public void UpdateGame(Game game)
        {
            var index = items.FindIndex(existingGame => existingGame.Id == game.Id);
            items[index] = game;
        }

        public void DeleteGame(Guid id)
        {
            var index = items.FindIndex(existingGame => existingGame.Id == id);
            items.RemoveAt(index);
        }
    }
}