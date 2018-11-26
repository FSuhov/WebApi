using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BookShelfBusinessLogic;
using BookShelfBusinessLogic.Services;
using AutoMapper;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BookShelf
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
            services.AddAutoMapper();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver
                        = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                });
            var connection = @"Server=DESKTOP-PU90CNF;Database=WebApiLibrary;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<IDataProvider, LibraryContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            //    {
            //        Version = "v1",
            //        Title = "BookShelf",
            //        Description = "Level 4 task for softserve",
            //        TermsOfService = "Welcome everybody!",
            //        Contact = new Swashbuckle.AspNetCore.Swagger.Contact() { Name = "Alex Brylov", Email = "fsuf@ukr.net" }
            //    });

            //});

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            //app.UseHttpsRedirection();
            app.UseMvc();
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookLibrary V1");
            //});
        }
    }
}
