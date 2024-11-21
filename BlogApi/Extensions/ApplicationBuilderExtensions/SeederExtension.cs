using BlogApi.Services.DataSeeder.Contract;

namespace BlogApi.Extensions.ApplicationBuilderExtension.SeederExtension;

public static class SeederExtension
{

    public static void UseSeeder(this IApplicationBuilder app)
    {

        using var scope = app.ApplicationServices.CreateScope();

        var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();

        seeder.StartSeed();
    }

}
