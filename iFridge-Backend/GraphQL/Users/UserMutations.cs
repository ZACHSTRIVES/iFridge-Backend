using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using iFridge_Backend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Octokit;

namespace iFridge_Backend.GraphQL.Users
{
    [ExtendObjectType(name: "Mutation")]
    public class UserMutations

    {

        [UseAppDbContext]
        public async Task<Models.User> AddUserAsync(AddUserInput input,
        [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var user = new Models.User
            {
                Name = input.Name,
                GitHub = input.GitHub,
                ImageURI = input.ImageURI,
            };

            context.Users.Add(user);
            await context.SaveChangesAsync(cancellationToken);

            return user;
        }

        [UseAppDbContext]
        public async Task<Models.User> EditUserAsync(EditUserInput input,
                [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync(int.Parse(input.UserId));

            user.Name = input.Name ?? user.Name;
            user.GitHub = input.GitHub ?? user.GitHub;
            user.ImageURI = input.ImageURI ?? user.ImageURI;

            await context.SaveChangesAsync(cancellationToken);

            return user;
        }

        [UseAppDbContext]
        public async Task<LoginPayload> LoginAsync(LoginInput input, [ScopedService] AppDbContext context, CancellationToken cancellationToken)
        {
            var client = new GitHubClient(new ProductHeaderValue("iFridge"));

            var request = new OauthTokenRequest("sss", "sss", input.Code);
            var tokenInfo = await client.Oauth.CreateAccessToken(request);

            if (tokenInfo.AccessToken == null)
            {
                throw new GraphQLRequestException(ErrorBuilder.New()
                    .SetMessage("Bad code")
                    .SetCode("AUTH_NOT_AUTHENTICATED")
                    .Build());
            }


        }




    }
}
