using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;
using System.Linq;
using System.Security.Claims;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;


namespace iFridge_Backend.GraphQL.Users
{
    [ExtendObjectType(name: "Query")]
    public class UserQueries
    {
        [UseAppDbContext]
        public IQueryable<User> GetUsers([ScopedService] AppDbContext context)
        {
            return context.Users;
        }

        [UseAppDbContext]
        public User GetUser(int id, [ScopedService] AppDbContext context)
        {
            return context.Users.Find(id);
        }

        [UseAppDbContext]
        [Authorize]
        public User GetSelf(ClaimsPrincipal claimsPrincipal, [ScopedService] AppDbContext context)
        {
            var userIdStr = claimsPrincipal.Claims.First(c => c.Type == "userId").Value;

            return context.Users.Find(int.Parse(userIdStr));
        }

    }
}
