using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iFridge_Backend.GraphQL.Foods
{
    [ExtendObjectType(name: "Mutation")]
    public class FoodMutations
    {
        [UseAppDbContext]
        public async Task<Food> AddFoodAsync(AddFoodInput input,
          [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var food = new Food
            {

                OriginQTY = int.Parse(input.OriginQTY),
                CurrentQTY = int.Parse(input.CurrentQTY),
                Type = input.Type,
                ExpireDate = input.ExpireDate,
                Modified = DateTime.Now,
                Created = DateTime.Now,
            };
            context.Foods.Add(food);

            await context.SaveChangesAsync(cancellationToken);

            return food;
        }

        [UseAppDbContext]
        public async Task<Food> EditFoodAsync(EditFoodInput input,
            [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var food = await context.Foods.FindAsync(int.Parse(input.FoodID));

            food.OriginQTY = int.Parse(input.OriginQTY ?? food.OriginQTY.ToString());
            food.CurrentQTY = int.Parse(input.CurrentQTY ?? food.CurrentQTY.ToString());
            food.Type = input.Type ?? food.Type;
            food.Notes = input.Notes ?? food.Notes;
            food.ExpireDate = input.ExpireDate ?? food.ExpireDate;
            food.Modified = DateTime.Now;

            await context.SaveChangesAsync(cancellationToken);

            return food;
        }

    }
}
