using Avatar.Dtos;
using Avatar.Entities;

namespace Avatar
{
    public static class Extensions
    {
        public static GameDto AsDto(this Game game)
        {
            return new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                CreatedDate = game.CreatedDate
            };
        }
    }
}