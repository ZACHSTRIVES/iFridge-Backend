using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using iFridge_Backend.Data;
using System.Reflection;

namespace iFridge_Backend.Extensions
{
    public class UseAppDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<AppDbContext>();
        }
    }
}
