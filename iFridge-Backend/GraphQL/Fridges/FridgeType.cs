using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.GraphQL.UserFridges;
using iFridge_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace iFridge_Backend.GraphQL.Users
{
    public class FridgeType : ObjectType<Fridge>
    {
        protected override void Configure(IObjectTypeDescriptor<Fridge> descriptor)
        {
            descriptor.Field(u => u.Id).Type<NonNullType<IdType>>();
            descriptor.Field(u => u.Name).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.OwnerId).Type<NonNullType<IdType>>();
            descriptor.Field(p => p.Modified).Type<NonNullType<DateTimeType>>();
            descriptor.Field(p => p.Created).Type<NonNullType<DateTimeType>>();

            descriptor
                .Field(u => u.UserFridges)
                .ResolveWith<Resolvers>(r => r.GetUserFridges(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<ListType<NonNullType<UserFridgeType>>>>();

            descriptor
                 .Field(f => f.Foods)
                 .ResolveWith<Resolvers>(r => r.GetFoods(default!, default!, default))
                 .UseDbContext<AppDbContext>()
                 .Type<NonNullType<ListType<NonNullType<Foods.FoodType>>>>();


        }

        private class Resolvers
        {
            public async Task<IEnumerable<UserFridge>> GetUserFridges(Fridge fridge, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.UserFridges.Where(uf => uf.FridgeId == fridge.Id).ToArrayAsync(cancellationToken);
            }

            public async Task<IEnumerable<Food>> GetFoods(Fridge fridge, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Foods.Where(f => f.FridgeID == fridge.Id).ToArrayAsync(cancellationToken);
            }


        }
    }
}
