using iFridge_Backend.Data;
using iFridge_Backend.GraphQL.Foods;
using iFridge_Backend.GraphQL.Fridges;
using iFridge_Backend.GraphQL.UserFridges;
using iFridge_Backend.GraphQL.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace iFridge_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services
                .AddGraphQLServer()
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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
