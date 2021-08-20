using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;

namespace iFridge_Backend.GraphQL.Foods
{
    [ExtendObjectType(name: "Query")]
    public class FoodQueries
    {
        [UseAppDbContext]
        [UsePaging]
        public IQueryable<Food> GetFoods([ScopedService] AppDbContext context)
        {
            return context.Foods.OrderBy(c => c.Created);
        }

        [UseAppDbContext]
        public Food GetFoods(int id, [ScopedService] AppDbContext context)
        {
            return context.Foods.Find(id);
        }
    }
}
