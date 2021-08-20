using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;

namespace iFridge_Backend.GraphQL.Fridges
{
    [ExtendObjectType(name: "Mutation")]
    public class FridgeMutations
    {
        [UseAppDbContext]
        public async Task<Fridge> AddFridgeAsync(AddFridgeInput input,
           [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var fridge = new Fridge
            {
                Name = input.Name,
                OwnerId = int.Parse(input.OwnerId),
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };
            context.Fridges.Add(fridge);

            await context.SaveChangesAsync(cancellationToken);

            return fridge;
        }

        [UseAppDbContext]
        public async Task<Fridge> EditFridgeAsync(EditFridgeInput input,
            [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var fridge= await context.Fridges.FindAsync(int.Parse(input.FridgeId));

            fridge.Name = input.Name ?? fridge.Name;
            fridge.Modified = DateTime.Now;

            await context.SaveChangesAsync(cancellationToken);

            return fridge;
        }
    }
}
