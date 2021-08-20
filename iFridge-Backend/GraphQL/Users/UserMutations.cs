using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;

namespace iFridge_Backend.GraphQL.Users
{
    [ExtendObjectType(name: "Mutation")]
    public class UserMutations
    {
        [UseAppDbContext]
        public async Task<User> AddUserAsync(AddUserInput input,
        [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = input.Name,
                GitHub = input.GitHub,
                ImageURI = input.ImageURI,
            };

            context.Users.Add(user);
            await context.SaveChangesAsync(cancellationToken);

            return user;
        }

        [UseAppDbContext]
        public async Task<User> EditUserAsync(EditUserInput input,
                [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync(int.Parse(input.UserId));

            user.Name = input.Name ?? user.Name;
            user.GitHub = input.GitHub ?? user.GitHub;
            user.ImageURI = input.ImageURI ?? user.ImageURI;

            await context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
