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
        [UsePaging]
        public IQueryable<Fridge> GetFridges([ScopedService] AppDbContext context)
        {
            return context.Fridges.OrderBy(c => c.Created);
        }

        [UseAppDbContext]
        public Fridge GetFridges(int id, [ScopedService] AppDbContext context)
        {
            return context.Fridges.Find(id);
        }
    }
}