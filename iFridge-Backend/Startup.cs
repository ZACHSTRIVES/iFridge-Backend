using iFridge_Backend.Data;
using iFridge_Backend.GraphQL.Foods;
using iFridge_Backend.GraphQL.Fridges;
using iFridge_Backend.GraphQL.UserFridges;
using iFridge_Backend.GraphQL.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace iFridge_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; } = default!;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services
                .AddGraphQLServer()
                .AddAuthorization()
                .AddQueryType(d => d.Name("Query"))
                     .AddTypeExtension<UserQueries>()
                     .AddTypeExtension<FridgeQueries>()
                     .AddTypeExtension<UserFridgeQueries>()
                     .AddTypeExtension<FoodQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                     .AddTypeExtension<UserMutations>()
                     .AddTypeExtension<FridgeMutations>()
                     .AddTypeExtension<UserFridgeMutations>()
                     .AddTypeExtension<FoodMutations>()
                .AddType<UserType>()
                .AddType<FridgeType>()
                .AddType<UserFridgeType>();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidIssuer = "MSA-Yearbook",
                            ValidAudience = "MSA-Student",
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = signingKey
                        };
                });

            services.AddAuthorization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }


    }
}
