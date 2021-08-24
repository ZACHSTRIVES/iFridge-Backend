using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Models;
using System.Threading;
using System.Threading.Tasks;


namespace iFridge_Backend.GraphQL.Foods
{
    public class FoodType : ObjectType<Food>
    {
        protected override void Configure(IObjectTypeDescriptor<Food> descriptor)
        {
            descriptor.Field(uf => uf.Id).Type<NonNullType<IdType>>();
            descriptor.Field(uf => uf.FridgeID).Type<NonNullType<IdType>>();


            descriptor
                .Field(f => f.Fridge)
                .ResolveWith<Resolvers>(r => r.GetFridge(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<FoodType>>();

        }

        private class Resolvers
        {
            public async Task<Fridge> GetFridge(Food food, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.Fridges.FindAsync(new object[] { food.FridgeID }, cancellationToken);
            }

        }
    }
}
