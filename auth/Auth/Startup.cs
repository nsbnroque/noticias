using System.Text;
using Auth.Contexts;
using Auth.Models;
using dotenv.net;
using GraphQL;
using GraphQL.Server.Ui.GraphiQL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

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
            Console.WriteLine($"Connection string: {connectionString}");
            services.AddDbContext<AuthContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors();
            services.AddControllers();
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

            // Adiciona o middleware do servidor GraphQL
            services.AddGraphQL(b => b
                .AddSystemTextJson()
                .AddSchema<UserSchema>()
                .AddGraphTypes(typeof(UserSchema).Assembly));
                
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod());

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseGraphQLGraphiQL();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
