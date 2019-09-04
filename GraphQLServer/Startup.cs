using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Orders.Services;
using Orders.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GraphQLServer
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //registering services and graphql types
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<OrderType>();
            services.AddSingleton<CustomerType>();
            services.AddSingleton<OrderStatusesEnum>();
            services.AddSingleton<OrdersQuery>();
            services.AddSingleton<OrdersSchema>();

            //needed to make types available to graphql.net
            //WHen object is constructed that needs a dependency, this code runs to resolve it
            services.AddSingleton<IDependencyResolver>(
                c => new FuncDependencyResolver(type =>
                c.GetRequiredService(type)));
            //services.add
            //AddWebSo

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCookiePolicy();

            //app.UseMvc();
            app.UseDefaultFiles();
            app.UseSpaStaticFiles();
            app.UseWebSockets();
        }
    }
}
