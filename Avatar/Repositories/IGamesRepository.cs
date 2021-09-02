using System;
using System.Collections.Generic;
using Avatar.Entities;

namespace Avatar.Repositories
{
    public interface IGamesRepository
    {
        IEnumerable<Game> GetGames();
        Game GetGame(Guid id);

        void CreateGame(Game game);

        void UpdateGame(Game game);

        void DeleteGame(Guid id);
    }
}