using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Types;
using iFridge_Backend.Data;
using iFridge_Backend.Extensions;
using Microsoft.IdentityModel.Tokens;
using Octokit;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            var request = new OauthTokenRequest(Startup.Configuration["Github:ClientId"], Startup.Configuration["Github:ClientSecret"], input.Code);
            var tokenInfo = await client.Oauth.CreateAccessToken(request);

            if (tokenInfo.AccessToken == null)
            {
                throw new GraphQLRequestException(ErrorBuilder.New()
                    .SetMessage("Bad code")
                    .SetCode("AUTH_NOT_AUTHENTICATED")
                    .Build());
            }

            client.Credentials = new Credentials(tokenInfo.AccessToken);
            var user = await client.User.Current();

            var u = await context.Users.FirstOrDefaultAsync(s => s.GitHub == user.Login, cancellationToken);

            if (u == null)
            {
                u = new Models.User
                {
                    Name = user.Name ?? user.Login,
                    GitHub = user.Login,
                    ImageURI = user.AvatarUrl,
                };

                context.Users.Add(u);
                await context.SaveChangesAsync(cancellationToken);
            }

            // authentication successful so generate jwt token
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.Configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>{
                new Claim( "studentId", u.Id.ToString()),
            };

            var jwtToken = new JwtSecurityToken(
                "MSA-Yearbook",
                "MSA-Student",
                claims,
                expires: DateTime.Now.AddDays(90),
                signingCredentials: credentials);

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new LoginPayload(student, token);





        }




    }
}
