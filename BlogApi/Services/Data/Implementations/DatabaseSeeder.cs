using System;
using System.Reflection;
using BlogApi.Data;
using BlogApi.Data.Seeder;
using BlogApi.Services.Data.Contract;

namespace BlogApi.Services.Data.Implementations;

public class DatabaseSeeder : ISeeder
{

    private readonly IConfiguration _configuration;
    private readonly ApplicationContext _context;

    private readonly string seederNamespace;

    public DatabaseSeeder(IConfiguration configuration, ApplicationContext context)
    {
        _configuration = configuration;
        _context = context;

        seederNamespace = _configuration.GetSection("Seeder:Namespace").Value;
    }

    public void StartSeed()
    {
        var seederTypes = GetSeederTypes();

        foreach (var seeder in seederTypes)
        {
            seeder.Seed();
        }
    }

    private IEnumerable<IWillSeed> GetSeederTypes()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(IWillSeed).IsAssignableFrom(t) && t.Namespace == seederNamespace)
            .Select(t => (IWillSeed)Activator.CreateInstance(t, _context));
    }


}

