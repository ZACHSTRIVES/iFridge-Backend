using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using HotChocolate.Types;
using iFridge_Backend.Models;
using iFridge_Backend.Data;

namespace iFridge_Backend.GraphQL.Users
{
    public class UserType: ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(u => u.Id).Type<NonNullType<IdType>>();
            descriptor.Field(u => u.Name).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.GitHub).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.ImageURI).Type<NonNullType<StringType>>();

            descriptor
                .Field(u => u.UserFridges)
                .ResolveWith<Resolvers>(r => r.GetUserFridges(default!, default!, default))
                .UseDbContext<AppDbContext>()
                .Type<NonNullType<ListType<NonNullType<UserFridgeType>>>>();

           
        }

        private class Resolvers
        {
            public async Task<IEnumerable<UserFridge>> GetUserFridges(User user, [ScopedService] AppDbContext context,
                CancellationToken cancellationToken)
            {
                return await context.UserFridges.Where(u => u.UserId == user.Id).ToArrayAsync(cancellationToken);
            }

           
        }
    }
}
