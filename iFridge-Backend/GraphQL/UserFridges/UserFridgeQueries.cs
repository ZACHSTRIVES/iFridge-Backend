using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;

namespace iFridge_Backend.GraphQL.UserFridges
{
    [ExtendObjectType(name: "Query")]
    public class UserFridgeQueries
    {
        [UseAppDbContext]
        [UsePaging]
        public IQueryable<UserFridge> GetUserFridges([ScopedService] AppDbContext context)
        {
            return context.UserFridges.OrderBy(c => c.UserId);
        }

        [UseAppDbContext]
        public UserFridge GetUserFridges(int id, [ScopedService] AppDbContext context)
        {
            return context.UserFridges.Find(id);
        }
    }
}
