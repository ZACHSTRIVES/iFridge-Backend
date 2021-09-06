using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;
using System.Linq;

namespace iFridge_Backend.GraphQL.UserFridges
{
    [ExtendObjectType(name: "Query")]
    public class UserFridgeQueries
    {
        
        [UseAppDbContext]
        public IQueryable<UserFridge> GetUserFridges(int id, [ScopedService] AppDbContext context)
        {
            return context.UserFridges.Where(uf => uf.UserId == id);
        }
    }
}
