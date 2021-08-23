using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;
using System.Linq;

namespace iFridge_Backend.GraphQL.Users
{
    [ExtendObjectType(name: "Query")]
    public class UserQueries
    {
        [UseAppDbContext]
        [UsePaging]
        public IQueryable<User> GetUsers([ScopedService] AppDbContext context)
        {
            return context.Users;
        }

        [UseAppDbContext]
        public User GetUsers(int id, [ScopedService] AppDbContext context)
        {
            return context.Users.Find(id);
        }
    }
}
