using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;
using System.Linq;

namespace iFridge_Backend.GraphQL.Foods
{
    [ExtendObjectType(name: "Query")]
    public class FoodQueries
    {
        [UseAppDbContext]
        public IQueryable<Food> GetFoods([ScopedService] AppDbContext context)
        {
            return context.Foods.OrderBy(c => c.ExpireDate);
        }

        [UseAppDbContext]
        public Food GetFood(int id, [ScopedService] AppDbContext context)
        {
            return context.Foods.Find(id);
        }
    }
}
