using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;
using System.Linq;

namespace iFridge_Backend.GraphQL.Fridges
{
    [ExtendObjectType(name: "Query")]
    public class FridgeQueries
    {
        [UseAppDbContext]
        public IQueryable<Fridge> GetFridges([ScopedService] AppDbContext context)
        {
            return context.Fridges.OrderBy(c => c.Created);
        }

        [UseAppDbContext]
        public Fridge GetFridge(QueryFridgeInput input, [ScopedService] AppDbContext context)
        {
            return context.Fridges.Find(int.Parse(input.FridgeId));
        }
    }
}