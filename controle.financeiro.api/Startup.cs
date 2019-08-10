using controle.financeiro.api.Helpers;
using controle.financeiro.domain.Contracts;
using controle.financeiro.domain.Flows;
using controle.financeiro.infra.Context;
using controle.financeiro.infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace controle.financeiro.api
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
            var configDb = Configuration.GetSection("MongoDB").Get<MongoDbDto>();
            services.AddCors();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<AccountFlows, AccountFlows>();
            services.AddScoped(i => new MongoContext(configDb.User, configDb.Password, configDb.Hash, configDb.Database, configDb.Port));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

            //serializa as decimais como Decimal128(por padrão o mongo salva como string, o que não permite fazer cálculos nas consultas)
            BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
            BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(option => option.AllowAnyOrigin()); ;
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
