using AtakDomain.API.Services;
using AtakDomain.Common.Intarfaces;
using AtakDomain.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace AtakDomain.Tests
{
    internal class TestApp : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();
            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<AppDbContext>));
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("AtakDomain", root);
                });
            });
            return base.CreateHost(builder);
        }
    }
}