using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace iFridge_Backend.Extensions
{
    public static class ObjectFieldDescriptorExtensions
    {
        public static IObjectFieldDescriptor UseAppDbContext<TDbContext>(
            this IObjectFieldDescriptor descriptor)
            where TDbContext : DbContext
        {
            return descriptor.UseScopedService<TDbContext>(
                create: s => s.GetRequiredService<IDbContextFactory<TDbContext>>().CreateDbContext(),
                disposeAsync: (s, c) => c.DisposeAsync());
        }
    }
}
