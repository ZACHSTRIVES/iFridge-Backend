using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;
using System.Threading;
using System.Threading.Tasks;

namespace iFridge_Backend.GraphQL.UserFridges
{
    [ExtendObjectType(name: "Mutation")]
    public class UserFridgeMutations
    {
        [UseAppDbContext]
        public async Task<UserFridge> AddUserFridgeAsync(AddUserFridgeInput input,
          [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var userFridge = new UserFridge
            {
                UserId = int.Parse(input.UserId),
                FridgeId = int.Parse(input.FridgeId)

            };
            context.UserFridges.Add(userFridge);

            await context.SaveChangesAsync(cancellationToken);

            return userFridge;
        }
    }
}
