using System.Text;
using Auth.Contexts;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using HotChocolate.AspNetCore;
using HotChocolate;
using Auth.Models;

namespace Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            DotEnv.Load();  

        }
        public IConfiguration Configuration { get;}

        public void ConfigureServices(IServiceCollection services)
{
    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    services.AddDbContext<AuthContext>(options =>
                                        options.UseNpgsql(connectionString));
    services.AddCors();
    services.AddControllers();
    services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>();
/*             ;
    // Obtém o valor da variável de ambiente JWT_SECRET
    var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
    var key = Encoding.ASCII.GetBytes(secret);
 services.AddAuthentication(x=> {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme =JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>{
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        { 
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }); 
 */
}


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseRouting();
/*     app.UseAuthentication();
    app.UseAuthorization(); */
    
    app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
    app.UseWebSockets();

    app.UsePlayground();

    app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Hello World!");
        });
    endpoints.MapGraphQL();
});

}

    }
}
