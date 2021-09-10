using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.GraphQL.Users;
using iFridge_Backend.Models;
using System.Threading;
using System.Threading.Tasks;

namespace iFridge_Backend.GraphQL.UserFridges
{
    public class UserFridgeType : ObjectType<UserFridge>
    {
        protected override void Configure(IObjectTypeDescriptor<UserFridge> descriptor)
        {
            descriptor.Field(uf => uf.UserId).Type<NonNullType<IdType>>();
            descriptor.Field(uf => uf.FridgeId).Type<NonNullType<IdType>>();
            descriptor
                .Field(uf => uf.User)
                .ResolveWith<Resolvers>(r => r.GetUser(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<UserType>>();
            descriptor
                .Field(uf => uf.Fridge)
                .ResolveWith<Resolvers>(r => r.GetFridge(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<FridgeType>>();
        }

        private class Resolvers
        {
            public async Task<User> GetUser(UserFridge userFridge, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Users.FindAsync(new object[] { userFridge.UserId }, cancellationToken);
            }

            public async Task<Fridge> GetFridge(UserFridge userFridge, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Fridges.FindAsync(new object[] { userFridge.FridgeId }, cancellationToken);
            }
        }

    }
}
