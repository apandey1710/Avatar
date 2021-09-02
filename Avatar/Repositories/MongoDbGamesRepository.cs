using System;
using System.Collections.Generic;
using Avatar.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Avatar.Repositories
{
    public class MongoDbGamesRepository : IGamesRepository
    {
        private const string DatabaseName = "Avatar";
        private const string CollectionName = "Games";
        
        private readonly IMongoCollection<Game> _gamesCollection;
        private readonly FilterDefinitionBuilder<Game> filterBuilder = Builders<Game>.Filter;

        public MongoDbGamesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            this._gamesCollection = database.GetCollection<Game>(CollectionName);
        }
        public IEnumerable<Game> GetGames()
        {
            return this._gamesCollection.Find(new BsonDocument()).ToList();
        }

        public Game GetGame(Guid id)
        {
            var filter = this.filterBuilder.Eq(game => game.Id, id);
            return this._gamesCollection.Find(filter).SingleOrDefault();
        }

        public void CreateGame(Game game)
        {
            this._gamesCollection.InsertOne(game);
        }

        public void UpdateGame(Game game)
        {
            var filter = this.filterBuilder.Eq(existingGame => existingGame.Id, game.Id);
            this._gamesCollection.ReplaceOne(filter, game);
        }

        public void DeleteGame(Guid id)
        {
            var filter = this.filterBuilder.Eq(game => game.Id, id);
            this._gamesCollection.DeleteOne(filter);
        }
    }
}