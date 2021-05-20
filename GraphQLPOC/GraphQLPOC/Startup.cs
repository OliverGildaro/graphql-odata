using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQLPOC.Mutations;
using GraphQLPOC.Queries;
using GraphQLPOC.Schemas;
using GraphQLPOC.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;

namespace GraphQLPOC
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
            services.AddControllers();
            services
                    .AddEntityFrameworkInMemoryDatabase()
                    .AddDbContext<AplicationContext>(context => { context.UseInMemoryDatabase("BookLists"); });
            //services.AddDbContext<AplicationContext>(opt => opt.UseInMemoryDatabase("BookLists"));

            // GraphQL type
            services.AddScoped<AuthorType>();
            services.AddScoped<AuthorInputType>();
            services.AddScoped<AuthorsQuery>();
            services.AddScoped<AuthorsMutation>();
            services.AddScoped<BookType>();
            services.AddScoped<BookInputType>();
            services.AddScoped<BooksMutation>();
            services.AddScoped<MutationContainer>();
            services.AddScoped<ISchema, AppSchema>();

            services.AddScoped<AuthorsRepository>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
             .AddSystemTextJson() //// or use AddNewtonsoftJson for .NET Core 2.2
             .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // GraphQL
            // Add http for Schema at default url /api
            app.UseGraphQL<ISchema>("/api");

            // Use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
