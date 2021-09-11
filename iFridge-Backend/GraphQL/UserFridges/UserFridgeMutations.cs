using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.GraphQL.Fridges;
using iFridge_Backend.Models;
using System.Linq;
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

        [UseAppDbContext]
        public IQueryable<UserFridge> DeleteUserFridge(DeleteUserFridgeInput input,
         [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            context.RemoveRange(context.UserFridges.Where(u => u.FridgeId == int.Parse(input.FridgeId)));
            context.SaveChanges();

            return context.UserFridges.Where(u => u.FridgeId == int.Parse(input.FridgeId));

        }

        [UseAppDbContext]
        public Task<IQueryable<UserFridge>> RemoveFridgemateAsync(RemoveFridgemateInput input,
         [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            context.RemoveRange(context.UserFridges.Where(u => (u.FridgeId == int.Parse(input.FridgeId)&&(u.UserId==int.Parse(input.UserId)))));
            context.SaveChanges();

            return Task.FromResult(context.UserFridges.Where(u => u.FridgeId == int.Parse(input.FridgeId)));

        }
    }
}
